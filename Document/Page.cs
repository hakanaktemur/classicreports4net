/*
 * Author: Jason D. Jimenez
 * Date  : 5/30/2004
 * Time  : 9:10 AM
 */

using System;
using System.Collections.Generic;
using JasonJimenez.ClassicReport.Common;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport
{
	class ClassicReportPage : IPage
	{
		ClassicReportDocument _document;
		
		List<ClassicReportPageItem> _items;
		int _rowIndex;
		int _pageIndex;
		bool _hasFooter = false;

		public ClassicReportPage(ClassicReportDocument document)
		{
			_items = new List<ClassicReportPageItem>();
			_document = document;
			_pageIndex = document.Count;
			_rowIndex = 0;
		}

		~ClassicReportPage()
		{
			_items.Clear();
			_items = null;
		}

		public bool hasFooter
		{
			get { return _hasFooter; }
			set { _hasFooter = value; }
		}

		public ClassicReportDocument Document 
		{
			get { return _document; }
		}


		public ClassicReportPageItem this[int index]
		{
			get
			{
				return _items[index];
			}
		}
		
		public int CurrentRow
		{
			get	{ return _rowIndex; }
		}
		
		public int PageNo
		{
			get { return _pageIndex+1; }
		}
		
		public void Write(BaseWidget widget,int col)
		{
			ClassicReportPageItem item = new ClassicReportPageItem(this);
			item.IsBold = widget.IsBold;
			item.IsItalic = widget.IsItalic;
			item.IsUnderline = widget.IsUnderline;
			item.Col= col;
			item.Text = widget.Value;
			_items.Add(item);
		}

		public void Write(BaseWidget widget, int col, AlignmentEnum align)
		{
			ClassicReportPageItem item = new ClassicReportPageItem(this);
			item.IsBold = widget.IsBold;
			item.IsItalic = widget.IsItalic;
			item.IsUnderline = widget.IsUnderline;
			item.Align = align;
			item.Col= col;
			item.Text = widget.Value;
			_items.Add(item);
		}

		public void Write(BaseWidget widget, JustifyEnum justify)
		{
			ClassicReportPageItem item = new ClassicReportPageItem(this);
			item.IsBold = widget.IsBold;
			item.IsItalic = widget.IsItalic;
			item.IsUnderline = widget.IsUnderline;
			item.Justify = justify;
			item.Text = widget.Value;
			_items.Add(item);
		}

		public void WriteLine()
		{
			_rowIndex++;
		}

		public IEnumerable<ClassicReportPageItem> GetItems(int row)
		{
			List<ClassicReportPageItem> items =
				_items.FindAll(
					delegate(ClassicReportPageItem pi)
					{
						return pi.Row == row;
					});
            items.Sort(
                delegate(ClassicReportPageItem x, ClassicReportPageItem y)
                {
                    return x.Offset - y.Offset;
                });
			foreach (ClassicReportPageItem item in items)
			{
				item.Parse(this);
				yield return item;
			}
		}
		
		public string ToString(int row)
		{
			StringBuffer buffer = new StringBuffer();
			foreach(ClassicReportPageItem item in GetItems(row))
			{
				buffer.Insert(item);
			}
			return buffer.ToString();
		}
		
		public override string ToString()
		{
			string sb = "";
			StringBuffer buffer = new StringBuffer();
			
			for (int i=0; i<_document.PageHeight; i++)
			{
                buffer.Clear();
                foreach (ClassicReportPageItem item in GetItems(i))
                {
                    buffer.Insert(item);
                }
                sb += buffer.ToString();
                //sb += string.Format("*** LINE {0:00}", i);
                if (i < _document.PageHeight - 1)
                    sb += "\n";
			}
            return sb;		// return the page contents as a string
		}		
	}
	
	class StringBuffer
	{
		char[] _buffer;
		int _size;

		public StringBuffer()
		{
			_size=512;
			_buffer=new char[_size];
			this.Clear();
		}
		
		public StringBuffer(int size)
		{
			_buffer = new char[size];
			_size = size;
			this.Clear();			
		}
		
		public void Clear()
		{
			for (int i=0; i<_size; i++)
				_buffer[i] = ' ';
		}
		
		public void Insert(ClassicReportPageItem item)
		{
			CopyString(item.Value,item.Offset);
		}
	
		public override string ToString()
		{
			string s = "";
			for (int i=0; i<_size; ++i)
				s += _buffer[i];	
			string sb = s.TrimEnd(' ');
			return sb;
		}

		private void CopyString(string src,int offset)
		{
			for(int i=0; i<src.Length; i++)
				_buffer[i+offset] = src[i];
		}
		
	}
}
