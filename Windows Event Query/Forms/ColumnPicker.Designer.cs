namespace Event_Query.Forms
{
    partial class ColumnPicker
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
            this.DataColumns = new System.Windows.Forms.GroupBox();
            this.shownColumns_statusLabel = new System.Windows.Forms.Label();
            this.hiddenColumns_statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HiddenColumns = new System.Windows.Forms.ListBox();
            this.remove_Button = new System.Windows.Forms.Button();
            this.add_Button = new System.Windows.Forms.Button();
            this.ShownColumns = new System.Windows.Forms.ListBox();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.okay_Button = new System.Windows.Forms.Button();
            this.DataColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataColumns
            // 
            this.DataColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataColumns.Controls.Add(this.shownColumns_statusLabel);
            this.DataColumns.Controls.Add(this.hiddenColumns_statusLabel);
            this.DataColumns.Controls.Add(this.label2);
            this.DataColumns.Controls.Add(this.label1);
            this.DataColumns.Controls.Add(this.HiddenColumns);
            this.DataColumns.Controls.Add(this.remove_Button);
            this.DataColumns.Controls.Add(this.add_Button);
            this.DataColumns.Controls.Add(this.ShownColumns);
            this.DataColumns.Location = new System.Drawing.Point(1, 3);
            this.DataColumns.Name = "DataColumns";
            this.DataColumns.Size = new System.Drawing.Size(427, 229);
            this.DataColumns.TabIndex = 8;
            this.DataColumns.TabStop = false;
            this.DataColumns.Text = "Data Columns";
            // 
            // shownColumns_statusLabel
            // 
            this.shownColumns_statusLabel.AutoSize = true;
            this.shownColumns_statusLabel.Location = new System.Drawing.Point(267, 208);
            this.shownColumns_statusLabel.Name = "shownColumns_statusLabel";
            this.shownColumns_statusLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.shownColumns_statusLabel.Size = new System.Drawing.Size(19, 13);
            this.shownColumns_statusLabel.TabIndex = 8;
            this.shownColumns_statusLabel.Text = "__";
            // 
            // hiddenColumns_statusLabel
            // 
            this.hiddenColumns_statusLabel.AutoSize = true;
            this.hiddenColumns_statusLabel.Location = new System.Drawing.Point(14, 208);
            this.hiddenColumns_statusLabel.Name = "hiddenColumns_statusLabel";
            this.hiddenColumns_statusLabel.Size = new System.Drawing.Size(19, 13);
            this.hiddenColumns_statusLabel.TabIndex = 7;
            this.hiddenColumns_statusLabel.Text = "__";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Active:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hidden:";
            // 
            // HiddenColumns
            // 
            this.HiddenColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.HiddenColumns.FormattingEnabled = true;
            this.HiddenColumns.Location = new System.Drawing.Point(5, 32);
            this.HiddenColumns.Name = "HiddenColumns";
            this.HiddenColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.HiddenColumns.Size = new System.Drawing.Size(165, 173);
            this.HiddenColumns.Sorted = true;
            this.HiddenColumns.TabIndex = 3;
            // 
            // remove_Button
            // 
            this.remove_Button.Location = new System.Drawing.Point(176, 109);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Size = new System.Drawing.Size(70, 23);
            this.remove_Button.TabIndex = 4;
            this.remove_Button.Text = "<< Remove";
            this.remove_Button.UseVisualStyleBackColor = true;
            this.remove_Button.Click += new System.EventHandler(this.remove_Button_Click);
            // 
            // add_Button
            // 
            this.add_Button.Location = new System.Drawing.Point(176, 80);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(70, 23);
            this.add_Button.TabIndex = 2;
            this.add_Button.Text = "Add >>";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Click += new System.EventHandler(this.add_Button_Click);
            // 
            // ShownColumns
            // 
            this.ShownColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ShownColumns.FormattingEnabled = true;
            this.ShownColumns.Location = new System.Drawing.Point(252, 32);
            this.ShownColumns.Name = "ShownColumns";
            this.ShownColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ShownColumns.Size = new System.Drawing.Size(167, 173);
            this.ShownColumns.TabIndex = 0;
            // 
            // cancel_Button
            // 
            this.cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_Button.Location = new System.Drawing.Point(269, 234);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.cancel_Button.TabIndex = 10;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.cancel_Button_Click);
            // 
            // okay_Button
            // 
            this.okay_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okay_Button.Location = new System.Drawing.Point(350, 234);
            this.okay_Button.Name = "okay_Button";
            this.okay_Button.Size = new System.Drawing.Size(75, 23);
            this.okay_Button.TabIndex = 9;
            this.okay_Button.Text = "Okay";
            this.okay_Button.UseVisualStyleBackColor = true;
            this.okay_Button.Click += new System.EventHandler(this.okay_Button_Click);
            // 
            // ColumnPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 261);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.okay_Button);
            this.Controls.Add(this.DataColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ColumnPicker";
            this.Text = "ColumnPicker";
            this.DataColumns.ResumeLayout(false);
            this.DataColumns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DataColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox HiddenColumns;
        private System.Windows.Forms.Button remove_Button;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.ListBox ShownColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.Button okay_Button;
        private System.Windows.Forms.Label hiddenColumns_statusLabel;
        private System.Windows.Forms.Label shownColumns_statusLabel;

    }
}