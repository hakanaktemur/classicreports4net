using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using JasonJimenez.ClassicReport.Common;
using JasonJimenez.ClassicReport.Common.Collections;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport
{
	enum ModeEnum
	{
		Default,
		Selecting,
		Moving
	}

	[ToolboxItem(false)]
	internal partial class ReportDesignerPanel : UserControl
	{
		// constants
		const int MAX_COL = 500;
		const int MAX_ROW = 500;

		// coordinates
		//int _row = 0;
		//int _col = 0;
		int _top = 0;
		int _left = 0;
		int _bandmargin = 0;
		Point _cursor;
		Point _rawMouse;
		Point _pivot;
		Rectangle _selectionRect;
		Rectangle _prevSelectionRect;

		// flags
		ModeEnum _mode = ModeEnum.Default;

		// fonts
		Font _normalFont = new Font("Courier New", 10);
		Font _boldFont = new Font("Courier New", 10, FontStyle.Bold);
		Font _italicFont = new Font("Courier New", 10, FontStyle.Italic);
		int _charWidth = 0;
		int _charHeight = 0;

		// data
		ReportModel _model = new ReportModel();
		string _lastControl = "";

		// collections
		SelectionList _selections = new SelectionList();
		SelectionList _clipboard = new SelectionList();

		// events
		public event ReportDesignerEventHandler SelectionChanged;
		public event ReportDesignerEventHandler ClipBoardChanged;
		
		public ReportDesignerPanel()
		{
			InitializeComponent();
			SizeF size = this.CreateGraphics().MeasureString("1", _normalFont);
			_charHeight = (int)size.Height;
			_charWidth = (int)size.Width - 4;
			_bandmargin = label1.Width;
			vScrollBar.Maximum = MAX_ROW;
			hScrollBar1.Maximum = MAX_COL;
			hScrollBar1.Value = 0;
			LeftCol = 0;
		}


		public ReportModel ReportSchema
		{
			get { return _model; }
		}

		public void OpenReport(string path)
		{
			_model.LoadFile(path);
			Invalidate();
		}
		
		public void OpenSchema(string schema)
		{
			_model.LoadSchema(schema);
			Invalidate();
		}

		public void CutWidgets()
		{
			_clipboard.Clear();
			foreach (BaseWidget widget in _selections)
			{
				Band band = _model.Bands[widget.Row];
				band.Items.Remove(widget);
				_clipboard.Add(widget);
			}
			_selections.Clear();
			RenderControls();
			OnSelectionChanged();
			OnClipBoardChanged();
		}

		public void CopyWidgets()
		{
			_clipboard.Clear();
			foreach (BaseWidget widget in _selections)
			{
				BaseWidget clone = (BaseWidget)widget.Clone();
				_clipboard.Add(clone);
			}
			OnClipBoardChanged();
		}

		public void PasteWidgets()
		{
			foreach (BaseWidget widget in _clipboard)
			{
				Band band = _model.Bands[widget.Row];
				band.Items.Add(widget);
			}
			RenderControls();
			_clipboard.Clear();
			OnClipBoardChanged();
		}

		public void SetValue(string propertyName, object value)
		{
			if (_selections.Count > 1)
			{
				foreach (BaseWidget widget in _selections)
				{
					widget.SetValue(propertyName, value);
				}
			}
		}

		public void Clear()
		{
			_selections.Clear();
			_clipboard.Clear();
			_model.Clear();
			_model = new ReportModel();
			OnClipBoardChanged();
			Invalidate();
		}

		public string LastControl()
		{
			return _lastControl;
		}

		BaseWidget GetWidgetAt(Point pt)
		{
			BaseWidget widget = null;
			try
			{
				foreach (BaseWidget w in _model.Bands[pt.Y].Items)
				{
					if (w.GetRectangle().Contains(pt))
					{
						widget = w;
						break;
					}
				}
			}
			catch
			{
			}
			return widget;
		}
		
		int GetMargin()
		{
			return _bandmargin + 1;
		}

		int MaxViewRows()
		{
			return (Height - bottomPanel.Height) / _charHeight;
		}

		int MaxViewCols()
		{
			return (Width - GetMargin()) / _charWidth;
		}

		int LeftCol
		{
			set
			{
				if (value >= 0)
				{
					try
					{
						_left = value;
						hScrollBar1.Value = value;
					}
					catch
					{
						_left = MAX_COL;
						hScrollBar1.Value = MAX_COL;
					}
				}
				else
				{
					_left = 0;
					hScrollBar1.Value = 0;
				}
			}
		}

		int TopRow
		{
			set
			{
				if (value >= 0)
				{
					try
					{
						_top = value;
						vScrollBar.Value = value;
					}
					catch
					{
						_top = MAX_ROW;
						vScrollBar.Value = MAX_ROW;
					}
				}
				else
				{
					_top = 0;
					vScrollBar.Value = 0;
				}
			}
		}

		Rectangle GetDesignRect()
		{
			return new Rectangle(GetMargin(), 0, MaxViewCols() * _charWidth, MaxViewRows() * _charHeight);
		}

		Point PointToDesignClient(Point p)
		{
			int rel_row = p.Y / _charHeight;
			int rel_col = (p.X - GetMargin()) / _charWidth;
			int x = _left + rel_col;
			int y = _top + rel_row;
			if (x < 0)
			{
				x = 0;
			}
			if (y < 0)
			{
				y = 0;
			}
			return new Point(x, y);
		}

		public int BandCount
		{
			get { return _model.Bands.Count; }
		}

		public string ToXml()
		{
			//            StringBuilder sb = new StringBuilder();
			//            StringWriter iowriter = new StringWriter(sb);
			//            XmlTextWriter writer = new XmlTextWriter(iowriter);
			//            writer.WriteStartElement("report");
			//            _model.ToXml(writer);
			//            writer.WriteEndElement();
			//            return sb.ToString();
			return _model.GetSchema();
		}

		void DrawString(Graphics g, Font font, Brush brush, string s, int x, int y)
		{
			foreach (char ch in s)
			{
				g.DrawString(ch.ToString(), font, brush, x, y);
				x += _charWidth;
			}
			brush.Dispose();
		}

		void RenderBands(Graphics g)
		{
			int row = 0;
			g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight)), 0, 0, _bandmargin, this.Height);
			for (int index = _top; index < _model.Bands.Count; ++index)
			{
				Band band = _model.Bands[index];
				g.DrawString(band.ToString(), _boldFont, GetBrush(band), 0, row*_charHeight);
				if (++row > MaxViewRows())
				{
					break;
				}
			}
		}

		void RenderControls()
		{
			RenderControls(CreateGraphics());
		}

		void RenderControls(Graphics g)
		{
			g.IntersectClip(GetDesignRect());
			g.Clear(this.BackColor);
			int x = _model.PageWidth;
			g.DrawLine(Pens.WhiteSmoke,PointToDesignScreen(new Point(x,0)),PointToDesignScreen(new Point(x,this.Height)));
			foreach (Band band in _model.Bands)
			{
				if (band.Row >= _top)
				{
					foreach (BaseWidget widget in band.Items)
					{
						Point p = PointToDesignScreen(new Point(widget.Col,widget.Row));
						Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
						Font font;
						FontStyle fontStyle = FontStyle.Regular;
						//if (widget.IsSelected)
						//{
						//    font = _italicFont;
						//}
						//else
						//{
						//    font = _normalFont;
						//}
						if (widget.IsBold)
							fontStyle |= FontStyle.Bold;
						if (widget.IsUnderline)
							fontStyle |= FontStyle.Underline;
						if (widget.IsItalic)
							fontStyle |= FontStyle.Italic;
						font = new Font("Courier New",10, fontStyle);
						if (widget.IsSelected)
						{
							g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Highlight)), RectToScreen(widget.GetRectangle()));
							brush = new SolidBrush(Color.FromKnownColor(KnownColor.HighlightText));
						}
						else if (widget is ValueWidget)
						{
							g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), RectToScreen(widget.GetRectangle()));
							brush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));
						}
						DrawString(g, font, brush, widget.ToString(), p.X, p.Y);
						brush.Dispose();
						font.Dispose();
					}
				}
			}
		}

		void RenderControls(Graphics g, Rectangle rect)
		{
			g.SetClip(Inflate(RectToScreen(rect)));
			RenderControls(g);
			g.ResetClip();
		}

		Brush GetBrush(Band band)
		{
			Brush brush;
			switch (band.BandType)
			{
				case BandEnum.PageHeaderBand:
					if (_model.ShowHeader)
					{
						brush = new SolidBrush(Color.Navy);
					}
					else
					{
						brush = new SolidBrush(Color.LightGray);
					}
					break;
				case BandEnum.GroupHeaderBand:
					if (band.Group.ShowHeader)
					{
						brush = new SolidBrush(Color.DarkMagenta);
					}
					else
					{
						brush = new SolidBrush(Color.LightGray);
					}
					break;
				case BandEnum.PageDetailBand:
					brush = new SolidBrush(Color.Green);
					break;
				case BandEnum.GroupFooterBand:
					if (band.Group.ShowFooter)
					{
						brush = new SolidBrush(Color.DarkMagenta);
					}
					else
					{
						brush = new SolidBrush(Color.LightGray);
					}
					break;
				case BandEnum.PageFooterBand:
					if (_model.ShowFooter)
					{
						brush = new SolidBrush(Color.Red);
					}
					else
					{
						brush = new SolidBrush(Color.LightGray);
					}
					break;
				case BandEnum.SummaryBand:
					if (_model.ShowSummary)
					{
						brush = new SolidBrush(Color.DarkOrange);
					}
					else
					{
						brush = new SolidBrush(Color.LightGray);
					}
					break;
				default:
					brush = new SolidBrush(Color.Black);
					break;
			}
			return brush;
		}

		public void AddGroup(Group group)
		{
			//_schema.Groups.Add(group);
			//_schema.Bands.Add(group);
			_model.Add(group);
			CheckVerticalScolling();
			Invalidate();
		}

		public void RemoveGroup(Group group)
		{
			//_schema.Groups.Remove(group);
			//_schema.Bands.Remove(group);
			_model.Remove(group);
			CheckVerticalScolling();
			Invalidate();
		}

		public void InsertControl(string name)
		{
			InsertControl(name, _cursor);
		}

		void InsertControl(string name, Point p)
		{
			try
			{
				Band band = _model.Bands[p.Y];
				BaseWidget widget = WidgetFactory.Create(name);
				widget.Owner = _model;
				widget.Row = p.Y;
				widget.Col = p.X;
				band.Add(widget);
				RenderControls();
			}
			catch
			{
			}
		}

		void UpdateStatus(int x, int y)
		{
			label1.Text = string.Format("C{0}, R{1}", x, y);
		}

		void UpdateCursor()
		{
			_cursor = PointToDesignClient(_rawMouse);
			if (_cursor.Y >= BandCount - 1)
			{
				_cursor.Y = BandCount - 1;
			}
			if (_cursor.X >= MAX_COL)
			{
				_cursor.X = MAX_COL;
			}
			//_row = _cursor.Y;
			//_col = _cursor.X;
		}

		Rectangle GetSelectionRect()
		{
			Point p1 = _pivot; ;
			Point p2 = _cursor;
			if (_cursor.X <= _pivot.X && _cursor.Y <= _pivot.Y) // upper left
			{
				p1 = _cursor;
				p2 = _pivot;
			}
			else if (_cursor.X >= _pivot.X && _cursor.Y >= _pivot.Y) // lower right
			{
				p1 = _pivot;
				p2 = _cursor;
			}
			else if (_cursor.X > _pivot.X && _cursor.Y < _pivot.Y)  // upper right
			{
				p1 = new Point(_pivot.X, _cursor.Y);
				p2 = new Point(_cursor.X, _pivot.Y);
			}
			else // lower left
			{
				p1 = new Point(_cursor.X, _pivot.Y);
				p2 = new Point(_pivot.X, _cursor.Y);
			}
			return new Rectangle(p1.X, p1.Y, p2.X - p1.X + 1, p2.Y - p1.Y + 1);
		}

		void UpdateView()
		{
			bool isVScrolled = false;
			UpdateStatus(_cursor.X,_cursor.Y);
			if (_mode != ModeEnum.Default)
			{
				if (_cursor.X < _left)
				{
					LeftCol = _cursor.X;
					RenderControls();
				}
				else if (_cursor.X > _left + MaxViewCols() - 1)
				{
					LeftCol = _cursor.X - MaxViewCols() + 1;
					RenderControls();
				}
				if (vScrollBar.Visible)
				{
					if (_cursor.Y < _top)
					{
						TopRow = _cursor.Y;
						RenderControls();
						isVScrolled = true;
					}
					else if (_cursor.Y > _top + MaxViewRows() - 1)
					{
						TopRow = _cursor.Y - MaxViewRows() + 1;
						RenderControls();
						isVScrolled = true;
					}
				}
				if (_mode == ModeEnum.Selecting)
				{
					_selectionRect = GetSelectionRect();
					RenderSelectionRectangle(isVScrolled);
				}
				else if (_mode == ModeEnum.Moving)
				{
					_selectionRect = GetTargetRect();
					RenderSelectionRectangle(isVScrolled);
				}
			}
		}

		Point GetTargetOffset()
		{
			return new Point(_cursor.X - _pivot.X, _cursor.Y - _pivot.Y);
		}

		Rectangle GetTargetRect()
		{
			Point offset = GetTargetOffset();
			Rectangle rect = _selections.GetRectangle();
			if (offset.X != 0 || offset.Y != 0)
			{
				rect.Offset(offset);
				if (rect.X < 0) rect.X = 0;
				if (rect.Y < 0) rect.Y = 0;
			}
			return rect;
		}

		void RenderSelectionRectangle(bool isVScrolled)
		{
			Graphics g = CreateGraphics();
			if (isVScrolled)
			{
				// repaint the whole view
				RenderBands(g);
				//RenderControls(g);
			}
			else
			{
				// repaint previous selection
				RenderControls(g, _prevSelectionRect);
			}
			// draw the curent selection rectangle
			g.SetClip(GetDesignRect());
			g.DrawRectangle(Pens.Black, RectToScreen(_selectionRect));
			g.Dispose();
		}

		Rectangle Inflate(Rectangle rect)
		{
			rect.X--;
			rect.Y--;
			rect.Width += 2;
			rect.Height += 2;
			return rect;
		}

		Rectangle RectToScreen(Rectangle rect)
		{
			Point p = PointToDesignScreen(new Point(rect.X, rect.Y));
			int width = rect.Width * _charWidth;
			int height = (rect.Height) * _charHeight;
			return new Rectangle(p.X, p.Y, width, height);
		}

		Point PointToDesignScreen(Point p)
		{
			int x = p.X * _charWidth - (_left * _charWidth) + GetMargin();
			int y = p.Y * _charHeight - (_top * _charHeight);
			return new Point(x, y);
		}

		void MoveWidgets()
		{
			Point offset = GetTargetOffset();
			foreach (BaseWidget widget in _selections)
			{
				int y = widget.Row + offset.Y;
				int x = widget.Col + offset.X;
				if (x < 0) x = 0;
				if (y < 0) y = 0;
				_model.Bands[y].Add(widget);
				widget.Col = x;
			}
		}

		void SelectWidgets()
		{
			_selections.Clear();
			foreach (Band band in _model.Bands)
			{
				foreach (BaseWidget widget in band.Items)
				{
					if (_selectionRect.IntersectsWith(widget.GetRectangle()))
					{
						widget.IsSelected = true;
						_selections.Add(widget);
					}
				}
			}
			RenderControls();
			OnSelectionChanged();
		}
		

		#region keyboard handler
		bool isAltPressed;
		bool isCtrlPressed;
		bool isShiftPressed;

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			isAltPressed = e.Alt;
			isCtrlPressed = e.Control;
			isShiftPressed = e.Shift;
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			isAltPressed = false;
			isCtrlPressed = false;
			isShiftPressed = false;
		}
		#endregion

		#region mouse handlers
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (_mode != ModeEnum.Default)
			{
				_prevSelectionRect = _selectionRect;
			}
			_rawMouse = new Point(e.X, e.Y);
			UpdateCursor();
			UpdateView();
		}

		/// <summary>
		/// Capture mouse position when left mouse button is pressed
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			// buffer = GetScreen(GetDesignRect())

			_pivot = PointToDesignClient(new Point(_rawMouse.X, _rawMouse.Y));
			if (_rawMouse.X < GetMargin())
			{
				if (_pivot.Y < BandCount)
				{
					if (e.Button == MouseButtons.Left)
						_model.Bands.Insert(_pivot.Y);
					else
						_model.Bands.Remove(_pivot.Y);
					CheckVerticalScolling();
					Invalidate();
				}
			}
			else if (_pivot.Y < BandCount  && e.Button == MouseButtons.Left)
			{
				BaseWidget w = GetWidgetAt(_pivot);
				if (_selections.Hit(_pivot))
				{
					// we clicked the current selection
					// so we prepare to move it around
					_mode = ModeEnum.Moving;
					_prevSelectionRect = _selections.GetRectangle();
					RemoveSelectedFromHost();
				}
				else if (w != null)
				{
					// we clicked on a widget so we place
					// it on the selection list and
					// start moving it around.
					if (!isCtrlPressed) _selections.Clear();
					_selections.Add(w);
					w.IsSelected = true;
					RemoveSelectedFromHost();
					OnSelectionChanged();
					_mode = ModeEnum.Moving;
					_prevSelectionRect = _selections.GetRectangle();
				}
				else
				{
					_mode = ModeEnum.Selecting;
				}
			}
			UpdateView();
		}

		void RemoveSelectedFromHost()
		{
			foreach (BaseWidget widget in _selections)
			{
				_model.Bands[widget.Row].Remove(widget);
			}
			RenderControls();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left)
			{
				switch (_mode)
				{
					case ModeEnum.Selecting:
						SelectWidgets();
						break;
					case ModeEnum.Moving:
						MoveWidgets();
						break;
				}
			}
			_mode = ModeEnum.Default;
			RenderControls();
		}
		#endregion

		#region appearance handlers
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			RenderBands(e.Graphics);
			RenderControls(e.Graphics);
		}
		#endregion

		#region layout handlers
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			try
			{
				hScrollBar1.LargeChange = MaxViewCols() - 1;
			}
			catch
			{
				hScrollBar1.LargeChange = 10;
			}
			CheckVerticalScolling();
			Invalidate();
		}
		#endregion


		void CheckVerticalScolling()
		{
			if ((BandCount * _charHeight) > (this.Height - bottomPanel.Height))
			{
				vScrollBar.Maximum = BandCount - 1;
				if (MaxViewRows() > 0)
				{
					vScrollBar.LargeChange = MaxViewRows() - 1;
				}
				vScrollBar.Visible = true;
			}
			else
			{
				vScrollBar.Visible = false;
				TopRow = 0;
			}
		}

		#region drag drop handlers
		protected override void OnDragDrop(DragEventArgs e)
		{
			base.OnDragDrop(e);
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				Point p = PointToDesignClient (PointToClient(new Point(e.X, e.Y)));
				_lastControl = e.Data.GetData(DataFormats.Text).ToString();
				InsertControl(_lastControl,p);
			}
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			//base.OnDragOver(e);
			Point pt = PointToDesignClient(PointToClient(new Point(e.X, e.Y)));
			UpdateStatus(pt.X, pt.Y);
			if (pt.X >= 0 && pt.Y < BandCount)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		#endregion

		private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			_left = e.NewValue;
			RenderControls();
		}

		private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{
			_top = e.NewValue;
			Invalidate();
		}

		void OnClipBoardChanged()
		{
			ClipBoardChanged(this, new ReportDesignerEventArgs(null, _clipboard.Count));
		}

		void OnSelectionChanged()
		{
			//if (_selections.Count > 0)
			//{
			//    SelectionChanged(this, new ReportDesignerEventArgs(_selections[0], _selections.Count));
			//}
			//else
			//{
			//    SelectionChanged(this, new ReportDesignerEventArgs());
			//}

			SelectionChanged(this, new ReportDesignerEventArgs(_selections.ToArray(), _selections.Count));
		}

	}
	
}
