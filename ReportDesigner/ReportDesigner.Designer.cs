namespace JasonJimenez.ClassicReport
{
    partial class ReportDesigner
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDesigner));
        	this.propertyGrid = new System.Windows.Forms.PropertyGrid();
        	this.toolboxBar = new Divelements.Navisight.ButtonBar();
        	this.textControlButton = new Divelements.Navisight.NavigationButton();
        	this.fieldControlButton = new Divelements.Navisight.NavigationButton();
        	this.lineControlButton = new Divelements.Navisight.NavigationButton();
        	this.datetimeControlButton = new Divelements.Navisight.NavigationButton();
        	this.pageControlButton = new Divelements.Navisight.NavigationButton();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStrip3 = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
        	this.layoutToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStrip2 = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        	this.toolStrip4 = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
        	this.addGroupToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.delgroupToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.groupListBox = new System.Windows.Forms.ListBox();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        	this.designPanel = new JasonJimenez.ClassicReport.ReportDesignerPanel();
        	this.splitContainer3 = new System.Windows.Forms.SplitContainer();
        	this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
        	this.toolStrip1.SuspendLayout();
        	this.toolStrip3.SuspendLayout();
        	this.toolStrip2.SuspendLayout();
        	this.toolStrip4.SuspendLayout();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.splitContainer2.Panel1.SuspendLayout();
        	this.splitContainer2.Panel2.SuspendLayout();
        	this.splitContainer2.SuspendLayout();
        	this.splitContainer3.Panel1.SuspendLayout();
        	this.splitContainer3.Panel2.SuspendLayout();
        	this.splitContainer3.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// propertyGrid
        	// 
        	this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.propertyGrid.Location = new System.Drawing.Point(0, 25);
        	this.propertyGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.propertyGrid.Name = "propertyGrid";
        	this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
        	this.propertyGrid.Size = new System.Drawing.Size(139, 121);
        	this.propertyGrid.TabIndex = 0;
        	this.propertyGrid.UseCompatibleTextRendering = true;
        	this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
        	// 
        	// toolboxBar
        	// 
        	this.toolboxBar.AutoScrollMinSize = new System.Drawing.Size(0, 107);
        	this.toolboxBar.Buttons.AddRange(new Divelements.Navisight.NavigationButton[] {
        	        	        	this.textControlButton,
        	        	        	this.fieldControlButton,
        	        	        	this.lineControlButton,
        	        	        	this.datetimeControlButton,
        	        	        	this.pageControlButton});
        	this.toolboxBar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toolboxBar.Location = new System.Drawing.Point(0, 25);
        	this.toolboxBar.Name = "toolboxBar";
        	this.toolboxBar.Size = new System.Drawing.Size(139, 163);
        	this.toolboxBar.TabIndex = 0;
        	this.toolboxBar.TextAlignment = Divelements.Navisight.ButtonTextAlignment.Side;
        	this.toolboxBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolboxBar_MouseDown);
        	this.toolboxBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolboxBar_MouseMove);
        	// 
        	// textControlButton
        	// 
        	this.textControlButton.Image = ((System.Drawing.Image)(resources.GetObject("textControlButton.Image")));
        	this.textControlButton.Text = "Text";
        	// 
        	// fieldControlButton
        	// 
        	this.fieldControlButton.Image = ((System.Drawing.Image)(resources.GetObject("fieldControlButton.Image")));
        	this.fieldControlButton.Text = "Field";
        	// 
        	// lineControlButton
        	// 
        	this.lineControlButton.Image = ((System.Drawing.Image)(resources.GetObject("lineControlButton.Image")));
        	this.lineControlButton.Text = "Horizontal Line";
        	// 
        	// datetimeControlButton
        	// 
        	this.datetimeControlButton.Image = ((System.Drawing.Image)(resources.GetObject("datetimeControlButton.Image")));
        	this.datetimeControlButton.Text = "DateTime";
        	// 
        	// pageControlButton
        	// 
        	this.pageControlButton.Image = ((System.Drawing.Image)(resources.GetObject("pageControlButton.Image")));
        	this.pageControlButton.Text = "Page";
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cutToolStripButton,
        	        	        	this.copyToolStripButton,
        	        	        	this.pasteToolStripButton});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(313, 25);
        	this.toolStrip1.TabIndex = 2;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// cutToolStripButton
        	// 
        	this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.cutToolStripButton.Enabled = false;
        	this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
        	this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.cutToolStripButton.Name = "cutToolStripButton";
        	this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.cutToolStripButton.Text = "C&ut";
        	this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripButton_Click);
        	// 
        	// copyToolStripButton
        	// 
        	this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.copyToolStripButton.Enabled = false;
        	this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
        	this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.copyToolStripButton.Name = "copyToolStripButton";
        	this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.copyToolStripButton.Text = "&Copy";
        	this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripButton_Click);
        	// 
        	// pasteToolStripButton
        	// 
        	this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.pasteToolStripButton.Enabled = false;
        	this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
        	this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.pasteToolStripButton.Name = "pasteToolStripButton";
        	this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.pasteToolStripButton.Text = "&Paste";
        	this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripButton_Click);
        	// 
        	// toolStrip3
        	// 
        	this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabel2,
        	        	        	this.layoutToolStripButton});
        	this.toolStrip3.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip3.Name = "toolStrip3";
        	this.toolStrip3.Size = new System.Drawing.Size(139, 25);
        	this.toolStrip3.TabIndex = 1;
        	this.toolStrip3.Text = "toolStrip3";
        	// 
        	// toolStripLabel2
        	// 
        	this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
        	this.toolStripLabel2.Name = "toolStripLabel2";
        	this.toolStripLabel2.Size = new System.Drawing.Size(69, 22);
        	this.toolStripLabel2.Text = " Properties";
        	// 
        	// layoutToolStripButton
        	// 
        	this.layoutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.layoutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.layoutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("layoutToolStripButton.Image")));
        	this.layoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.layoutToolStripButton.Name = "layoutToolStripButton";
        	this.layoutToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.layoutToolStripButton.Text = "Report Layout";
        	this.layoutToolStripButton.Click += new System.EventHandler(this.layoutToolStripButton_Click);
        	// 
        	// toolStrip2
        	// 
        	this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabel1});
        	this.toolStrip2.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip2.Name = "toolStrip2";
        	this.toolStrip2.Size = new System.Drawing.Size(139, 25);
        	this.toolStrip2.TabIndex = 1;
        	this.toolStrip2.Text = "toolStrip2";
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
        	this.toolStripLabel1.Text = " Toolbox";
        	// 
        	// saveFileDialog
        	// 
        	this.saveFileDialog.DefaultExt = "xml";
        	this.saveFileDialog.Filter = "Report Files|*.xml";
        	// 
        	// openFileDialog
        	// 
        	this.openFileDialog.DefaultExt = "xml";
        	this.openFileDialog.Filter = "Report Files|*.xml";
        	// 
        	// toolStrip4
        	// 
        	this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabel3,
        	        	        	this.addGroupToolStripButton,
        	        	        	this.delgroupToolStripButton});
        	this.toolStrip4.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip4.Name = "toolStrip4";
        	this.toolStrip4.Size = new System.Drawing.Size(313, 25);
        	this.toolStrip4.TabIndex = 1;
        	this.toolStrip4.Text = "toolStrip4";
        	// 
        	// toolStripLabel3
        	// 
        	this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
        	this.toolStripLabel3.Name = "toolStripLabel3";
        	this.toolStripLabel3.Size = new System.Drawing.Size(54, 22);
        	this.toolStripLabel3.Text = "Groups:";
        	// 
        	// addGroupToolStripButton
        	// 
        	this.addGroupToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.addGroupToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addGroupToolStripButton.Image")));
        	this.addGroupToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.addGroupToolStripButton.Name = "addGroupToolStripButton";
        	this.addGroupToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.addGroupToolStripButton.Text = "Add group";
        	this.addGroupToolStripButton.Click += new System.EventHandler(this.addGroupToolStripButton_Click);
        	// 
        	// delgroupToolStripButton
        	// 
        	this.delgroupToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.delgroupToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("delgroupToolStripButton.Image")));
        	this.delgroupToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.delgroupToolStripButton.Name = "delgroupToolStripButton";
        	this.delgroupToolStripButton.Size = new System.Drawing.Size(23, 22);
        	this.delgroupToolStripButton.Text = "Delete group";
        	this.delgroupToolStripButton.Click += new System.EventHandler(this.delgroupToolStripButton_Click);
        	// 
        	// groupListBox
        	// 
        	this.groupListBox.BackColor = System.Drawing.SystemColors.Control;
        	this.groupListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.groupListBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupListBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.groupListBox.FormattingEnabled = true;
        	this.groupListBox.ItemHeight = 16;
        	this.groupListBox.Location = new System.Drawing.Point(0, 25);
        	this.groupListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.groupListBox.Name = "groupListBox";
        	this.groupListBox.Size = new System.Drawing.Size(313, 48);
        	this.groupListBox.TabIndex = 2;
        	this.groupListBox.SelectedIndexChanged += new System.EventHandler(this.groupListBox_SelectedIndexChanged);
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
        	this.splitContainer1.Size = new System.Drawing.Size(456, 338);
        	this.splitContainer1.SplitterDistance = 313;
        	this.splitContainer1.TabIndex = 3;
        	// 
        	// splitContainer2
        	// 
        	this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer2.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.splitContainer2.Name = "splitContainer2";
        	this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer2.Panel1
        	// 
        	this.splitContainer2.Panel1.Controls.Add(this.designPanel);
        	this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
        	// 
        	// splitContainer2.Panel2
        	// 
        	this.splitContainer2.Panel2.Controls.Add(this.groupListBox);
        	this.splitContainer2.Panel2.Controls.Add(this.toolStrip4);
        	this.splitContainer2.Size = new System.Drawing.Size(313, 338);
        	this.splitContainer2.SplitterDistance = 257;
        	this.splitContainer2.TabIndex = 4;
        	// 
        	// designPanel
        	// 
        	this.designPanel.AllowDrop = true;
        	this.designPanel.BackColor = System.Drawing.SystemColors.Window;
        	this.designPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.designPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.designPanel.Location = new System.Drawing.Point(0, 25);
        	this.designPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.designPanel.Name = "designPanel";
        	this.designPanel.Size = new System.Drawing.Size(313, 232);
        	this.designPanel.TabIndex = 3;
        	this.designPanel.Click += new System.EventHandler(this.designPanel_Click);
        	this.designPanel.SelectionChanged += new JasonJimenez.ClassicReport.Common.ReportDesignerEventHandler(this.designPanel_SelectionChanged);
        	this.designPanel.ClipBoardChanged += new JasonJimenez.ClassicReport.Common.ReportDesignerEventHandler(this.designPanel_ClipBoardChanged);
        	this.designPanel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.designPanel_KeyUp);
        	this.designPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.designPanel_KeyDown);
        	// 
        	// splitContainer3
        	// 
        	this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer3.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.splitContainer3.Name = "splitContainer3";
        	this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer3.Panel1
        	// 
        	this.splitContainer3.Panel1.Controls.Add(this.propertyGrid);
        	this.splitContainer3.Panel1.Controls.Add(this.toolStrip3);
        	// 
        	// splitContainer3.Panel2
        	// 
        	this.splitContainer3.Panel2.Controls.Add(this.toolboxBar);
        	this.splitContainer3.Panel2.Controls.Add(this.toolStrip2);
        	this.splitContainer3.Size = new System.Drawing.Size(139, 338);
        	this.splitContainer3.SplitterDistance = 146;
        	this.splitContainer3.TabIndex = 5;
        	// 
        	// ReportDesigner
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer1);
        	this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.Name = "ReportDesigner";
        	this.Size = new System.Drawing.Size(456, 338);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.toolStrip3.ResumeLayout(false);
        	this.toolStrip3.PerformLayout();
        	this.toolStrip2.ResumeLayout(false);
        	this.toolStrip2.PerformLayout();
        	this.toolStrip4.ResumeLayout(false);
        	this.toolStrip4.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.ResumeLayout(false);
        	this.splitContainer2.Panel1.ResumeLayout(false);
        	this.splitContainer2.Panel1.PerformLayout();
        	this.splitContainer2.Panel2.ResumeLayout(false);
        	this.splitContainer2.Panel2.PerformLayout();
        	this.splitContainer2.ResumeLayout(false);
        	this.splitContainer3.Panel1.ResumeLayout(false);
        	this.splitContainer3.Panel1.PerformLayout();
        	this.splitContainer3.Panel2.ResumeLayout(false);
        	this.splitContainer3.Panel2.PerformLayout();
        	this.splitContainer3.ResumeLayout(false);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private Divelements.Navisight.ButtonBar toolboxBar;
        private Divelements.Navisight.NavigationButton textControlButton;
        private Divelements.Navisight.NavigationButton fieldControlButton;
        private Divelements.Navisight.NavigationButton lineControlButton;
        private Divelements.Navisight.NavigationButton datetimeControlButton;
        private Divelements.Navisight.NavigationButton pageControlButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private ReportDesignerPanel designPanel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ListBox groupListBox;
        private System.Windows.Forms.ToolStripButton addGroupToolStripButton;
        private System.Windows.Forms.ToolStripButton delgroupToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton layoutToolStripButton;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}
