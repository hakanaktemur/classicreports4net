using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport.Xps
{
	public class XpsStream
	{
		string _path;
		
		public XpsStream(string path)
		{
			_path = path;
		}

		public FixedDocumentSequence Read()
		{
			XpsDocument xpsDoc = new XpsDocument(_path, FileAccess.Read);
			FixedDocumentSequence docSequence = xpsDoc.GetFixedDocumentSequence();
			xpsDoc.Close();
			return docSequence;
		}
		
		public void Write(FixedDocumentSequence document)
		{
			// create a XpsDocument object
			XpsDocument xpsDoc = new XpsDocument(_path, FileAccess.Write);
			// get the XpsDocumentWriter for the XpsDocument object
			XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
			// write the FixedDocumentSequence object
			writer.Write(document);
			// close the XpsDocument
			xpsDoc.Close();
		}

		public  void Write(FixedDocument document)
		{
			Write(SequenceBuilder.Instance(document).GetResult());
		}
	}
	
	
	public class XpsService
	{
		FontFamily FONTFAMILY = new FontFamily("Courier New");
		ClassicReportDocument _report;
		int DPI = 96;
		FixedDocument fixedDocument = new FixedDocument();

        public XpsService()
        {
        }	

		public XpsService(ClassicReportDocument report)
		{
			_report = report;
		}

        public FixedDocumentSequence DocumentSequence
        {
        	get { return SequenceBuilder.Instance(fixedDocument).GetResult(); }
        }
        
        public void Populate()
		{
			// add pages to the FixedDocument object
			for (int i = 0; i < _report.Count; i++)
			{
				(fixedDocument as IAddChild).AddChild(BuildPageContent(_report[i]));
			}
		}
		
		void AddPage(ClassicReportPage page)
		{
			(fixedDocument as IAddChild).AddChild(BuildPageContent(page));
		}
		
		internal PageContent BuildPageContent(ClassicReportPage page)
		{
			PageContent content = new PageContent();
			content.BeginInit();
			(content as IAddChild).AddChild(BuildPage(page));
			content.EndInit();
			return content;
		}

		internal FixedPage BuildPage(ClassicReportPage page)
		{
			FixedPage fpage = new FixedPage();
			fpage.Height = (_report.PaperHeight * DPI) / 100;
			fpage.Width = (_report.PaperWidth * DPI) / 100;
			(fpage as IAddChild).AddChild(BuildCanvas(page));
			return fpage;
		}

		internal Canvas BuildCanvas(ClassicReportPage page)
		{
			Canvas canvas = new Canvas();
			double leftMargin = 10;
			double topMargin = 25;
			double yPos = topMargin;
			double xPos = leftMargin;
			Size size = GetFontSize(_report.Cpi);
			StringReader reader = new StringReader(page.ToString());
			string row = reader.ReadLine();
			while (row != null)
			{
				canvas.Children.Add(BuildText(row, yPos, xPos, size.Width));
				yPos += size.Height;
				row = reader.ReadLine();
			}
			reader.Close();
			return canvas;
		}

		UIElement BuildText(string content, double top, double left, double fontSize)
		{
			Label label = new Label();
			label.Content = content;
			label.FontFamily = FONTFAMILY;
			label.FontSize = fontSize;
			Canvas.SetTop(label, top);
			Canvas.SetLeft(label, left);
			return label;
		}

		Size GetFontSize(CPIEnum cpi)
		{
			switch (cpi)
			{
				case CPIEnum._10cpi:
					return new Size(16, 15.2);
				case CPIEnum._12cpi:
					return new Size(13.5, 15.2);
				case CPIEnum._15cpi:
					return new Size(10.8, 15.2);
				case CPIEnum._17cpi:
					return new Size(9.55, 15.2);
				case CPIEnum._20cpi:
					return new Size(8.15, 15.2);
			}
			return new Size(16, 15.2);
		}
	}
	
	class SequenceBuilder
	{
		FixedDocument _document;
		
		public static SequenceBuilder Instance(FixedDocument document)
		{
			return new SequenceBuilder(document);
		}
		
		private SequenceBuilder(FixedDocument document)
		{
			_document = document;
		}
		
		public FixedDocumentSequence GetResult()
		{
			// wrap the FixedDocument object in a DocumentReference object
			DocumentReference docRef = new DocumentReference();
			docRef.BeginInit();
			docRef.SetDocument(_document);
			docRef.EndInit();
			// add the DocumentReference object above to a FixedDocumentSequence object
			FixedDocumentSequence docSeq = new FixedDocumentSequence();
			(docSeq as IAddChild).AddChild(docRef);
			// return the FixedDocumentSequence object
			return docSeq;
		}
	}
}

