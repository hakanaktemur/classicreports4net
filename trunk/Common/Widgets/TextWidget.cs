using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace JasonJimenez.ClassicReport.Common.Widgets
{
	internal class TextWidget : BaseWidget
	{
		string m_text = "";

        public TextWidget()
        {
        }
		
		public TextWidget(string caption, int column)
		{
			this.Text = caption;
			this.Col = column;
		}
		
		public TextWidget(int column)
		{
			this.Col = column;
			this.Text = "Text";
		}
		
		public TextWidget(System.Xml.XmlNode node) : base(node)
		{			
			this.Text = ReportReader.GetValue(node, "text");
		}
		
		[System.ComponentModel.CategoryAttribute("Design")]
		public string Text
		{
			get {return m_text;}
			set
			{
				if (value.Trim() != "")
				{
					m_text = value.Trim();
				}
			}
		}
		
		[System.ComponentModel.CategoryAttribute("Layout")]
		public override int Width
		{
			get {return m_text.Length;}			
		}
		
		public override string ToString()
		{
			return this.StrConv(m_text);
		}

        protected override void Write(XmlWriter writer)
        {
            writer.WriteElementString("_type", "0");
            writer.WriteStartElement("text");
            writer.WriteCData(m_text);
            writer.WriteEndElement();
        }
      
	}
}
