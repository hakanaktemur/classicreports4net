/*
 * Author: Jason D. Jimenez
 * Date  : 5/1/2007 5:10AM
 * 
 */

using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows;

using JasonJimenez.ClassicReport.Xps;

namespace JasonJimenez.ClassicReport
{
	/// <summary>
	/// Description of XpsPreviewControl.
	/// </summary>
	public partial class ZoomPreviewControl : System.Windows.Forms.UserControl
	{
		ClassicReportDocument _document;
		ElementHost _host;
		XpsService xps;
		ScaleTransform _scale;
		int _index = 0;

		public ZoomPreviewControl()
		{
			InitializeComponent();
			_host = new ElementHost();
			_scale = new ScaleTransform();
			_host.Dock = System.Windows.Forms.DockStyle.Fill;
			Controls.Add(_host);
			_host.BringToFront();
		}

		[Browsable(false)]
		public ClassicReportDocument Document
		{
			get { return _document; }
			set
			{
				_document = value;
				if ( value != null )
				{
					xps = new XpsService(value);
					pageCountLabel.Text = _document.Count.ToString();
					RefreshPage();
				}
			}
		}
		
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			if (DesignMode) return;
			if (_document == null) return;
			nextToolStripButton.Enabled = _index < _document.Count - 1;
			prevToolStripButton.Enabled = _index > 0;
		}

		void RefreshPage()
		{
			base.Refresh();
			if ( xps == null ) return;
			//_canvas.Background = Brushes.LightBlue;			
			FixedPage page = xps.BuildPage(_document[_index]);
			page.RenderTransform = _scale;
			_scale.ScaleX = _host.Width / page.Width;
            _scale.ScaleY = 1;
            _host.Child = page;
			this.currentPageTextBox.Text = (_index + 1).ToString();
		}

		void nextToolStripButton_Click(object sender, EventArgs e)
		{
			if ( _document==null ) return;
			if ( _index < _document.Count-1 )
			{
				_index++;
				RefreshPage();
			}
		}
		
		void prevToolStripButton_Click(object sender, EventArgs e)
		{
			if ( _document == null ) return;
			if ( _index > 0 )
			{
				_index--;
				RefreshPage();
			}

		}

		void CurrentPageTextBoxKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == System.Windows.Forms.Keys.Enter )
			{
				_host.Focus();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}

		void CurrentPageTextBoxValidating(object sender, CancelEventArgs e)
		{
			int result;
			if ( int.TryParse(this.currentPageTextBox.Text, out result) )
			{
				if (result > 0 && result <= _document.Count)
				{
					_index = result - 1;
					RefreshPage();
					return;
				}
			}
			currentPageTextBox.Text = (_index + 1).ToString();
		}

		void CurrentPageTextBoxClick(object sender, EventArgs e)
		{
			currentPageTextBox.SelectAll();
		}
	}
}
