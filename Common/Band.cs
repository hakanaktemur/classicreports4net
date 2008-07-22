/*
 * Author: jason d. jimenez
 * Date  : 12/8/2005
 * Time  : 6:16 AM
 */

using System;
using System.Xml;
using JasonJimenez.ClassicReport.Common.Collections;
using JasonJimenez.ClassicReport.Common.Widgets;


namespace JasonJimenez.ClassicReport.Common
{

	class Band : IXmlWriter
	{
		int m_row = 0;
		int m_groupId;
		BandEnum m_bandType;
		Group m_group = null;
		ControlList m_widgets = new ControlList();
		
		public Band(BandEnum bandType, Group group)
		{
			m_bandType = bandType;
			this.Group = group;
		}
		
		public Band(BandEnum bandType)
		{
			m_bandType = bandType;
		}
		
		public Band(XmlNode node)
		{
			m_bandType = (BandEnum)Enum.Parse(typeof(BandEnum),ReportReader.GetValue(node, "type"));
			this.GroupId = Convert.ToInt32(ReportReader.GetValue(node, "groupid"));
			this.Row = Convert.ToInt32(ReportReader.GetValue(node, "row"));
		}

		public int Row
		{
			get { return m_row; }
			set
			{
				m_row = value;
				m_widgets.Reindex(Row);
			}
		}
		
		public BandEnum BandType
		{
			get	{return m_bandType;}
		}
		
		public Group Group
		{
			get {return m_group;}
			set {
				m_group = value;
				if (value == null)
				{
					m_groupId = 0;
				}
				else
				{
					m_groupId = value.Id;
				}
			}
		}
		
		[System.ComponentModel.Browsable(false)]
		public int GroupId
		{
			get {return m_groupId;}
			set {m_groupId = value;}
		}
		
		public ControlList Items
		{
			get {return m_widgets;}
		}
		
		
		public override string ToString()
		{
			string mValue = string.Empty;
			switch (m_bandType)
			{
				case BandEnum.PageHeaderBand:
					mValue = "header";
					break;
				case BandEnum.PageDetailBand:
					mValue = "detail";
					break;
				case BandEnum.PageFooterBand:
					mValue = "footer";
					break;
				case BandEnum.SummaryBand:
					mValue = "summary";
					break;
				case BandEnum.GroupHeaderBand:
					//mValue = m_group.Key.ToLower().Substring(0,10);
					//mValue = Microsoft.VisualBasic.Strings.Left(m_group.Key.ToLower(), 10);
					//break;
				case BandEnum.GroupFooterBand:
					//mValue = m_group.Key.ToLower().Substring(0,10);
					//mValue = Microsoft.VisualBasic.Strings.Left(m_group.Key.ToLower(), 10);
					mValue = m_group.ColumnName.ToLower();
					break;
			}
			return mValue;
		}

		public void AddFront(BaseWidget control)
		{
			m_widgets.Insert(0, control);
			control.Row = m_row;
		}
		
		public void Add(BaseWidget control)
		{
			m_widgets.Add(control);
			control.Row = m_row;
		}
		
		public void Remove(BaseWidget control)
		{
			m_widgets.Remove(control);
		}

		public void WriteXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("band");
			if (m_group != null)
			{
				writer.WriteElementString("groupid", m_group.Id.ToString());
			}
			else
			{
				writer.WriteElementString("groupid", "0");
			}
			writer.WriteElementString("row", m_row.ToString());
			writer.WriteElementString("type", m_bandType.ToString());
			m_widgets.WriteXml(writer);
			writer.WriteEndElement();
		}

		
	}

}
