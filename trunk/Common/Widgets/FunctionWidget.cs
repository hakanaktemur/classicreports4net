using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;


namespace JasonJimenez.ClassicReport.Common.Widgets
{
    internal class FunctionWidget : BaseWidget
	{
		FunctionEnum m_function = FunctionEnum.PageEx;
		string m_format = "";

        public FunctionWidget()
        {
        }
		
		public FunctionWidget(int col)
		{
			this.Col = col;
		}
		
		public FunctionWidget(System.Xml.XmlNode node) : base(node)
		{
			this.Function = (FunctionEnum)Enum.Parse(typeof(FunctionEnum),ReportReader.GetValue(node, "function"));
			this.Width = Convert.ToInt32(ReportReader.GetValue(node, "width"));
			this.DateFormat = ReportReader.GetValue(node, "dataformat");
		}
		
		public override string Value
		{
			get
			{
				string s = string.Empty;
				switch (m_function) {
					case FunctionEnum.DateTime:
				        s = StrConv(DateTime.Now.ToString(m_format));
						break;
					case FunctionEnum.Page:
						s = "%Page";
						break;
                    case FunctionEnum.PageEx:
						s = "%PageEx";
						break;
				}
				return s;
			}
		}
		
		[Category("Design")]
		public string DateFormat
		{
			get {return m_format;}
			set {m_format = value;}
		}
		
		[Category("Layout")]
		public override int Width
		{
			get {return ToString().Length;}
			set {m_width = value;}
		}
		
		[Category("Design")]
		public FunctionEnum Function
		{
			get {return m_function;}
			set {m_function = value;}
		}
		
		public override string ToString()
		{
			string s = string.Empty;
			switch (m_function)
			{
				case FunctionEnum.DateTime:
					try
					{
                        if (m_format == "")
                            s = DateTime.Now.ToString();
                        else
                        {
                            s = Microsoft.VisualBasic.Strings.Format(DateTime.Now, m_format);
                            s = StrConv(s);
                        }
					}
					catch
					{
						s = DateTime.Now.ToString();
						m_format = "";
					}
					break;
				case FunctionEnum.Page:
					s = "Page 1";
					break;
				case FunctionEnum.PageEx:
					s = "Page 1 of 1";
					break;
			}
			return this.StrConv(s);
		}
		
		protected override void Write(XmlWriter writer)
		{
			writer.WriteElementString("_type", "3");
			writer.WriteStartElement("dataformat");
			writer.WriteCData(m_format);
			writer.WriteEndElement();
			writer.WriteElementString("function", m_function.ToString());
		}
		
	}
}
