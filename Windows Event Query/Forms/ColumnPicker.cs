using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Event_Query.Forms
{
    public partial class ColumnPicker : Form
    {
        // Return object that will contain a list of all the columns in ShownColumns listbox.
        public List<string> shownColumns = new List<string>();

        public ColumnPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds columnHeaders list to ShownColumns and starts thread to 
        /// add headers found in master_list into HiddenColumns.
        /// </summary>
        /// <param name="columnHeaders"></param>
        /// <param name="master_list"></param>
        public void ShowDialog(ref List<string> columnHeaders, 
                               ref List<Dictionary<string, string>> master_list)
        {
            // Add headers to ShownColumns listbox.
            shownColumns_statusLabel.Text = "Adding Columns";
            foreach (string header in columnHeaders)
            {
                ShownColumns.Items.Add(header);
            }
            shownColumns_statusLabel.Text = "";

            // Create reference objects to pass into thread.
            List<Dictionary<string, string>> m_list = new List<Dictionary<string, string>>(master_list);
            List<string> c_headers = new List<string>(columnHeaders);
            // Start discover_HiddenColumns to populate HiddenColumns listbox.
            hiddenColumns_statusLabel.Text = "Discovering Hidden Columns...";
            Thread t = new Thread(() => discover_HiddenColumns(m_list, c_headers));
            t.IsBackground = true;
            t.Start();

            // Display form.
            this.ShowDialog();
        }


        /// <summary>
        /// Updates HiddenColumns with new keys found in the MasterList.
        /// </summary>
        /// <param name="m_list"></param>
        /// <param name="c_headers"></param>
        private void discover_HiddenColumns(List<Dictionary<string, string>> m_list, List<string> c_headers)
        {
            // Iterate through m_list and search keys for new header names.
            foreach (Dictionary<string, string> entry in m_list)
            {
                foreach (string key in entry.Keys)
                {
                    if (!c_headers.Contains(key))
                    {
                        // Update Column list with new header.
                        c_headers.Add(key);
                        // Add header to HiddenColumns listbox.
                        addHeaderFromThread(key);
                    }
                }
            }
            // Magic string to update hiddenColumns_statusLabel.
            addHeaderFromThread("Discovering Hidden Columns...");
        }


        // Delegate for addHeaderFromThread method.
        private delegate void HeaderStringDelegate(string value);
        /// <summary>
        /// Invokes Thread back into ColumnPicker and adds header to HiddenColumns listbox.
        /// </summary>
        /// <param name="header"></param>
        private void addHeaderFromThread(string header)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new HeaderStringDelegate(addHeaderFromThread), new object[] { header });
                return;
            }
            // If match magic string update hiddenColumns_statusLabel.
            if (header.Equals("Discovering Hidden Columns..."))
            {
                hiddenColumns_statusLabel.Text = "";
            }
            // Else add header to HiddenColumns listbox.
            else
            {
                HiddenColumns.Items.Add(header);
            }
        }

        /// <summary>
        /// Moves items from HiddenColumns to ShownColumns and removes them from
        ///  HiddenColumns listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Button_Click(object sender, EventArgs e)
        {
            if (HiddenColumns.SelectedItems != null)
            {
                foreach (string sel_item in HiddenColumns.SelectedItems)
                {
                    ShownColumns.Items.Add(sel_item);
                }

                List<string> items_to_move = new List<string>();
                foreach (string item in HiddenColumns.SelectedItems)
                {
                    items_to_move.Add(item);
                }
                foreach (string sel_item in items_to_move)
                {
                    HiddenColumns.Items.Remove(sel_item);
                }
                
            }
        }

        /// <summary>
        /// Moves items from ShownColumns to HiddenColumns and removes them from
        /// ShownColumns listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remove_Button_Click(object sender, EventArgs e)
        {
            if (ShownColumns.SelectedItem != null)
            {
                foreach (string sel_item in ShownColumns.SelectedItems)
                {
                    if (sel_item != "EventID" &&
                        sel_item != "Count")
                    {
                        HiddenColumns.Items.Add(sel_item);
                    }
                }

                List<string> items_to_move = new List<string>();
                foreach (string item in ShownColumns.SelectedItems)
                {
                    items_to_move.Add(item);
                }
                foreach (string sel_item in items_to_move)
                {
                    if (sel_item != "EventID" &&
                        sel_item != "Count")
                    {
                        ShownColumns.Items.Remove(sel_item);
                    }
                }
            }
        }

        /// <summary>
        /// Closes the popup on cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sets DialogResult.OK and populates this.shownColumns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okay_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            foreach (string shown_item in ShownColumns.Items)
            {
                this.shownColumns.Add(shown_item);
            }
            this.Close();
        }
    }
}
