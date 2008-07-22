using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;

using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport
{
	public class ClassicReport : Component
	{
		string _template;
		object datasource;
		object target;
		IEnumerator enumerator;
		ClassicReportDocument _document;

		/// <summary>
		/// Occurs when the current row has changed.
		/// </summary>
		public event ClassicReportDataHandler RowChanged;
		
		/// <summary>
		/// Occurs when the value of a report field needs to be updated.
		/// </summary>
		public event ClassicReportDataHandler ValueOverride;

		public ClassicReport()
		{
		}

		[Browsable(false)]
		public object DataSource
		{
			get { return datasource; }
			set { datasource = value; }
		}

		public string DocumentName
		{
			get
			{
				if (_template != null || _template.Trim() != "")
				{
					ReportModel model = new ReportModel();
					model.LoadSchema(_template);
					return model.DocumentName;
				}
				return "";
			}
		}
		
		[Browsable(false)]
		public ClassicReportDocument Document
		{
			get { return _document; }
		}
		
		[Editor(typeof(TemplateEditor),typeof(UITypeEditor))]
		public string Template
		{
			get { return _template; }
			set { _template = value; }
		}

		public void Execute()
		{
			if (DataSource != null)
			{
				ReportComposer composer = new ReportComposer(_template);
				composer.InitData += new ReportComposerEventHandler(OnInitData);
				composer.ReadData += new ReportComposerEventHandler(OnReadData);
				composer.Execute();
				_document = composer.Document;
			}
			else
			{
				_document = null;
			}
		}

		#region ReportComposer event handlers
		void OnInitData(object sender, ReportComposerEventArgs e)
		{
			object _ds;
			if (DataSource is BindingSource)
				_ds = ((BindingSource)DataSource).DataSource;
			else
				_ds = DataSource;
			// initialize the record count and datasource here
			if (e.Bof)
			{
				e.Bof = false;
				if (_ds is System.Data.DataSet )
				{
					e.Count = ((System.Data.DataSet)_ds).Tables[0].Rows.Count;
					if (e.Count == 0)
					{
						e.Eof = true;
						return;
					}
				}
				else if (_ds is System.Data.DataTable)
				{
					e.Count = ((System.Data.DataTable)_ds).Rows.Count;
					if (e.Count == 0)
					{
						e.Eof = true;
						return;
					}
					
				}
				else if (_ds is IEnumerable)
				{
					e.Count = int.MaxValue;
					enumerator = ((IEnumerable)_ds).GetEnumerator();
				}
				else if (_ds is IList)
				{
					e.Count = ((IList)_ds).Count;
					if (e.Count == 0)
					{
						e.Eof = true;
						return;
					}
				}
				else if (_ds != null)
				{
					e.Count = 1;
				}
				else
				{
					e.Eof = true;
					return;
				}
			}
			// process a row here.
			if (_ds is System.Data.DataSet)
			{
				target = ((System.Data.DataSet)_ds).Tables[0].Rows[e.Index];
				OnRowChanged(new ClassicReportDataEventArgs(target, e));
			}
			else if (_ds is System.Data.DataTable)
			{
				target = ((System.Data.DataTable)DataSource).Rows[e.Index];
				OnRowChanged(new ClassicReportDataEventArgs(target, e));
			}
			else if (_ds is IEnumerable)
			{
				if (enumerator.MoveNext())
				{
					target = enumerator.Current;
					OnRowChanged(new ClassicReportDataEventArgs(target, e));
				}
				else
					e.Eof = true;
			}
			else if (_ds is IList)
			{
				target = ((IList)_ds)[e.Index];
				OnRowChanged(new ClassicReportDataEventArgs(target, e));
			}
			else
			{
				target = _ds;
			}
		}
		
		void OnReadData(object sender, ReportComposerEventArgs e)
		{
			// let the client process the data first
			ClassicReportDataEventArgs args = new ClassicReportDataEventArgs(target, e);
			if (ValueOverride != null)
			{
				ValueOverride(this, args);
				if (args.Handled)
				{
					e.Value = args.Value;
					return;
				}
			}
			// the client did not process the data 
			object _ds;
			if (DataSource is BindingSource)
				_ds = ((BindingSource)DataSource).DataSource;
			else
				_ds = DataSource;
			if (_ds is System.Data.DataSet || _ds is System.Data.DataTable)
			{
				System.Data.DataRow row = (System.Data.DataRow)target;
				e.Value = row[e.ColumnName];
			}
			else
			{
				PropertyInfo property = target.GetType().GetProperty(e.ColumnName);
				if (property != null)
					e.Value = property.GetValue(target, null);
				else
					e.Value = null;
			}
		}
		#endregion
		
		void OnRowChanged(ClassicReportDataEventArgs e)
		{
			if (RowChanged != null)
			{
				RowChanged(this, e);
			}
		}
		
		void OnValueOverride(ClassicReportDataEventArgs e)
		{
			if (ValueOverride != null)
			{
				ValueOverride(this, e);
			}
		}
	}

}
