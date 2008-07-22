/*
 * User: Jason D. Jimenez
 * Date: 12/8/2005
 * Time: 6:31 AM
 * 
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Reflection;

using Microsoft.VisualBasic;


namespace JasonJimenez.ClassicReport.Common.Widgets
{
    using JasonJimenez.ClassicReport.Common;

	internal abstract class BaseWidget : IXmlWriter, ICloneable
	{
		// design properties
		protected int m_col = 0;
		protected int m_row = 0;
		protected int m_width = 10;
		protected int m_height = 1;
		protected CasingEnum m_conv;
		protected JustifyEnum m_justify = JustifyEnum.JustifyNone;

        protected ReportModel m_owner = null;
        protected bool m_selected = false;
        
        public BaseWidget()
        {
        }

        public BaseWidget(XmlNode node)
        {
            this.Col = Convert.ToInt32(ReportReader.GetValue(node, "col"));
            this.Row = Convert.ToInt32(ReportReader.GetValue(node, "row"));
            this.Height = Convert.ToInt32(ReportReader.GetValue(node, "height"));
            this.Casing = (CasingEnum)Enum.Parse(typeof(CasingEnum), ReportReader.GetValue(node, "conversion"));
            this.Justify = (JustifyEnum)Enum.Parse(typeof(JustifyEnum), ReportReader.GetValue(node, "justify"));
            this.IsBold = ReportReader.GetValue(node, "bold") == "True";
            this.IsItalic = ReportReader.GetValue(node, "italic") == "True";
            this.IsUnderline = ReportReader.GetValue(node, "underline") == "True";
        }

        protected abstract void Write(XmlWriter writer);

        bool _bold;
        bool _underline;
        bool _italic;

        [Category("Appearance")]
	    public bool IsBold
        {
            get { return _bold; }
            set { _bold = value; }
        }

        [Category("Appearance")]
        public bool IsUnderline
        {
            get { return _underline; }
            set { _underline = value; }
        }

        [Category("Appearance")]
        public bool IsItalic
        {
            get { return _italic; }
            set { _italic = value; }
        }

        [Browsable(false)]
		public ReportModel Owner
		{
			get { return m_owner; }
			set { m_owner = value; }
		}
		
		[Category("Layout")]
		public virtual int Width
		{
			get {return m_width;}
            set {  }
		}
		
		[Category("Appearance")]
		public CasingEnum Casing
		{
			get {return m_conv;}
			set {m_conv = value;}
		}
		
		[Browsable(false)]
		public bool IsSelected
		{
			get {return m_selected;}
			set {m_selected = value;}
		}
		
		[Category("Layout")]
		public JustifyEnum Justify
		{
			get {return m_justify;}
			set {m_justify = value;}
		}
		
		[Browsable(false)]
		public int Row
		{
			get {return m_row;}
			set {m_row = value;}
		}
		
		[Category("Layout")]
		public int Col
		{
			get
			{
				switch (m_justify)
				{
					case JustifyEnum.JustifyLeft:
						return 0;
					case JustifyEnum.JustifyRight:
						return Owner.PageWidth - this.Width;
					case JustifyEnum.JustifyCenter:
						return (Owner.PageWidth - this.Width) / 2;
					default:
						return m_col;
				}
			}
			set {m_col = value;}
		}
		
		[Browsable(true)]
		public int Height
		{
			get {return m_height;}
			set 
            {
                if (value>0) m_height = value;
            }
		}
		
		public override string ToString()
		{
			return base.ToString();
		}
		
		public System.Drawing.Rectangle GetRectangle()
		{
			return new Rectangle(this.Col, this.Row, this.Width, this.Height);
		}
		
        [Browsable(false)]
		public virtual string Value
		{
			get {return this.ToString();}
		}
		
		public string StrConv(string s)
		{
			VbStrConv conv = VbStrConv.None;
			switch (m_conv)
			{
				case CasingEnum.None:
					conv = VbStrConv.None;
					break;
				case CasingEnum.Upper:
					conv = VbStrConv.Uppercase;
					break;
				case CasingEnum.Lower:
					conv = VbStrConv.Lowercase;
					break;
				case CasingEnum.Proper:
					conv = VbStrConv.ProperCase;
					break;
			}
			return Microsoft.VisualBasic.Strings.StrConv(s,conv,0);
		}
		
        public virtual void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("widget");
            writer.WriteElementString("col", m_col.ToString());
            writer.WriteElementString("row", m_row.ToString());
            writer.WriteElementString("conversion", m_conv.ToString());
            writer.WriteElementString("height", m_height.ToString());
            writer.WriteElementString("justify", m_justify.ToString());
            writer.WriteElementString("width", m_width.ToString());
            writer.WriteElementString("bold", _bold.ToString());
            writer.WriteElementString("italic", _italic.ToString());
            writer.WriteElementString("underline", _underline.ToString());
            this.Write(writer);
            writer.WriteEndElement();
        }

        
        public virtual void Write(IPage page)
        {
            if (this.Justify != JustifyEnum.JustifyNone)
            {
                page.Write(this, this.Justify);
            }
            else
            {
                page.Write(this, this.Col);
            }
        }

        public void SetValue(string propertyName, object value)
        {
            PropertyInfo prop = this.GetType().GetProperty(propertyName);
            try
            {
                prop.SetValue(this, value, null);
            }
            catch { }
        }


        #region ICloneable Members

        public object Clone()
        {
            object clone = Activator.CreateInstance(this.GetType());
            PropertyInfo[] pi = this.GetType().GetProperties();
            foreach (PropertyInfo info in pi)
            {
                if (info.CanWrite)
                {
                    info.SetValue(clone, info.GetValue(this, null),null);
                }
            }
            return clone;
        }

        #endregion


        public void BringToFront()
        {
            Band band = m_owner.Bands[m_row];
            band.Remove(this);
            band.AddFront(this);
        }

        public void SendToBack()
        {
            Band band = m_owner.Bands[m_row];
            band.Remove(this);
            band.Add(this);
        }
    }

    //internal class TemplateWidget : BaseWidget
    //{
    //    public override void Write(IWriter Document)
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }

    //    public override void Write(XmlWriter writer)
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }

    //    public override int Width
    //    {
    //        get
    //        {
    //            return base.Width;
    //        }
    //        set
    //        {
    //            if (value>0) m_width = value;
    //        }
    //    }
    //}
}
