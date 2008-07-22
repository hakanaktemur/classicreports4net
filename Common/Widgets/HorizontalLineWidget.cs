using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;


namespace JasonJimenez.ClassicReport.Common.Widgets
{
	internal class HorizontalLineWidget : BaseWidget
	{
		char m_char = '-';

        public HorizontalLineWidget()
        {
        }
		
		public HorizontalLineWidget(char ch, int col)
		{
			this.Col = col;
			this.Char = ch;
		}
		
		public HorizontalLineWidget(int col)
		{
			this.Col = col;
		}
		
		public HorizontalLineWidget(XmlNode node) : base(node)
		{
			this.Char = Convert.ToChar(ReportReader.GetValue(node, "char"));
			this.Width = Convert.ToInt32(ReportReader.GetValue(node, "width"));
		}
		
        //public override string Value 
        //{
        //    get {return this.ToString();}
        //}
		
		[System.ComponentModel.CategoryAttribute("Design")]
		public char Char 
		{
			get {return m_char;}
			set {m_char = value;}
		}
		
		[System.ComponentModel.CategoryAttribute("Design")]
		public override int Width 
		{
			get {return m_width;}
			set {m_width = value;}
		}
		
		public override string ToString()
		{			
			return Strings.StrDup(m_width, m_char);
		}
		
		protected override void Write(XmlWriter writer)
		{
			writer.WriteElementString("_type", "2");
			writer.WriteStartElement("char");
			writer.WriteCData(m_char.ToString());
			writer.WriteEndElement();
		}
		
		
	}
}
