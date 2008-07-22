using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using Divelements.Navisight;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport
{
	/// <summary>
	/// A banded report writer.
	/// </summary>
	public partial class ReportDesigner : UserControl
	{
		
		NavigationButton hilitedButton = null;
		bool isAltPressed;
		bool isReportContext = false;
		
		/// <summary>
		/// 
		/// </summary>
		public ReportDesigner()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Return the layout of the report in XML format.
		/// </summary>
		/// <returns></returns>
		public string GetSchema()
		{
			return designPanel.ToXml();
		}

		/// <summary>
		/// Create a new report.
		/// </summary>
		public void NewReport()
		{
			_fileName = "";
			designPanel.Clear();
			ShowGroups();
			ShowAttributes();
		}

		/// <summary>
		/// Edit an existing report.
		/// </summary>
		public void OpenReport()
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string path = openFileDialog.FileName;
				OpenReport(path);
			}
		}
		
		
		string _fileName = "";
		public string FileName
		{
			get {return _fileName;}
		}
		
		
		public void OpenReport(string fileName)
		{
			_fileName = fileName;
			designPanel.OpenReport(fileName);
			ShowGroups();
			ShowAttributes();
		}
		
		public void OpenSchema(string schema)
		{
			designPanel.OpenSchema(schema);
			ShowGroups();
			ShowAttributes();
		}

		/// <summary>
		/// Persist the report to disk.
		/// </summary>
		public void SaveAs()
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string path = saveFileDialog.FileName;
				Save(path);
			}
		}
		
		public void Save()
		{
			if (_fileName == "")
				SaveAs();
			else
				Save(_fileName);
		}
		
		public void Save(string fileName)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(designPanel.ToXml());
			doc.Save(fileName);
		}

		private void ShowGroups()
		{
			groupListBox.Items.Clear();
			foreach (Group group in designPanel.ReportSchema.Groups)
			{
				groupListBox.Items.Add(group);
			}
		}

		private void toolboxBar_MouseDown(object sender, MouseEventArgs e)
		{
			if (hilitedButton != null)
			{
				toolboxBar.DoDragDrop(hilitedButton.Text, DragDropEffects.Copy);
			}
		}

		private void toolboxBar_MouseMove(object sender, MouseEventArgs e)
		{
			hilitedButton = toolboxBar.GetButtonAt(new Point(e.X, e.Y));
		}

		private void designPanel_KeyDown(object sender, KeyEventArgs e)
		{
			isAltPressed = e.Alt;
		}

		private void designPanel_KeyUp(object sender, KeyEventArgs e)
		{
			isAltPressed = false;
		}

		private void designPanel_Click(object sender, EventArgs e)
		{
			string lastControl = designPanel.LastControl();
			if (isAltPressed && lastControl!="")
			{
				designPanel.InsertControl(lastControl);
			}
		}

		private void designPanel_ClipBoardChanged(object sender, ReportDesignerEventArgs e)
		{
			pasteToolStripButton.Enabled = e.Count > 0;
		}

		private void designPanel_SelectionChanged(object sender, ReportDesignerEventArgs e)
		{
			bool flag = e.Count > 0;
			cutToolStripButton.Enabled = flag;
			copyToolStripButton.Enabled = flag;
			if (e.Count > 0)
			{
				this.propertyGrid.SelectedObjects = e.Widget;
			}
			//else if (e.Count == 1)
			//{
			//    this.propertyGrid.SelectedObject = e.Widget;
			//}
			else
			{
				this.propertyGrid.SelectedObject = null;
			}
			isReportContext = false;
		}

		private void cutToolStripButton_Click(object sender, EventArgs e)
		{
			designPanel.CutWidgets();
		}

		private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (!isReportContext)
			{
				this.designPanel.SetValue(e.ChangedItem.Label, e.ChangedItem.Value);
			}
			this.designPanel.Invalidate();
			ShowGroups();
		}

		private void copyToolStripButton_Click(object sender, EventArgs e)
		{
			designPanel.CopyWidgets();
		}

		private void pasteToolStripButton_Click(object sender, EventArgs e)
		{
			designPanel.PasteWidgets();
		}

		private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowGroupProperty();
		}

		private void addGroupToolStripButton_Click(object sender, EventArgs e)
		{
			int count = designPanel.ReportSchema.Groups.Count;
			Group group = new Group("Group"+count.ToString());
			designPanel.AddGroup(group);
			//designPanel.Invalidate();
			ShowGroups();
		}

		private void delgroupToolStripButton_Click(object sender, EventArgs e)
		{
			Group group = groupListBox.SelectedItem as Group;
			if (group != null)
			{
				this.propertyGrid.SelectedObject = null;
				designPanel.RemoveGroup(group);
				//designPanel.Invalidate();
				ShowGroups();
			}
		}

		private void layoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAttributes();
		}

		void ShowAttributes()
		{
			propertyGrid.SelectedObject = designPanel.ReportSchema;
			isReportContext = true;
		}

		void ShowGroupProperty()
		{
			propertyGrid.SelectedObject = groupListBox.SelectedItem;
			isReportContext = true;
		}

		private void layoutToolStripButton_Click(object sender, EventArgs e)
		{
			ShowAttributes();
		}

	}
}
