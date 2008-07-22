/*
 * User: Jason Jimenez
 * Date: 12/8/2005
 * Time: 6:25 AM
 * 
 */

using System;
using System.ComponentModel;
using System.Data;
using System.Xml;

namespace JasonJimenez.ClassicReport.Common
{
	
	internal class Group : IXmlWriter
	{
		// design time
		int m_id = 0;
		string m_key = "<New>";
		bool m_showheader = true;
		bool m_showfooter = true;
		TypeEnum m_type = TypeEnum.String;
		
		// run time
		object m_value;
		bool m_changed;

        public Group(string key)
        {
            this.m_key = key;
            InitValue();
        }

        public Group(XmlNode node)
        {
            this.Id = Convert.ToInt32(ReportReader.GetValue(node, "id"));
            this.ColumnName = ReportReader.GetValue(node, "key");
            this.ShowFooter = Convert.ToBoolean(ReportReader.GetValue(node, "showfooter"));
            this.ShowHeader = Convert.ToBoolean(ReportReader.GetValue(node, "showheader"));
            this.DataType = (TypeEnum)Enum.Parse(typeof(TypeEnum),ReportReader.GetValue(node, "datatype"));
            InitValue();
        }
		
		[Browsable(false)]
		public bool IsChanged 
		{
			get 
            {
				return m_changed;
			}
		}
		
		[Browsable(false)]
		public int Id {
			get {
				return m_id;
			}
			set {
				m_id = value;
			}
		}
		
		[Category("Data")]
		public string ColumnName {
			get {
				return m_key;
			}
			set {
				m_key = value;
			}
		}
		
		[Category("Behavior")]
		public bool ShowHeader {
			get {
				return m_showheader;
			}
			set {
				m_showheader = value;
			}
		}

        [Category("Behavior")]
		public bool ShowFooter {
			get {
				return m_showfooter;
			}
			set {
				m_showfooter = value;
			}
		}
		
		[Category("Data")]
		public TypeEnum DataType {
			get {
				return m_type;
			}
			set {
				m_type = value;
			}
		}
		
		public override string ToString()
		{
			if (m_id > 0)
				return m_key;
			else 
				return "New me";
		}
		
		public void WriteXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("group");
			writer.WriteElementString("id", m_id.ToString());
			writer.WriteElementString("key", m_key.ToString());
			writer.WriteElementString("showfooter", m_showfooter.ToString());
			writer.WriteElementString("showheader", m_showheader.ToString());
			writer.WriteElementString("datatype", m_type.ToString());
			writer.WriteEndElement();
		}
		
		public void Read(DataRow row)
		{
			object prevValue = m_value;
			if (!(row[m_key, DataRowVersion.Current] is DBNull) )
			{
				switch (m_type) {
					case TypeEnum.String:
						m_value = Convert.ToString(row[m_key,DataRowVersion.Current]).Trim();
						break;
					case TypeEnum.Boolean:
                        m_value = Convert.ToBoolean(row[m_key, DataRowVersion.Current]);
						break;
					case TypeEnum.Currency:
                        m_value = Convert.ToDecimal(row[m_key, DataRowVersion.Current]);
						break;
					case TypeEnum.Date:
                        m_value = Convert.ToDateTime(row[m_key, DataRowVersion.Current]);
						break;
					case TypeEnum.Integer:
                        m_value = Convert.ToInt32(row[m_key, DataRowVersion.Current]);
						break;
				}
			}
			else
			{
				InitValue();
			}
			m_changed = (prevValue != m_value);
		}

        void SetValue(object value)
        {
            object prevValue = m_value;
            if (value != null)
            {
                switch (m_type)
                {
                    case TypeEnum.String:
                        m_value = value.ToString();
                        break;
                    case TypeEnum.Boolean:
                        m_value = Convert.ToBoolean(value);
                        break;
                    case TypeEnum.Currency:
                        m_value = Convert.ToDecimal(value);
                        break;
                    case TypeEnum.Date:
                        m_value = Convert.ToDateTime(value);
                        break;
                    case TypeEnum.Integer:
                        m_value = Convert.ToInt32(value);
                        break;
                }
            }
            else
            {
                m_value = null;
            }
            m_changed = !m_value.Equals(prevValue);
          }

        [Browsable(false)]
        public object Value
        {
            get { return m_value; }
            set { SetValue(value); }
        }   
		
		private void InitValue()
		{
			switch (m_type) {
				case TypeEnum.String:
					m_value = "";
					break;
				case TypeEnum.Boolean:
					m_value = false;
					break;
				case TypeEnum.Currency:
					m_value = 0m;
					break;
				case TypeEnum.Date:
					m_value = DateTime.MinValue;                    
					break;
				case TypeEnum.Integer:
					m_value = 0;
					break;
			}
		}
		
	
	}

}
