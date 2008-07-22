using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using Microsoft.VisualBasic;

namespace JasonJimenez.ClassicReport.Common.Widgets
{
	using JasonJimenez.ClassicReport.Common;

	internal class ValueWidget : BaseWidget
	{
		// design time variables
		AlignmentEnum m_align = AlignmentEnum.AlignLeft;
		CalcEnum m_calcType = CalcEnum.None;
		ResetEnum m_resetType = ResetEnum.Default;
		string m_columnName;
		string m_tableName;
		string m_dataFormat = "";
		TypeEnum m_type = TypeEnum.String;
		bool m_noduplicates;
		int m_index = 0;
		
		// used during runtime
		object m_value;
		object m_oldValue;
		IFunction m_calc;
		
		[Browsable(false)]
		public IFunction Calc
		{
			get { return m_calc; }
		}


		public ValueWidget()
		{
		}
		
		public ValueWidget(int column)
		{
			this.m_width = 10;
			this.m_col = column;
			this.m_columnName = "Field";
		}
		
		public ValueWidget(string caption, int col)
		{
			this.m_width = 10;
			this.m_col = col;
			this.m_columnName = caption;
		}
		
		public ValueWidget(XmlNode node) : base(node)
		{
			this.Width = Convert.ToInt32(ReportReader.GetValue(node, "width"));
			this.Alignment = (AlignmentEnum)Enum.Parse(typeof(AlignmentEnum),ReportReader.GetValue(node, "alignment"));
			this.CalcType = (CalcEnum)Enum.Parse(typeof(CalcEnum),ReportReader.GetValue(node, "calc"));
			this.DataFormat = ReportReader.GetValue(node, "dataformat");
			this.DataType = (TypeEnum)Enum.Parse(typeof(TypeEnum),ReportReader.GetValue(node, "datatype"));
			this.ResetType = (ResetEnum)Enum.Parse(typeof(ResetEnum),ReportReader.GetValue(node, "reset"));
			this.ColumnName = ReportReader.GetValue(node, "datamember");
			this.TableName = ReportReader.GetValue(node, "datasource");
			string arrIndex = ReportReader.GetValue(node, "arrayindex");
			if (arrIndex != "")
				this.ArrayIndex = int.Parse(arrIndex);
			this.NoDuplicates = bool.Parse(ReportReader.GetValue(node, "noduplicates"));
			m_calc = FunctionFactory.Create(m_calcType);
		}


		public void Reset()
		{
			if (m_calc != null)
			{
				m_calc.Reset();
			}
			m_value = null;
			m_oldValue = null;
		}
		
		public override string Value
		{
			get
			{
				object retval;
				if (m_calc != null)
				{
					retval = m_calc.GetValue();
				}
				else
				{
					retval = m_value;
				}
				if (m_noduplicates && m_value.Equals(m_oldValue))
				{
					retval = "";
				}
				if (retval == null)
				{
					return Strings.StrDup(m_width, "*");
				}
				//return Strings.Left(StrConv(Strings.Format(retval,m_dataFormat.Trim())),this.Width);
				string formatter="";
				if (m_dataFormat == "")
					formatter = "{0}";
				else
					formatter = "{0:" + m_dataFormat + "}";
				return StrConv(Strings.Left(string.Format(formatter, retval),this.Width)).Trim();
			}
		}

		[Category("Behavior")]
		public bool NoDuplicates
		{
			get { return m_noduplicates; }
			set { m_noduplicates = value; }
		}
		
		[Category("Design")]
		public override int Width
		{
			get {return m_width;}
			set {m_width = value;}
		}
		
		[Category("Design")]
		public string DataFormat
		{
			get {return m_dataFormat;}
			set {m_dataFormat = value;}
		}
		
		[Category("Data")]
		public TypeEnum DataType
		{
			get {return m_type;}
			set {m_type = value;}
		}
		
		[Category("Data")]
		public string ColumnName
		{
			get {return m_columnName;}
			set {m_columnName = value;}
		}
		
		[Category("Data")]
		public int ArrayIndex
		{
			get {return m_index;}
			set {m_index = value;}
		}

		[Category("Data")]
		public string TableName
		{
			get { return m_tableName; }
			set { m_tableName = value; }
		}
		
		[Category("Appearance")]
		public AlignmentEnum Alignment
		{
			get {return m_align;}
			set {m_align = value;}
		}
		
		[Category("Behavior")]
		public CalcEnum CalcType
		{
			get {return m_calcType;}
			set {m_calcType = value;}
		}

		[Category("Behavior")]
		public ResetEnum ResetType
		{
			get {return m_resetType;}
			set {m_resetType = value;}
		}
		
		public override string ToString()
		{
			return Microsoft.VisualBasic.Strings.Left(m_columnName, Width);
		}
		
		protected override void Write(XmlWriter writer)
		{
			writer.WriteElementString("_type", "1");
			writer.WriteElementString("alignment", m_align.ToString());
			writer.WriteElementString("calc", m_calcType.ToString());
			writer.WriteStartElement("dataformat");
			writer.WriteCData(m_dataFormat);
			writer.WriteEndElement();
			writer.WriteElementString("datatype", m_type.ToString());
			writer.WriteElementString("reset", m_resetType.ToString());
			writer.WriteElementString("datamember", m_columnName);
			writer.WriteElementString("datasource", m_tableName);
			writer.WriteElementString("noduplicates", m_noduplicates.ToString());
			writer.WriteElementString("arrayindex",m_index.ToString());
		}
		
		public override void Write(IPage page)
		{
			if (this.Justify != JustifyEnum.JustifyNone)

			{
				page.Write(this, this.Justify);
			}
			else
			{
				switch (this.Alignment)
				{
					case AlignmentEnum.AlignLeft:
						page.Write(this, m_col, AlignmentEnum.AlignLeft);
						break;
					case AlignmentEnum.AlignRight:
						page.Write(this, m_col + m_width, AlignmentEnum.AlignRight);
						break;
				}
			}
		}

		public void Aggregate(object value)
		{
			if (m_calc != null)
			{
				m_calc.Add(value);
			}
		}

		public void SetValue(object value)
		{
			if (value != null)
			{
				m_oldValue = m_value;
				//m_value = value;
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
		}
		
		public void Read(DataRow row)
		{
			if (!(row[m_columnName, DataRowVersion.Current] is DBNull))
			{
				SetValue(row[m_columnName, DataRowVersion.Current]);
			}
			else
			{
				SetValue(null);
			}
		}
	}
	
}
