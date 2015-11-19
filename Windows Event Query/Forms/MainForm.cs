using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;
using System.Threading;

using Event_Query.Forms;


namespace Event_Query
{
    public partial class MainForm : Form
    {
        private List<Dictionary<string, string>> EventMasterList = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> EventDisplayList = new List<Dictionary<string, string>>();
        private List<string> DisplayedColumns = new List<string>();
        private List<string> ColumnKeyOrder = new List<string>();
        private List<string> populatedDomains = new List<string>();
        private bool eventsListView_sortOrder = false;
        private int thread_counter = 0;

        private List<string> DCList = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(ColumnHeader col_header in eventsListView.Columns)
            {
                this.ColumnKeyOrder.Add(col_header.Text);
            }
            get_Domains_Event();

            eventsListView.ColumnContextMenuClicked += (sndr, col) =>
            {
                columnHeader_contextMenu.Show(Cursor.Position);
            };
            eventsListView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(eventsListView_RetrieveVirtualItem);
            eventsListView.ColumnClick += eventsListViewColumn_Click;
            this.DC_TreeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(DC_TreeView_NodeMouseClick);
            this.DC_TreeView.AfterCheck += new TreeViewEventHandler(OnDCNodeCheck);
            
        }

        private void get_AllChildNodes(List<TreeNode> Nodes, TreeNode Node)
        {
            foreach (TreeNode thisNode in Node.Nodes)
            {
                Nodes.Add(thisNode);
                get_AllChildNodes(Nodes, thisNode);
            }
        }

