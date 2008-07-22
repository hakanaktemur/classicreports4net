using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using JasonJimenez.ClassicReport.Printing;

namespace JasonJimenez.ClassicReport
{
	/// <summary>
	/// A control for previewing and printing live reports.
	/// </summary>
	[ToolboxItem(true)]
	public partial class ReportPreviewControl : UserControl
	{
		ToolStripMenuItem prevZoom = null;
		ClassicReportDocument document;
		bool isWindows = false;
		
		int fromPage;
		int toPage;
		
		/// <summary>
		/// Initializer for the control.
		/// </summary>
		public ReportPreviewControl()
		{
			InitializeComponent();
			printDocument.DefaultPageSettings.Margins.Top = 25;
			printDocument.DefaultPageSettings.Margins.Bottom = 25;
			printDocument.DefaultPageSettings.Margins.Left = 10;
			printDocument.DefaultPageSettings.Margins.Right = 10;
			fromPage = 0;
			toPage = 0;
		}

		[Browsable(false)]
		public ClassicReportDocument Document
		{
			get { return document; }
			set
			{
				document = value;
				if (document != null)
				{
					System.Drawing.Printing.PaperSize papersize = new PaperSize("Custom", document.PaperWidth, document.PaperHeight);
					printDocument.DefaultPageSettings.PaperSize = papersize;
					toPage= document.Count-1;
					this.pageCountLabel.Text = document.Count.ToString();
					this.currentPageTextBox.Text = "1";
				}
			}
		}
		
		[Category("Behavior")]
		public bool WindowsPrinting
		{
			get { return isWindows; }
			set { isWindows = value; }
		}
		
		public void PrintPages(System.Drawing.Printing.PrintRange range)
		{
			IPrinterService printer;
			if ( isWindows )
				printer = new WinPrinterService(document, printDocument.PrinterSettings.PrinterName);
			else
				printer = new PrinterService(document, printDocument.PrinterSettings.PrinterName);
			switch (range)
			{
				case System.Drawing.Printing.PrintRange.AllPages:
					printer.PrintAll();
					break;
				case System.Drawing.Printing.PrintRange.CurrentPage:
					printer.PrintRange(printPreviewControl1.StartPage, printPreviewControl1.StartPage);
					break;
				case System.Drawing.Printing.PrintRange.Selection:
					break;
				case System.Drawing.Printing.PrintRange.SomePages:
					printer.PrintRange(printDocument.PrinterSettings.FromPage, printDocument.PrinterSettings.ToPage);
					break;
				default:
					break;
			}
		}
		
		void CompilePreviewPagesEx(System.Drawing.Printing.PrintPageEventArgs e)
		{
			Application.DoEvents();
			float height = e.MarginBounds.Height / document.PageHeight;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float yPos = topMargin;
			Font printFont = FontProvider.GetFont(document.Cpi);
			ClassicReportPage page = document[fromPage];
			for (int rowIndex = 0; rowIndex < document.PageHeight; rowIndex++)
			{
				string rowString = page.ToString(rowIndex);
				rowString = rowString.Replace(' ','M');
				foreach (ClassicReportPageItem item in page.GetItems(rowIndex))
				{
					float xPos = leftMargin;
					if (item.Offset > 0)
					{
						string trailer = rowString.Substring(0,item.Offset-1);
						xPos += e.Graphics.MeasureString(trailer, printFont).Width;
					}
					FontStyle fontStyle = FontStyle.Regular;
					if (item.IsBold)
						fontStyle |= FontStyle.Bold;
					if (item.IsItalic)
						fontStyle |= FontStyle.Italic;
					if (item.IsUnderline)
						fontStyle |= FontStyle.Underline;
					Font itemFont = new Font(printFont, fontStyle);
					e.Graphics.DrawString(item.Value, itemFont, Brushes.Black, xPos, yPos);
					itemFont.Dispose();
				}
				yPos += height;
			}
			e.HasMorePages = ++fromPage <= toPage;
			printFont.Dispose();
			
		}
		
		void CompilePreviewPages(System.Drawing.Printing.PrintPageEventArgs e)
		{
			Application.DoEvents();
			Font printFont = FontProvider.GetFont(document.Cpi);
			string source = document.ToString(fromPage);
			System.IO.StringReader sr = new System.IO.StringReader(source);
			float height = e.MarginBounds.Height / document.PageHeight;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float yPos = topMargin;
			while (true)
			{
				string line = sr.ReadLine();
				if (line != null)
				{
					e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
					//yPos += (printFont.GetHeight(e.Graphics)-3);
					yPos += height;
				}
				else
				{
					break;
				}
			}
			e.HasMorePages = ++fromPage < document.Count;
			printFont.Dispose();
			sr.Close();
			sr.Dispose();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			if (DesignMode) return;
			if (document == null) return;
			int index = printPreviewControl1.StartPage;
			nextToolStripButton.Enabled = index < document.Count - 1;
			prevToolStripButton.Enabled = index > 0;
		}
		
		private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			if (this.DesignMode) return;
			if (document != null)
			{
				CompilePreviewPages(e);
			}
		}
		
		private void OnPrint(object sender, EventArgs e)
		{
			DialogResult result = printDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				PrintPages(printDialog.PrinterSettings.PrintRange);
			}
		}

		private void OnZoom(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			if (item != prevZoom)
			{
				printPreviewControl1.Zoom = double.Parse(item.Tag.ToString());
				item.Checked = true;
				if (prevZoom != null) prevZoom.Checked = false;
				prevZoom = item;
			}
		}

		private void OnFirstPage(object sender, EventArgs e)
		{
			printPreviewControl1.StartPage = 0;
		}

		private void OnLastPage(object sender, EventArgs e)
		{
			printPreviewControl1.StartPage = document.Count - 1;
		}

		private void OnPreviousPage(object sender, EventArgs e)
		{
			printPreviewControl1.StartPage--;
			int currentPage = printPreviewControl1.StartPage+1;
			this.currentPageTextBox.Text = currentPage.ToString();
		}

		private void OnNextPage(object sender, EventArgs e)
		{
			printPreviewControl1.StartPage++;
			int currentPage = printPreviewControl1.StartPage+1;
			this.currentPageTextBox.Text = currentPage.ToString();
		}


		
		void CurrentPageTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter )
			{
				printPreviewControl1.Focus();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
		}
		
		void CurrentPageTextBoxValidating(object sender, CancelEventArgs e)
		{
			int result;
			if ( int.TryParse(this.currentPageTextBox.Text, out result) )
			{
				if (result>0 && result<=document.Count)
				{
					printPreviewControl1.StartPage = result-1;
					currentPageTextBox.Text = result.ToString();
					return;
				}
			}
			result = printPreviewControl1.StartPage+1;
			currentPageTextBox.Text = result.ToString();
		}
		
		void CurrentPageTextBoxClick(object sender, EventArgs e)
		{
			currentPageTextBox.SelectAll();
		}
		
		void PrintPreviewControl1PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			int pageNo = printPreviewControl1.StartPage+1;
			if ( e.KeyCode == Keys.PageDown )
			{
				if ( pageNo < document.Count )
				{
					pageNo++;
				}
			}
			else if ( e.KeyCode == Keys.PageUp )
			{
				if ( pageNo > 1 )
				{
					pageNo--;
				}
			}
			
			currentPageTextBox.Text = pageNo.ToString();
		}
	}
}
