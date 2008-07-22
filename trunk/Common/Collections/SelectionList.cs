using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common.Collections
{
    class SelectionList : List<BaseWidget>
    {
        public Rectangle GetRectangle()
        {
            int x1 = 9999;
            int y1 = 9999;
            int x2 = 0;
            int y2 = 0;
            int x;
            int y;
            foreach (BaseWidget widget in this)
            {
                if (x1 > widget.Col)
                {
                    x1 = widget.Col;
                }
                if (y1 > widget.Row)
                {
                    y1 = widget.Row;
                }
                x = widget.Col + widget.Width - 1;
                y = widget.Row + widget.Height - 1;
                if (x2 < x)
                {
                    x2 = x;
                }
                if (y2 < y)
                {
                    y2 = y;
                }
            }
            return new Rectangle(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
        }

        public bool Hit(Point p)
        {
            bool ok = false; ;
            foreach (BaseWidget widget in this)
            {
                if (widget.GetRectangle().Contains(p))
                {
                    ok = true;
                    break;
                }
            }
            return ok;
        }

        public new void Clear()
        {
            foreach (BaseWidget control in this)
            {
                control.IsSelected = false;
            }
            base.Clear();
        }
    }
}
