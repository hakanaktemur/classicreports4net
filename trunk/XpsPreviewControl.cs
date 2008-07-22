/*
 * Author: Jason Jimenez
 * Date  : 5/7/2007 6:11PM
 * 
 */

using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using JasonJimenez.ClassicReport.Xps;

namespace JasonJimenez.ClassicReport
{	
	public partial class XpsPreviewControl : System.Windows.Forms.UserControl
	{
		ElementHost host;
		DocumentViewer viewer;
		//ClassicReportDocument doc;
		
		public XpsPreviewControl()
		{
			InitializeComponent();
			viewer = new DocumentViewer();
			host = new ElementHost();
			host.Dock = System.Windows.Forms.DockStyle.Fill;
			host.Child = viewer;
			Controls.Add(host);
		}
		
		[Browsable(false)]
		public ClassicReportDocument Document
		{
			//get { return doc; }
			set
			{
				//doc = value;
				if (value != null)
				{
					XpsService xps = new XpsService(value);
					xps.Populate();
					viewer.Document = xps.DocumentSequence;
				}
			}
		}				
	}		
}
