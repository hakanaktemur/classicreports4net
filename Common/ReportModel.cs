using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;

using JasonJimenez.ClassicReport.Common.Collections;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common
{
	class ReportModel
	{
		int _width = 80;
		int _height = 60;
		bool _showheader = true;
		bool _showfooter = true;
		bool _showsummary = false;
		string _name = "New ClassicReport";
		int _paperwidth = 850;
		int _paperheight = 1100;
		CPIEnum _cpi = CPIEnum._10cpi;

		GroupList _groups = new GroupList();
		BandList _bands = new BandList();

		public ReportModel()
		{
			_bands.Add(new Band(BandEnum.PageHeaderBand));
			_bands.Add(new Band(BandEnum.PageHeaderBand));
			_bands.Add(new Band(BandEnum.PageHeaderBand));
			_bands.Add(new Band(BandEnum.PageDetailBand));
			_bands.Add(new Band(BandEnum.PageFooterBand));
			_bands.Add(new Band(BandEnum.PageFooterBand));
			_bands.Add(new Band(BandEnum.SummaryBand));
		}

        public ReportModel(string schema)
        {
            LoadSchema(schema);
        }
		
		internal void Add(Group group)
		{
			Groups.Add(group);
			Bands.Add(group);
		}
		
		internal void Remove(Group group)
		{
			Groups.Remove(group);
			Bands.Remove(group);
		}

		public int PaperWidth
		{
			get { return _paperwidth; }
			set { _paperwidth = value; }
		}

		public int PaperHeight
		{
			get { return _paperheight; }
			set { _paperheight = value; }
		}

		[Category("Layout")]
		public CPIEnum Cpi
		{
			get {return _cpi;}
			set { _cpi = value; }
		}

		[Category("Design")]
		public string DocumentName
		{
			get {return _name;}
			set
			{
				if (value != "")
				{
					_name = value;
				}
			}
		}

		[Category("Layout")]
		public int PageHeight
		{
			get {return _height;}
			set
			{
				if (value > 0)
				{
					_height = value;
				}
			}
		}

		[Category("Layout")]
		public int PageWidth
		{
			get {return _width;}
			set
			{
				if (value > 0)
				{
					_width = value;
				}
			}
		}

		[Browsable(false)]
		public int PageFooter
		{
			get
			{
				if (ShowFooter)
					return PageHeight - Bands.FindAll(BandEnum.PageFooterBand).Count;
				else
					return PageHeight;
			}
		}

		[Category("Appearance")]
		public bool ShowSummary
		{
			get {return _showsummary;}
			set {_showsummary = value;}
		}

		[Category("Appearance")]
		public bool ShowHeader
		{
			get { return _showheader; }
			set { _showheader = value; }
		}

		[Category("Appearance")]
		public bool ShowFooter
		{
			get { return _showfooter; }
			set { _showfooter = value; }
		}
		
		[Browsable(false)]
		internal BandList Bands
		{
			get
			{
				return _bands;
			}
		}
		
		[Browsable(false)]
		internal GroupList Groups
		{
			get {return _groups;}
		}

		public void Clear()
		{
			_bands.Clear();
			_groups.Clear();
			_showsummary = false;
			_showheader = true;
			_showfooter = true;
			_width = 80;
			_height = 60;
			_paperwidth = 850;
			_paperheight = 1100;
			_cpi = CPIEnum._10cpi;
			_name = "";
		}
		
		public void LoadFile(string fileName)
		{
			ReportReader reader = new ReportReader();
			reader.LoadFile(fileName);
			Load(reader);
		}
		
		public void LoadSchema(string schema)
		{
			ReportReader reader = new ReportReader();
			reader.LoadSchema(schema);
			Load(reader);
		}
		
		internal void Load(ReportReader reader)
		{
			Clear();
			this.DocumentName = reader.GetName();
			this.PageHeight = reader.GetHeight();
			this.PageWidth = reader.GetWidth();
			this.ShowSummary = reader.ShowSummary();
			this.ShowFooter = reader.ShowFooter();
			this.ShowHeader = reader.ShowHeader();
			this.PaperHeight = reader.GetPaperHeight();
			this.PaperWidth = reader.GetPaperWidth();
			this._cpi = reader.GetCpi();
			_groups.Load(reader.GetGroups());
			_bands.Load(reader.GetBands());
			foreach (Band band in _bands)
			{
				if (band.GroupId > 0)
				{
					band.Group = Groups[band.GroupId - 1];
				}
			}
			foreach (BaseWidget widget in reader.GetWidgets())
			{
				widget.Owner = this;
				_bands[widget.Row].Add(widget);
			}
		}
		
		public string GetSchema()
		{
			StringBuilder sb = new StringBuilder();
			StringWriter iowriter = new StringWriter(sb);
			XmlTextWriter writer = new XmlTextWriter(iowriter);
			writer.WriteStartElement("report");
			ToXml(writer);
			writer.WriteEndElement();
			return sb.ToString();
		}

		void ToXml(XmlTextWriter writer)
		{
			WriteAttributes(writer);
			Groups.WriteXml(writer);
			Bands.WriteXml(writer);
		}

		void WriteAttributes(XmlTextWriter writer)
		{
			writer.WriteStartElement("attributes");
			writer.WriteElementString("name", _name);
			writer.WriteElementString("width", _width.ToString());
			writer.WriteElementString("height", _height.ToString());
			writer.WriteElementString("cpi", _cpi.ToString());
			writer.WriteElementString("paperwidth", _paperwidth.ToString());
			writer.WriteElementString("paperheight", _paperheight.ToString());
			writer.WriteElementString("summary", _showsummary.ToString());
			writer.WriteElementString("header", _showheader.ToString());
			writer.WriteElementString("footer", _showfooter.ToString());
			writer.WriteEndElement();
		}
	}
}