        private void OnDCNodeCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                List<TreeNode> children = new List<TreeNode>();
                get_AllChildNodes(children, e.Node);
                foreach(TreeNode child in children)
                {
                    child.Checked = e.Node.Checked;
                }
            }
        }

        private void DC_TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.Equals("Domain") &&
                !this.populatedDomains.Contains(e.Node.Text))
            {
                this.populatedDomains.Add(e.Node.Text);
                Thread t = new Thread(() => update_DCTree_DomainNode(e.Node));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void get_Domains_Event()
        {
            Thread t = new Thread(() => update_DCTree_rootNode());
            t.IsBackground = true;
            t.Start();
        }

        private delegate void treeNodeDelegate(List<TreeNode> node_list, TreeNode selectedNode);
        private void update_Node(List<TreeNode> node_list, TreeNode selectedNode)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new treeNodeDelegate(update_Node), new object[] { node_list, selectedNode });
                return;
            }
            if (selectedNode != null)
            {
                Dictionary<string, TreeNode> SiteNodes = new Dictionary<string, TreeNode>();
                foreach (TreeNode node in node_list)
                {
                    string sitename = node.Tag.ToString().Substring(3);
                    if (SiteNodes.ContainsKey(sitename))
                    {
                        SiteNodes[sitename].Nodes.Add(node);
                        node.Checked = selectedNode.Checked;
                    }
                    else
                    {
                        TreeNode siteNode = new TreeNode();
                        siteNode.Text = sitename;
                        siteNode.Tag = "Site";
                        siteNode.Checked = node.Checked;
                        selectedNode.Nodes.Add(siteNode);
                        siteNode.Nodes.Add(node);
                        SiteNodes.Add(sitename, siteNode);
                    }
                }
                selectedNode.ExpandAll();
            }
            else
            {
                foreach (TreeNode node in node_list)
                {
                    this.DC_TreeView.Nodes.Add(node);
                }
            }
            
        }

        private void update_DCTree_DomainNode(TreeNode selectedNode)
        {
            List<TreeNode> DCList = get_DomainDCs(selectedNode);
            update_Node(DCList, selectedNode);
        }

        private void update_DCTree_rootNode()
        {
            try
            {
                this.populatedDomains.Add(Domain.GetCurrentDomain().Name);
                List<TreeNode> DomainList = get_ForestDomains();
                TreeNode nullNode = null;
                update_Node(DomainList, nullNode);
                string currentDomainName = Domain.GetCurrentDomain().Name;
                foreach(TreeNode domainNode in DomainList)
                {
                    if (domainNode.Text == currentDomainName)
                    {
                        update_DCTree_DomainNode(domainNode);
                        break;
                    }
                }
            }
            catch
            {
                StatusLabel.Text = "Failed to find domain.";
            }
            
        }

        private List<TreeNode> get_ForestDomains()
        {
            List<TreeNode> domains = new List<TreeNode>();
            try
            {
                Forest c_forest = Forest.GetCurrentForest();
                
                foreach (Domain dom in c_forest.Domains)
                {
                    TreeNode domain_Node = new TreeNode();
                    domain_Node.Text = dom.Name;
                    domain_Node.Tag = "Domain";
                    string Domain_ToolTipText = "";
                    Domain_ToolTipText = Domain_ToolTipText + "DomainMode:" + dom.DomainMode + Environment.NewLine;
                    Domain_ToolTipText = Domain_ToolTipText + "PDCOwner: " + dom.PdcRoleOwner + Environment.NewLine;
                    Domain_ToolTipText = Domain_ToolTipText + "RootDomain: " + c_forest.RootDomain.Name + Environment.NewLine;
                    domain_Node.ToolTipText = Domain_ToolTipText;
                    domains.Add(domain_Node);
                }
                c_forest.Dispose();
            }
            catch
            {

            }
            return domains;
        }

        private List<TreeNode> get_DomainDCs(TreeNode domain_Node)
        {
            List<TreeNode> DCNode_List = new List<TreeNode>();
            try
            {
                DirectoryContext DomContext = new DirectoryContext(DirectoryContextType.Domain, domain_Node.Text);
                Domain Dom = Domain.GetDomain(DomContext);

                foreach (DomainController DC in Dom.FindAllDomainControllers())
                {
                    TreeNode DCNode = new TreeNode();
                    DCNode.Text = DC.Name;
                    DCNode.Tag = "DC@" + DC.SiteName;

                    string DC_ToolTipText = "";
                    DC_ToolTipText = DC_ToolTipText + "SiteName: " + DC.SiteName + Environment.NewLine;
                    DC_ToolTipText = DC_ToolTipText + "OSVersion: " + DC.OSVersion + Environment.NewLine;
                    // DC_ToolTipText = DC_ToolTipText + "IPAddress: " + DC.IPAddress + Environment.NewLine;
                    if (DC.Roles.Count > 0)
                    {
                        string DCRoleString = "Roles:";
                        foreach (ActiveDirectoryRole DCRole in DC.Roles)
                        {
                            DCRoleString = DCRoleString + "\t" + DCRole.ToString() + Environment.NewLine;
                        }
                        DCNode.ToolTipText = DC_ToolTipText + DCRoleString;
                    }

                    DCNode_List.Add(DCNode);
                    DC.Dispose();
                }
                Dom.Dispose();
            }
            catch
            {
                // PASS Console.WriteLine("WHAT!");
            }
            return DCNode_List;
        }
        // EVENTS


        /// <summary>
        /// Displays items EventDisplayList in eventListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventsListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            List<string> row = new List<string>();
            
            foreach (ColumnHeader header_name in this.eventsListView.Columns)
            {
                if (this.EventDisplayList[e.ItemIndex].ContainsKey(header_name.Text))
                {
                    row.Add(this.EventDisplayList[e.ItemIndex][header_name.Text]);
                }
                else
                {
                    this.EventDisplayList[e.ItemIndex].Add(header_name.Text, "---");
                    row.Add("---");
                }

            }

            lvi.Text = this.EventDisplayList[e.ItemIndex][this.eventsListView.Columns[0].Text];
            lvi.SubItems.AddRange(row.Skip(1).ToArray());
            e.Item = lvi;
        }

        private void eventsListViewColumn_Click(object o, ColumnClickEventArgs e)
        {
            if (this.eventsListView_sortOrder)
            {
                //((x, y) => int.Parse(x.Name).CompareTo(int.Parse(y.Name))
                try // Attempt to sort by Date
                {
                    this.EventDisplayList = this.EventDisplayList.OrderBy(obj => Convert.ToDateTime(obj[this.eventsListView.Columns[e.Column].Text])).ToList();
                }
                catch (System.FormatException ex) 
                {
                    try // Attempt to sort by integer
                    {
                        this.EventDisplayList = this.EventDisplayList.OrderBy(obj => int.Parse(obj[this.eventsListView.Columns[e.Column].Text])).ToList();
                    }
                    catch (System.FormatException excep) // Sort by string
                    {
                        this.EventDisplayList = this.EventDisplayList.OrderBy(obj => obj[this.eventsListView.Columns[e.Column].Text]).ToList();
                    }
                }
            }
            else
            {
                //((x, y) => int.Parse(x.Name).CompareTo(int.Parse(y.Name))
                try // Attempt to sort by Date
                {
                    this.EventDisplayList = this.EventDisplayList.OrderByDescending(obj => Convert.ToDateTime(obj[this.eventsListView.Columns[e.Column].Text])).ToList();
                }
                catch (System.FormatException ex)
                {
                    try // Attempt to sort by integer
                    {
                        this.EventDisplayList = this.EventDisplayList.OrderByDescending(obj => int.Parse(obj[this.eventsListView.Columns[e.Column].Text])).ToList();
                    }
                    catch (System.FormatException excep) // Sort by string
                    {
                        this.EventDisplayList = this.EventDisplayList.OrderByDescending(obj => obj[this.eventsListView.Columns[e.Column].Text]).ToList();
                    }
                }
            }
            this.eventsListView_sortOrder = !this.eventsListView_sortOrder;
            this.eventsListView.Invalidate();
        }
        
        private void start_query(string query, string computername)
        {
            update_ThreadCounter(1);
            Thread t = new Thread(() => query_EventLogs(computername, query));
            t.IsBackground = true;
            t.Start();
        }

        

        private void queryEvents_Button_Click(object sender, EventArgs e)
        {
            string query = get_Query();
            // Console.WriteLine(query);
            if (query.Equals(""))
            {
                return;
            }
            bool keep_lock = false;
            enable_Interact(false);
            
            foreach (TreeNode node in this.DC_TreeView.Nodes)
            {
                List<TreeNode> children = new List<TreeNode>();
                get_AllChildNodes(children, node);
                foreach(TreeNode child in children)
                {
                    if (child.Tag.ToString().StartsWith("DC") &&
                        child.Checked)
                    {
                        start_query(query, child.Text);
                        keep_lock = true;
                    }
                }
            }
            if (!keep_lock)
            {
                enable_Interact(true);
            }
        }

        private void query_EventLogs(string computername, string query)
        {
            EventLogReader logReader = create_logReader(query, computername);
            if (logReader != null)
            {
                List<Dictionary<string, string>> return_list = new List<Dictionary<string, string>>();
                return_list = ParseEventLog(logReader, computername);
                this.EventMasterList.AddRange(return_list);
                update_EventListView(addItems_DisplayList(this.EventDisplayList, return_list, ColumnKeyOrder));
                update_ThreadCounter(-1);
            }
            else
            {
                update_ThreadCounter (-1);
            }
        }


        private delegate void integerDelegate(int cntr_change);
        private void update_ThreadCounter (int cntr_change)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new integerDelegate(update_ThreadCounter), new object[] { cntr_change });
                return;
            }
            this.thread_counter = this.thread_counter + cntr_change;
            this.StatusLabel.Text = String.Format("Querying: {0} remaining queries...", this.thread_counter);
            if (this.thread_counter == 0)
            {
                this.StatusLabel.Text = "Query complete!";
                enable_Interact(true);
            }
        }

        private void enable_Interact(bool should_enable)
        {
            this.queryEvents_Button.Enabled = should_enable;
            this.clearEventView_Button.Enabled = should_enable;
            this.columnHeader_contextMenu.Enabled = should_enable;
            this.addRemoveColumnsToolStripMenuItem1.Enabled = should_enable;
        }

        private void addRemoveColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Popup_ColumnPicker();
        }

        private void clearEventView_Button_Click(object sender, EventArgs e)
        {
            this.eventsListView.VirtualListSize = 0;
            this.EventDisplayList.Clear();
            this.EventMasterList.Clear();
            this.eventsListView.Invalidate();
        }


        // END EVENTS


        // START POPUPS


        /// <summary>
        /// Shows ColumnPicker popup and spawns off thread to recalcuate items in
        /// eventsListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Popup_ColumnPicker()
        {
            List<string> shown_headers = new List<string>();
            foreach (ColumnHeader lvheader in this.eventsListView.Columns)
            {
                shown_headers.Add(lvheader.Text);
            }
            ColumnPicker column_picker = new ColumnPicker();
            column_picker.ShowDialog(ref shown_headers, ref this.EventMasterList);
            // Spawns of thread to update EventMasterList for items and headers.
            if (column_picker.DialogResult == DialogResult.OK)
            {
                update_eventsLVHeaders(column_picker.shownColumns);
            }
            column_picker.Dispose();
        }


        // END POPUPS


        // START WIDGET UPDATES

        private delegate void DisplayListDelegate(List<Dictionary<string, string>> header);
        private void update_EventListView(List<Dictionary<string, string>> display_list)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DisplayListDelegate(update_EventListView), new object[] { display_list });
                return;
            }
            this.eventsListView.VirtualListSize = 0;
            this.EventDisplayList = display_list;
            this.eventsListView.VirtualListSize = this.EventDisplayList.Count();
            this.eventsListView.Invalidate();
        }


        private void update_eventsLVHeaders(List<string> column_headers)
        {
            this.ColumnKeyOrder = new List<string>(column_headers);
            this.eventsListView.VirtualListSize = 0;
            this.eventsListView.Columns.Clear();
            foreach(string c_header in column_headers)
            {
                ColumnHeader lvhdr = new ColumnHeader();
                lvhdr.Text = c_header;
                this.eventsListView.Columns.Add(lvhdr);
            }

            
            List<Dictionary<string, string>> keyed_DisplayList = reKey_DisplayList(column_headers, this.EventMasterList);
            update_EventListView(keyed_DisplayList);
        }


        // END WIDGET UPDATES


        private List<Dictionary<string, string>> reKey_DisplayList(List<string> keys, List<Dictionary<string, string>> master_lst)
        {
            Dictionary<string, Dictionary<string, string>> deduplicated_dict = new Dictionary<string, Dictionary<string, string>>();
            foreach(Dictionary<string, string> item in master_lst)
            {
                string key_code = "";
                foreach(string key in keys)
                {
                    if (item.Keys.Contains(key))
                    {
                        key_code = key_code + item[key];
                    }
                }

                if (deduplicated_dict.ContainsKey(key_code))
                {
                    int current_count;
                    bool parsed = Int32.TryParse(deduplicated_dict[key_code]["Count"], out current_count);
                    if (parsed)
                    {
                        current_count++;
                        deduplicated_dict[key_code]["Count"] = current_count.ToString();
                    }
                }
                else
                {
                    deduplicated_dict.Add(key_code, new Dictionary<string, string>(item));
                    deduplicated_dict[key_code].Add("Count", "1");
                    deduplicated_dict[key_code].Add("__KEY", key_code);
                }
            }

            List<Dictionary<string, string>> deduped_list = new List<Dictionary<string, string>>();
            foreach (string key_code in deduplicated_dict.Keys)
            {
                deduped_list.Add(deduplicated_dict[key_code]);
            }

            return deduped_list;
        }

        private List<Dictionary<string, string>> addItems_DisplayList(List<Dictionary<string, string>> disp_lst, 
                                            List<Dictionary<string, string>> addItems_lst,
                                            List<string> column_keyOrder)
        {
            Dictionary<string, Dictionary<string, string>> dispKey_dict = new Dictionary<string, Dictionary<string, string>>();
            foreach(Dictionary<string, string> entry in disp_lst)
            {
                dispKey_dict.Add(entry["__KEY"], entry);
            }

            foreach (Dictionary<string, string> entry in addItems_lst)
            {
                string key = "";
                foreach (string ky in column_keyOrder)
                {
                    if (entry.Keys.Contains(ky))
                    {
                        key = key + entry[ky];
                    }
                }
                if (dispKey_dict.Keys.Contains(key))
                {
                    int current_count;
                    bool parsed = Int32.TryParse(dispKey_dict[key]["Count"], out current_count);
                    if (parsed)
                    {
                        current_count++;
                        dispKey_dict[key]["Count"] = current_count.ToString();
                    }
                }
                else
                {
                    dispKey_dict.Add(key, new Dictionary<string, string>(entry));
                    dispKey_dict[key].Add("Count", "1");
                    dispKey_dict[key].Add("__KEY", key);
                }
                
            }

            return dispKey_dict.Values.ToList();
        }


        private string get_Query()
        {
            string username = textbox_TargetUserName.Text;
            string username_time = "";
            if (!username.Equals("*"))
            {
                username_time = username_time + "*/EventData[Data[@Name='TargetUserName']='" + username + "'] and ";
            }
            if (username.Equals(""))
            {
                StatusLabel.Text = "Username must be '*' or filled out.";
                return "";
            }
            string time = textBox_TimeInPast.Text;
            if (!time.Equals(""))
            {
                int hours;
                bool parsed = Int32.TryParse(time, out hours);
                if (parsed)
                {
                    TimeSpan QueryTime = TimeSpan.FromHours(hours);
                    username_time = username_time + "*/System/TimeCreated[timediff(@SystemTime) <= '" + QueryTime.TotalMilliseconds.ToString() + "'] and ";
                }
                else
                {
                    StatusLabel.Text = "Hours must be integer.";
                    return "";
                }
            }

            string evt_4771 = "*/System[EventID=4771] and */EventData[Data[@Name='Status']='0x18']";
            string evt_4776 = "*/System[EventID=4776] and */EventData[Data[@Name='Status']='C000006A']";
            //string evt_4624 = "*/System[EventID=4624]";
            //string evt_4740 = "*/System[EventID=4740]";
            string[] eventIDs = { evt_4771, evt_4776 };
            string query = "";
            foreach(string id_str in eventIDs)
            {
                query = query + username_time + id_str + " or ";
            }
            return query.Substring(0, (query.Length - 4));
        }


        private EventLogReader create_logReader(string query, string computername)
        {
            EventLogSession session = new EventLogSession(computername);
            EventLogQuery eventsQuery = new EventLogQuery("Security", PathType.LogName, query);
            //EventLogSession session = new EventLogSession("SKYNET");
            //EventLogQuery eventsQuery = new EventLogQuery(computername, PathType.FilePath, query);
            eventsQuery.Session = session;

            EventLogReader logReader = null;
            try
            {
                logReader = new EventLogReader(eventsQuery);
            }
            catch (Exception ex)
            {
                // PASS
            }
            return logReader;
        }


        private List<Dictionary<string, string>> ParseEventLog(EventLogReader logReader, string DCNameString)
        {
            List<Dictionary<string, string>> evt_list = new List<Dictionary<string, string>>();

            for (EventRecord eventInstance = logReader.ReadEvent();
                    eventInstance != null;
                    eventInstance = logReader.ReadEvent())
            {
                Dictionary<string, string> evtItem_dict = new Dictionary<string, string>();
                try
                {
                    evtItem_dict.Add("EventID", eventInstance.Id.ToString());
                    evtItem_dict.Add("Level", eventInstance.Level.ToString());
                    evtItem_dict.Add("MachineName", eventInstance.MachineName.ToString());
                    evtItem_dict.Add("Opcode", eventInstance.Opcode.ToString());
                    evtItem_dict.Add("ProcessId", eventInstance.ProcessId.ToString());
                    evtItem_dict.Add("ProviderId", eventInstance.ProviderId.ToString());
                    evtItem_dict.Add("Qualifiers", eventInstance.Qualifiers.ToString());
                    evtItem_dict.Add("RecordId", eventInstance.RecordId.ToString());
                    evtItem_dict.Add("RelatedActivityId", eventInstance.RelatedActivityId.ToString());
                    evtItem_dict.Add("Task", eventInstance.Task.ToString());
                    evtItem_dict.Add("ThreadId", eventInstance.ThreadId.ToString());
                    evtItem_dict.Add("TimeCreated", eventInstance.TimeCreated.ToString());
                    evtItem_dict.Add("Version", eventInstance.Version.ToString());
                    evtItem_dict.Add("LogName", eventInstance.LogName.ToString());
                    evtItem_dict.Add("QueryComputerName", DCNameString);
                    //evtItem_dict.Add("LevelDisplayName", eventInstance.LevelDisplayName.ToString()); // Takes too long
                    //evtItem_dict.Add("OpcodeDisplayName", eventInstance.OpcodeDisplayName.ToString()); // Takes too long
                    //evtItem_dict.Add("TaskDisplayName", eventInstance.TaskDisplayName.ToString()); // Takes too long
                    //evtItem_dict.Add("UserId", eventInstance.UserId.ToString()); // Fails on many logs

                    try
                    {
                        XDocument evtxml = XDocument.Parse(eventInstance.ToXml());
                        XNamespace ns = "http://schemas.microsoft.com/win/2004/08/events/event";

                        foreach (var node in evtxml.Descendants(ns + "Data"))
                        {
                            if (!evtItem_dict.Keys.Contains((string)node.Attribute("Name")))
                            {
                                evtItem_dict.Add((string)node.Attribute("Name"), node.Value.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // PASS
                    }
                }
                catch(Exception ex)
                {
                    // PASS
                }
                evt_list.Add(evtItem_dict);
            }
            return evt_list;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reDiscover_Button_Click(object sender, EventArgs e)
        {
            this.populatedDomains.Clear();
            this.DC_TreeView.Nodes.Clear();
            this.get_Domains_Event();
        }

        private void addRemoveColumnsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Popup_ColumnPicker();
        }
    }
}
