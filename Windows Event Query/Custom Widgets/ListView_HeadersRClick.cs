using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
// Adds right click events to the column headers.

namespace Event_Query.Custom_Widgets
{
    public partial class ListView_HeadersRClick : ListView
    {
        public ListView_HeadersRClick()
        {
        }


        public delegate void ColumnContextMenuHandler(object sender, ColumnHeader columnHeader);
        public event ColumnContextMenuHandler ColumnContextMenuClicked;

        bool _OnItemsArea = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _OnItemsArea = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _OnItemsArea = false;
        }

        const int WM_CONTEXTMENU = 0x7b;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_CONTEXTMENU)
            {
                Console.WriteLine(m);
                if (!_OnItemsArea)
                {
                    Point p = base.PointToClient(MousePosition);
                    int totalWidth = this.Width;
                    int totalHeight = 25;
                    if (p.X < totalWidth &&
                        p.Y < totalHeight)
                    {
                        if (ColumnContextMenuClicked != null)
                        {
                            ColumnContextMenuClicked(this, base.Columns[0]);
                        }
                    }
                }
            }
        }
    }
}
