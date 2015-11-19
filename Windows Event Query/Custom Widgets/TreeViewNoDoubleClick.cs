using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Event_Query.Custom_Widgets
{
    public partial class TreeViewNoDoubleClick : TreeView
    {
        const int WM_LBUTTONDBLCLK = 0x203;

        protected override void WndProc(ref Message m)
        {
            // Filter WM_LBUTTONDBLCLK
            if (m.Msg != WM_LBUTTONDBLCLK)
            {
                base.WndProc(ref m);
            }
        }

        public TreeViewNoDoubleClick()
        {
            InitializeComponent();
        }

        public TreeViewNoDoubleClick(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
