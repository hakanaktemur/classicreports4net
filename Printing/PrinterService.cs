using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows;

using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport.Printing
{
	public interface IPrinterService
	{
		void PrintAll();
		void PrintRange(int fromPage, int toPage);
	}

	public class WinPrinterService : IPrinterService
	{
		ClassicReportDocument document;
		PrintDocument pd;
		int fromPage, toPage;

		public WinPrinterService(ClassicReportDocument document)
		{
			this.document = document;
			pd = new PrintDocument();			
			pd.PrintPage += OnPrintPage;
			pd.DefaultPageSettings.Margins.Top = 25;
			pd.DefaultPageSettings.Margins.Bottom = 25;
			pd.DefaultPageSettings.Margins.Left = 10;
			pd.DefaultPageSettings.Margins.Right = 10;
			System.Drawing.Printing.PaperSize papersize = new System.Drawing.Printing.PaperSize("Custom", document.PaperWidth, document.PaperHeight);
			pd.DefaultPageSettings.PaperSize = papersize;		
			pd.DocumentName = document.DocumentName;		
		}

		public WinPrinterService(ClassicReportDocument document, string printerName)
			: this(document)
		{
			pd.PrinterSettings.PrinterName = printerName;
		}
		
		public void PrintAll()
		{
			SendToPrinter(1, document.Count);
		}

		public void PrintRange(int fromPage, int toPage)
		{
			SendToPrinter(fromPage, toPage);
		}
		
		void SendToPrinter(int fromPage, int toPage)
		{
			this.fromPage = fromPage;
			this.toPage = toPage;
			pd.Print();
		}
		
		private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			System.Windows.Forms.Application.DoEvents();
			float height = e.MarginBounds.Height / document.PageHeight;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float yPos = topMargin;
			Font printFont = FontProvider.GetFont(document.Cpi);
			ClassicReportPage page = document[fromPage-1];
			for (int rowIndex = 0; rowIndex < document.PageHeight; rowIndex++)
			{
				foreach (ClassicReportPageItem item in page.GetItems(rowIndex))
				{
					float xPos = leftMargin;
					if (item.Offset > 0)
					{
						xPos += e.Graphics.MeasureString(Utility.RepeatChar('a',item.Offset-1), printFont).Width;
					}
					System.Drawing.FontStyle fontStyle = System.Drawing.FontStyle.Regular;
					if (item.IsBold)
						fontStyle |= System.Drawing.FontStyle.Bold;
					if (item.IsItalic)
						fontStyle |= System.Drawing.FontStyle.Italic;
					if (item.IsUnderline)
						fontStyle |= System.Drawing.FontStyle.Underline;
					Font itemFont = new Font(printFont, fontStyle);
                    e.Graphics.DrawString(item.Value, itemFont, Brushes.Black, xPos, yPos);
					itemFont.Dispose();
				}
				yPos += height;
			}
			e.HasMorePages = ++fromPage <= toPage;
			printFont.Dispose();
		}
	}
	
	
	public class PrinterService : IPrinterService
	{
		string printerName;
		ClassicReportDocument document;

		public PrinterService(ClassicReportDocument document)
		{
			this.document = document;
		}

		public PrinterService(ClassicReportDocument document, string printerName)
		{
			this.document = document;
			this.printerName = printerName;
		}

		public void PrintAll()
		{
			SendToPrinter(1, document.Count);
		}

		public void PrintRange(int fromPage, int toPage)
		{
			SendToPrinter(fromPage, toPage);
		}

		void SendToPrinter(int fromPage, int toPage)
		{
			bool firstPass = true;
			DOCINFO di = new DOCINFO();
			IntPtr ptr = new IntPtr();
			di.pDocName = document.DocumentName;
			di.pDataType = "RAW";
			PrintDirect.OpenPrinter(printerName, ref ptr, 0);
			PrintDirect.StartDocPrinter(ptr, 1, ref di);
			for (int i = fromPage - 1; i < toPage; i++)
			{
				PrintDirect.StartPagePrinter(ptr);
				if (firstPass)
				{
					Print(ptr, PageSetting());
					firstPass = false;
				}
				Print(ptr, document.ToString(i));
				Print(ptr, "\f");
				PrintDirect.EndPagePrinter(ptr);
			}
			//Print(ptr, PageSetting());
			//Print(ptr, "****hello world\n");
			//Print(ptr, "****hello world\f");
			PrintDirect.EndDocPrinter(ptr);
			PrintDirect.ClosePrinter(ptr);
		}

		void Print(IntPtr ptr, string buf)
		{
			int count = 0;
			PrintDirect.WritePrinter(ptr, buf, buf.Length, ref count);
		}
		
		string PageSetting()
		{
			//string retVal = Convert.ToChar(27) + "@";
			string retVal = Convert.ToChar(27) + "C" + Convert.ToChar(0) +
				Convert.ToChar(document.PaperHeight / 100);
			switch (document.Cpi)
			{
				case CPIEnum.Default:
					break;
				case CPIEnum._10cpi:
					retVal += Convert.ToChar(27) + "!" + Convert.ToChar(0);
					//retVal += Convert.ToChar(27) + "P";
					//retVal += Convert.ToChar(27) + "w" + Convert.ToChar(0);
					break;
				case CPIEnum._12cpi:
					retVal += Convert.ToChar(27) + "!" + Convert.ToChar(1);
					//retVal += Convert.ToChar(27) + "M";
					//retVal += Convert.ToChar(27) + "w" + Convert.ToChar(1);
					break;
				case CPIEnum._15cpi:
					//retVal += Convert.ToChar(27) + "g";
					retVal += Convert.ToChar(27) + "w" + Convert.ToChar(2);
					break;
				case CPIEnum._17cpi:
					retVal += Convert.ToChar(27) + "!" + Convert.ToChar(4);
					//retVal += Convert.ToChar(27) + "w" + Convert.ToChar(3);
					break;
				case CPIEnum._20cpi:
					retVal += Convert.ToChar(27) + "!" + Convert.ToChar(5);
					break;
			}
			// set page length (lines)
			//retVal += Convert.ToChar(27) + "C" + Convert.ToChar(document.PageHeight);
			return retVal;
		}

	}
}

