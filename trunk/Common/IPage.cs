using System;
using System.Collections.Generic;
using System.Text;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common
{
	interface IPage
	{
		void WriteLine();
		void Write(BaseWidget widget, int col);
		void Write(BaseWidget widget, int col, AlignmentEnum align);
		void Write(BaseWidget widget, JustifyEnum justify);
	}
}
