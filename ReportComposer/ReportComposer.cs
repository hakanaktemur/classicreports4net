/*
 * Author: Jason D. Jimenez
 * Date  : 12/18/2005
 * Time  : 6:16AM
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

using JasonJimenez.ClassicReport.Common;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport
{
	/// <summary>
	/// A control for compiling live reports.
	/// </summary>
	public class ReportComposer : Component
	{
		/// <summary>
		/// An event fired whenever the control needs to read data.
		/// </summary>
		public event ReportComposerEventHandler ReadData;

		/// <summary>
		/// An event fired when the control needs to inititalize the data source
		/// </summary>
		public event ReportComposerEventHandler InitData;

		ReportModel _model;
		ClassicReportDocument _document;
		ReportComposerEventArgs _args = new ReportComposerEventArgs();
		ClassicReportPage _page;
		int _footer;
		
		public ReportComposer()
		{
		}
		
		public ReportComposer(string schema)
		{
			_model = new ReportModel(schema);
		}

		#region Properties

		[Browsable(false)]
		public ClassicReportDocument Document
		{
			get { return _document; }
		}

		#endregion

		
		bool Eof()
		{
			return _args.Eof || ( _args.Index >= _args.Count );
		}

		public void Execute(string schema)
		{
			_model = new ReportModel(schema);
			Execute();
		}

		public void Execute()
		{
			Reset();
			InitData(this, _args);
			if (!Eof())
			{
				InitGroups();
				Update();
			}
			Render();
		}

		void Reset()
		{
			_document = new ClassicReportDocument(_model);
			//_document._width = _model.PageWidth;
			_footer = _model.PageFooter;
			_args.Index = 0;
			_args.Eof = false;
			_args.Bof = true;
			// reset all fields
			foreach (Band band in _model.Bands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					ValueWidget vw = widget as ValueWidget;
					if (vw != null) vw.Reset();
				}
			}
		}

		void Render()
		{
			NewPage();
			RenderGroupHeader(1);
			while (!Eof())
			{
				RenderDetail();
				MoveNext();
				if (!Eof())
				{
					int groupIndex = UpdateGroups();
					if (groupIndex > 0)
					{
						RenderGroupFooter(groupIndex);
						RenderGroupHeader(groupIndex);
						ResetDetailAggregates(ResetEnum.EndOfGroup);
					}
					Update();
				}
			}
			RenderGroupFooter(1);
			RenderSummary();
			if (!_page.hasFooter)
				RenderPageFooter();
		}

		void NewPage()
		{
			_page = _document.NewPage();
			RenderPageHeaderSection();
		}
		
		void MoveNext()
		{
			_args.Index++;
			if (!Eof()) InitData(this, _args);
		}

		void Update()
		{
			foreach (Band band in _model.Bands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					ValueWidget vw = widget as ValueWidget;
					if (vw != null)
					{
						object colValue = GetColumnValue(vw.ColumnName);
						if (vw.CalcType == CalcEnum.None)
							vw.SetValue(colValue);
						else
							vw.Aggregate(colValue);
					}
				}
			}
		}

		void InitGroups()
		{
			foreach (Group group in _model.Groups)
			{
				group.Value = GetColumnValue(group.ColumnName);
			}
		}

		void RenderPageHeaderSection()
		{
			if (_model.ShowHeader)
			{
				foreach (Band band in GetHeaderBands())
				{
					foreach (BaseWidget widget in band.Items)
					{
						widget.Write(_page);
					}
					_page.WriteLine();
				}
			}
		}

		bool HasGroups()
		{
			return _model.Groups.Count > 0;
		}

		void RenderGroupHeader(int groupIndex)
		{
			if (HasGroups())
			{
				for (int index = groupIndex; index <= _model.Groups.Count; index++)
				{
					Group group = _model.Groups[index - 1];
					if (group.ShowHeader)
					{
						// loop around each groups bands
						List<Band> groupHeaderBands = GetGroupHeaderBands(index);
						if (WillOverFlow(groupHeaderBands.Count))
						{
							RenderPageFooter();
						}
						foreach (Band band in groupHeaderBands)
						{
							foreach (BaseWidget widget in band.Items)
							{
								widget.Write(_page);
								ValueWidget vw = widget as ValueWidget;
								if (vw != null) vw.Reset();
							}
							_page.WriteLine();
							if (_page.CurrentRow >= _footer)
							{
								RenderPageFooter();
							}
						}
					}
				}
			}
		}

		void RenderDetail()
		{
			List<Band> detailBands = GetDetailBands();
			if (WillOverFlow(detailBands.Count))
			{
				List<Band> footerBands = GetFooterBands();
				RollbackAggregates(footerBands);
				RenderPageFooter();
				UpdateAggregates(footerBands);
			}
			foreach (Band band in detailBands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					widget.Write(_page);
				}
				_page.WriteLine();
				if (_page.CurrentRow >= _footer)
				{
					RenderPageFooter();
				}
			}
		}

		int UpdateGroups()
		{
			int index = 0;
			foreach (Group group in _model.Groups)
			{
				group.Value = GetColumnValue(group.ColumnName);
				if (group.IsChanged)
				{
					if (index == 0)
					{
						index = group.Id;
					}
				}
			}
			return index;
		}

		void RenderPageFooter()
		{
			List<Band> footerBands = GetFooterBands();
			if (_model.ShowFooter)
			{
				while (_page.CurrentRow < _footer)
				{
					_page.WriteLine();
				}
				foreach (Band band in footerBands)
				{
					foreach (BaseWidget widget in band.Items)
					{
						widget.Write(_page);
					}
					_page.WriteLine();
				}
			}
			ResetAggregates(footerBands, ResetEnum.Default);
			ResetDetailAggregates(ResetEnum.EndOfPage);
			_page.hasFooter = true;
			if (!Eof())
			{
				NewPage();
			}
		}
		
		void RenderSummary()
		{
			if (!_model.ShowSummary)
			{
				return;
			}
			List<Band> summaryBands = GetSummaryBands();
			if (WillOverFlow(summaryBands.Count))
			{
				RenderPageFooter();
				NewPage();
			}
			foreach (Band band in summaryBands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					widget.Write(_page);
				}
				_page.WriteLine();
			}
		}
		

		void RenderGroupFooter(int groupIndex)
		{
			if (HasGroups())
			{
				for (int index = _model.Groups.Count; index >= groupIndex; index--)
				{
					Group group = _model.Groups[index - 1];
					if (group.ShowFooter)
					{
						List<Band> grpFooterBands = GetGroupFooterBands(index);
						if (WillOverFlow(grpFooterBands.Count))
						{
							RenderPageFooter();
						}
						foreach (Band band in grpFooterBands)
						{
							foreach (BaseWidget widget in band.Items)
							{
								widget.Write(_page);
								ValueWidget vw = widget as ValueWidget;
								if (vw != null)
								{
									if (vw.ResetType == ResetEnum.Default || vw.ResetType == ResetEnum.EndOfGroup)
										vw.Reset();
								}
							}
							_page.WriteLine();
							if (_page.CurrentRow == _footer)
							{
								RenderPageFooter();
							}
						}
					}
				}
			}
		}
		
		void RollbackAggregates(List<Band> bands)
		{
			foreach(Band band in bands)
			{
				foreach(BaseWidget widget in band.Items)
				{
					ValueWidget vw = widget as ValueWidget;
					if (vw != null && vw.CalcType != CalcEnum.None)
						vw.Calc.Rollback();
				}
			}
		}
		
		void UpdateAggregates(List<Band> bands)
		{
			foreach(Band band in bands)
			{
				foreach(BaseWidget widget in band.Items)
				{
					ValueWidget vw = widget as ValueWidget;
					if (vw != null && vw.CalcType != CalcEnum.None)
						vw.Aggregate(GetColumnValue(vw.ColumnName));
				}
			}
		}
		
		void ResetAggregates(List<Band> bands, ResetEnum resetType)
		{
			foreach (Band band in bands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					ValueWidget vw = widget as ValueWidget;
					if (vw != null && vw.CalcType != CalcEnum.None && vw.ResetType == resetType)
						vw.Reset();
				}
			}
		}
		
		void ResetDetailAggregates(ResetEnum resetType)
		{
			foreach (Band band in GetDetailBands())
			{
				foreach (ValueWidget widget in band.Items.FindAll(typeof(ValueWidget)))
				{
					if (widget.CalcType != CalcEnum.None && widget.ResetType == resetType)
					{
						widget.Reset();
					}
				}
			}
		}
		
		object GetColumnValue(string columnName)
		{
			_args.ColumnName = columnName;
			ReadData(this, _args);
			return _args.Value;
		}

		bool WillOverFlow(int count)
		{
			return _page.CurrentRow + count > _footer;
		}

		List<Band> GetGroupFooterBands(int groupId)
		{
			return _model.Bands.FindGroupBand(BandEnum.GroupFooterBand, groupId);
		}

		List<Band> GetGroupHeaderBands(int groupId)
		{
			return _model.Bands.FindGroupBand(BandEnum.GroupHeaderBand, groupId);
		}

		List<Band> GetHeaderBands()
		{
			return _model.Bands.FindAll(BandEnum.PageHeaderBand);
		}

		List<Band> GetDetailBands()
		{
			return _model.Bands.FindAll(BandEnum.PageDetailBand);
		}
		
		List<Band> GetFooterBands()
		{
			return _model.Bands.FindAll(BandEnum.PageFooterBand);
		}

		List<Band> GetSummaryBands()
		{
			return _model.Bands.FindAll(BandEnum.SummaryBand);
		}

		
	}
	
}
