using System;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common
{
	class ReportDesignerEventArgs : EventArgs
	{
		BaseWidget[] _widget;
		int _count = 0;

		public ReportDesignerEventArgs()
		{
		}

		public ReportDesignerEventArgs(BaseWidget[] widget, int count)
		{
			_widget = widget;
			_count = count;
		}

		public BaseWidget[] Widget
		{
			get { return _widget; }
		}

		public int Count
		{
			get { return _count; }
		}
	}

	delegate void ReportDesignerEventHandler(object sender, ReportDesignerEventArgs e);

}
