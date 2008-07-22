/*
 * Author: Jason D. Jimenez
 * Date  : 5/30/2004
 * Time  : 9:13 AM
 * 
 */

using System;
using System.Text;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport
{
	class ClassicReportPageItem
	{
        private ClassicReportPage _page = null;
		private int _col = 0;
		private int _row = 0;
		private int _offset = 0;
		private string _text = null;
		private string _value = null;
		private AlignmentEnum _align = AlignmentEnum.AlignLeft;
		private JustifyEnum _justify = JustifyEnum.JustifyNone;
        bool bold;
        bool underline;
        bool italic;

		public ClassicReportPageItem(ClassicReportPage page)
		{
            _page = page;
            _row = page.CurrentRow;
		}

        ~ClassicReportPageItem()
        {
            _page = null;            
        }

        public bool IsBold
        {
            get { return bold; }
            set { bold = value; }
        }

        public bool IsUnderline
        {
            get { return underline; }
            set { underline = value; }
        }

        public bool IsItalic
        {
            get { return italic; }
            set { italic = value; }
        }

        public AlignmentEnum Align
        {
            get { return _align; }
            set { _align = value; }
        }

		public int Col
		{
			get{return _col;}
			set{_col = value;}
		}
		
		
		public JustifyEnum Justify
		{
			get{return _justify;}
			set{_justify = value;}
		}
			
		public int Offset
		{
			get{return _offset;}
		}
		
		public int Row
		{
			get{return _row;}
		}
					
		public string Text
		{
			get{return _text;}
			set{_text = value;}
		}
		
			
		public string Value
		{
			get{return _value;}
		}
		
		
		public void Parse(ClassicReportPage page)
		{
			StringBuilder sb = new StringBuilder();
			
			if (_text == "%PageEx")
			{
				sb.AppendFormat("Page {0} of {1}",page.PageNo, page.Document.Count);	
			}
			else if (_text == "%Page")
			{
				sb.AppendFormat("Page {0}",page.PageNo);	
			}
			else
			{
				sb.Append(_text);
			}
			_value = sb.ToString();
			_offset = GetOffset(page.Document.PageWidth);
		}
		
		private int GetOffset(int pageWidth)
		{
			int retVal=0;
			
			if (_justify == JustifyEnum.JustifyNone)
			{
				switch(_align)
				{
					case AlignmentEnum.AlignLeft:
						retVal = _col;
						break;
					case AlignmentEnum.AlignRight: 
						retVal = _col-_value.Length;
						break;
				}
			}
			else
			{
				switch(_justify)
				{
					case JustifyEnum.JustifyLeft: 
						retVal = 0;
						break;
					case JustifyEnum.JustifyRight:
						retVal = pageWidth-_value.Length;
						break;
					case JustifyEnum.JustifyCenter: 
						retVal = (pageWidth-_value.Length)/2;
						break;
				}
			}
			return retVal;
		}
	}
}
