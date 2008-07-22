/*
 * Author: Jason D. Jimenez
 * Date  : 2/3/2005
 * Time  : 5:14 AM
 * 
 */

using System;
using System.Collections.Generic;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport
{
	public sealed class ClassicReportDocument
	{
		List<ClassicReportPage> _pages = new List<ClassicReportPage>();
		ClassicReportPage _page;
		//ReportModel _model;
		
		int _width;
		int _height;
		string _name;
		int _paperwidth;
		int _paperheight;
		CPIEnum _cpi;
		
		internal  ClassicReportDocument(ReportModel model)
		{
			_width = model.PageWidth;
			_height = model.PageHeight; 
			_name = model.DocumentName;
			_paperwidth = model.PaperWidth;
			_paperheight = model.PaperHeight;
			_cpi = model.Cpi;
		}

		~ClassicReportDocument()
		{
			_pages.Clear();
			_pages = null;
		}
		
		public int PaperWidth
		{
			get { return _paperwidth; }
		}

		public int PaperHeight
		{
			get { return _paperheight; }
		}

		public CPIEnum Cpi
		{
			get {return _cpi;}
		}

		public string DocumentName
		{
			get {return _name;}
		}

		public int PageHeight
		{
			get {return _height;}
		}

		public int PageWidth
		{
			get {return _width;}
		}

//		public string DocumentName
//		{
//			get { return _model.DocumentName;}
//		}
		
		public int Count
		{
			get { return _pages.Count; }
		}
		
//		internal ReportModel Model
//		{
//			get { return _model; }
//		}
		
		internal ClassicReportPage this[int index]
		{
			get
			{
				if (index >= 0 && index < _pages.Count)
					return _pages[index];
				else
					return null;
			}
		}

		internal int CurrentRow
		{
			get { return _page.CurrentRow; }
		}
		
		internal ClassicReportPage CurrentPage
		{
			get { return _page; }
		}
		
		public string ToString(int pageNo)
		{
			string s = "";
			if (pageNo>=0 && pageNo<Count)
			{
				return _pages[pageNo].ToString();				
			}
			return s;
		}
		
		internal ClassicReportPage NewPage()
		{
			_page = new ClassicReportPage(this);	// store new page reference
			_pages.Add(_page);						// add the page to our list
			return _page;
		}
		
		internal void Clear()
		{
			_pages.Clear();
		}

	}
}

