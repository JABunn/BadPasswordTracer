namespace Event_Query
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reDiscover_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_TargetUserName = new System.Windows.Forms.TextBox();
            this.textBox_TimeInPast = new System.Windows.Forms.TextBox();
            this.events_groupBox = new System.Windows.Forms.GroupBox();
            this.queryEvents_Button = new System.Windows.Forms.Button();
            this.clearEventView_Button = new System.Windows.Forms.Button();
            this.columnHeader_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRemoveColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoveColumnsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DC_TreeView = new Event_Query.Custom_Widgets.TreeViewNoDoubleClick(this.components);
            this.eventsListView = new Event_Query.Custom_Widgets.ListView_HeadersRClick();
            this.EventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IpAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QueryComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.events_groupBox.SuspendLayout();
            this.columnHeader_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.events_groupBox);
            this.splitContainer1.Size = new System.Drawing.Size(784, 515);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.reDiscover_Button);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textbox_TargetUserName);
            this.groupBox1.Controls.Add(this.textBox_TimeInPast);
            this.groupBox1.Controls.Add(this.DC_TreeView);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 510);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // reDiscover_Button
            // 
            this.reDiscover_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reDiscover_Button.Location = new System.Drawing.Point(138, 478);
            this.reDiscover_Button.Name = "reDiscover_Button";
            this.reDiscover_Button.Size = new System.Drawing.Size(89, 23);
            this.reDiscover_Button.TabIndex = 7;
            this.reDiscover_Button.Text = "Retry Discover";
            this.reDiscover_Button.UseVisualStyleBackColor = true;
            this.reDiscover_Button.Click += new System.EventHandler(this.reDiscover_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select DCs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TargetUserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hours.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Check in past";
            // 
            // textbox_TargetUserName
            // 
            this.textbox_TargetUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_TargetUserName.Location = new System.Drawing.Point(100, 23);
            this.textbox_TargetUserName.Name = "textbox_TargetUserName";
            this.textbox_TargetUserName.Size = new System.Drawing.Size(127, 20);
            this.textbox_TargetUserName.TabIndex = 2;
            // 
            // textBox_TimeInPast
            // 
            this.textBox_TimeInPast.Location = new System.Drawing.Point(100, 49);
            this.textBox_TimeInPast.Name = "textBox_TimeInPast";
            this.textBox_TimeInPast.Size = new System.Drawing.Size(85, 20);
            this.textBox_TimeInPast.TabIndex = 1;
            // 
            // events_groupBox
            // 
            this.events_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.events_groupBox.Controls.Add(this.queryEvents_Button);
            this.events_groupBox.Controls.Add(this.clearEventView_Button);
            this.events_groupBox.Controls.Add(this.eventsListView);
            this.events_groupBox.Location = new System.Drawing.Point(3, 3);
            this.events_groupBox.Name = "events_groupBox";
            this.events_groupBox.Size = new System.Drawing.Size(527, 507);
            this.events_groupBox.TabIndex = 0;
            this.events_groupBox.TabStop = false;
            this.events_groupBox.Text = "Events";
            // 
            // queryEvents_Button
            // 
            this.queryEvents_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.queryEvents_Button.Location = new System.Drawing.Point(446, 478);
            this.queryEvents_Button.Name = "queryEvents_Button";
            this.queryEvents_Button.Size = new System.Drawing.Size(75, 23);
            this.queryEvents_Button.TabIndex = 0;
            this.queryEvents_Button.Text = "Query";
            this.queryEvents_Button.UseVisualStyleBackColor = true;
            this.queryEvents_Button.Click += new System.EventHandler(this.queryEvents_Button_Click);
            // 
            // clearEventView_Button
            // 
            this.clearEventView_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearEventView_Button.Location = new System.Drawing.Point(365, 478);
            this.clearEventView_Button.Name = "clearEventView_Button";
            this.clearEventView_Button.Size = new System.Drawing.Size(75, 23);
            this.clearEventView_Button.TabIndex = 1;
            this.clearEventView_Button.Text = "Clear";
            this.clearEventView_Button.UseVisualStyleBackColor = true;
            this.clearEventView_Button.Click += new System.EventHandler(this.clearEventView_Button_Click);
            // 
            // columnHeader_contextMenu
            // 
            this.columnHeader_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRemoveColumnsToolStripMenuItem});
            this.columnHeader_contextMenu.Name = "columnHeader_contextMenu";
            this.columnHeader_contextMenu.Size = new System.Drawing.Size(196, 26);
            // 
            // addRemoveColumnsToolStripMenuItem
            // 
            this.addRemoveColumnsToolStripMenuItem.Name = "addRemoveColumnsToolStripMenuItem";
            this.addRemoveColumnsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addRemoveColumnsToolStripMenuItem.Text = "Add/Remove Columns";
            this.addRemoveColumnsToolStripMenuItem.Click += new System.EventHandler(this.addRemoveColumnsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRemoveColumnsToolStripMenuItem1});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // addRemoveColumnsToolStripMenuItem1
            // 
            this.addRemoveColumnsToolStripMenuItem1.Name = "addRemoveColumnsToolStripMenuItem1";
            this.addRemoveColumnsToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.addRemoveColumnsToolStripMenuItem1.Text = "Add/Remove Columns";
            this.addRemoveColumnsToolStripMenuItem1.Click += new System.EventHandler(this.addRemoveColumnsToolStripMenuItem1_Click);
            // 
            // DC_TreeView
            // 
            this.DC_TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DC_TreeView.CheckBoxes = true;
            this.DC_TreeView.Location = new System.Drawing.Point(6, 93);
            this.DC_TreeView.Name = "DC_TreeView";
            this.DC_TreeView.ShowNodeToolTips = true;
            this.DC_TreeView.Size = new System.Drawing.Size(221, 379);
            this.DC_TreeView.TabIndex = 0;
            // 
            // eventsListView
            // 
            this.eventsListView.AllowColumnReorder = true;
            this.eventsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventID,
            this.Count,
            this.TargetUserName,
            this.IpAddress,
            this.Status,
            this.QueryComputerName});
            this.eventsListView.FullRowSelect = true;
            this.eventsListView.Location = new System.Drawing.Point(6, 19);
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.Size = new System.Drawing.Size(515, 453);
            this.eventsListView.TabIndex = 0;
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.Details;
            this.eventsListView.VirtualMode = true;
            // 
            // EventID
            // 
            this.EventID.Tag = "data";
            this.EventID.Text = "EventID";
            this.EventID.Width = 52;
            // 
            // Count
            // 
            this.Count.Tag = "calc";
            this.Count.Text = "Count";
            this.Count.Width = 45;
            // 
            // TargetUserName
            // 
            this.TargetUserName.Text = "TargetUserName";
            this.TargetUserName.Width = 102;
            // 
            // IpAddress
            // 
            this.IpAddress.Text = "IpAddress";
            this.IpAddress.Width = 68;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 48;
            // 
            // QueryComputerName
            // 
            this.QueryComputerName.Text = "QueryComputerName";
            this.QueryComputerName.Width = 117;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Bad Password Tracer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.events_groupBox.ResumeLayout(false);
            this.columnHeader_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox events_groupBox;
        private Custom_Widgets.ListView_HeadersRClick eventsListView;
        private System.Windows.Forms.Button clearEventView_Button;
        private System.Windows.Forms.ColumnHeader EventID;
        private System.Windows.Forms.ColumnHeader Count;
        private System.Windows.Forms.Button queryEvents_Button;
        private System.Windows.Forms.ContextMenuStrip columnHeader_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addRemoveColumnsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader TargetUserName;
        private System.Windows.Forms.ColumnHeader IpAddress;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader QueryComputerName;
        private Custom_Widgets.TreeViewNoDoubleClick DC_TreeView;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TextBox textBox_TimeInPast;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textbox_TargetUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reDiscover_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRemoveColumnsToolStripMenuItem1;
    }
}

