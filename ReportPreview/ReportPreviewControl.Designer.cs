namespace JasonJimenez.ClassicReport
{
    partial class ReportPreviewControl
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPreviewControl));
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.zoomToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.currentPageTextBox = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
        	this.pageCountLabel = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.prevToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
        	this.printDocument = new System.Drawing.Printing.PrintDocument();
        	this.printDialog = new System.Windows.Forms.PrintDialog();
        	this.toolStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.printToolStripButton,
        	        	        	this.zoomToolStripDropDownButton,
        	        	        	this.toolStripLabel1,
        	        	        	this.currentPageTextBox,
        	        	        	this.toolStripLabel2,
        	        	        	this.pageCountLabel,
        	        	        	this.toolStripSeparator1,
        	        	        	this.prevToolStripButton,
        	        	        	this.nextToolStripButton});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 125);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(350, 25);
        	this.toolStrip1.TabIndex = 3;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// printToolStripButton
        	// 
        	this.printToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
        	this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.printToolStripButton.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
        	this.printToolStripButton.Name = "printToolStripButton";
        	this.printToolStripButton.Size = new System.Drawing.Size(23, 25);
        	this.printToolStripButton.Text = "Print";
        	this.printToolStripButton.Click += new System.EventHandler(this.OnPrint);
        	// 
        	// zoomToolStripDropDownButton
        	// 
        	this.zoomToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.zoomToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.zoomToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripMenuItem2,
        	        	        	this.toolStripMenuItem3,
        	        	        	this.toolStripMenuItem4,
        	        	        	this.toolStripMenuItem5,
        	        	        	this.toolStripMenuItem6,
        	        	        	this.toolStripMenuItem7,
        	        	        	this.toolStripMenuItem8,
        	        	        	this.toolStripMenuItem9,
        	        	        	this.toolStripMenuItem10,
        	        	        	this.toolStripMenuItem11});
        	this.zoomToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomToolStripDropDownButton.Image")));
        	this.zoomToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.zoomToolStripDropDownButton.Margin = new System.Windows.Forms.Padding(0);
        	this.zoomToolStripDropDownButton.Name = "zoomToolStripDropDownButton";
        	this.zoomToolStripDropDownButton.ShowDropDownArrow = false;
        	this.zoomToolStripDropDownButton.Size = new System.Drawing.Size(20, 25);
        	this.zoomToolStripDropDownButton.Text = "Zoom";
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem2.Tag = "1";
        	this.toolStripMenuItem2.Text = "100%";
        	this.toolStripMenuItem2.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem3
        	// 
        	this.toolStripMenuItem3.Name = "toolStripMenuItem3";
        	this.toolStripMenuItem3.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem3.Tag = ".9";
        	this.toolStripMenuItem3.Text = "90%";
        	this.toolStripMenuItem3.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem4
        	// 
        	this.toolStripMenuItem4.Name = "toolStripMenuItem4";
        	this.toolStripMenuItem4.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem4.Tag = ".8";
        	this.toolStripMenuItem4.Text = "80%";
        	this.toolStripMenuItem4.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem5
        	// 
        	this.toolStripMenuItem5.Name = "toolStripMenuItem5";
        	this.toolStripMenuItem5.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem5.Tag = ".7";
        	this.toolStripMenuItem5.Text = "70%";
        	this.toolStripMenuItem5.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem6
        	// 
        	this.toolStripMenuItem6.Name = "toolStripMenuItem6";
        	this.toolStripMenuItem6.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem6.Tag = ".6";
        	this.toolStripMenuItem6.Text = "60%";
        	this.toolStripMenuItem6.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem7
        	// 
        	this.toolStripMenuItem7.Name = "toolStripMenuItem7";
        	this.toolStripMenuItem7.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem7.Tag = ".5";
        	this.toolStripMenuItem7.Text = "50%";
        	this.toolStripMenuItem7.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem8
        	// 
        	this.toolStripMenuItem8.Name = "toolStripMenuItem8";
        	this.toolStripMenuItem8.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem8.Tag = ".4";
        	this.toolStripMenuItem8.Text = "40%";
        	this.toolStripMenuItem8.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem9
        	// 
        	this.toolStripMenuItem9.Name = "toolStripMenuItem9";
        	this.toolStripMenuItem9.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem9.Tag = ".3";
        	this.toolStripMenuItem9.Text = "30%";
        	this.toolStripMenuItem9.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem10
        	// 
        	this.toolStripMenuItem10.Name = "toolStripMenuItem10";
        	this.toolStripMenuItem10.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem10.Tag = ".2";
        	this.toolStripMenuItem10.Text = "20%";
        	this.toolStripMenuItem10.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripMenuItem11
        	// 
        	this.toolStripMenuItem11.Name = "toolStripMenuItem11";
        	this.toolStripMenuItem11.Size = new System.Drawing.Size(114, 22);
        	this.toolStripMenuItem11.Tag = ".1";
        	this.toolStripMenuItem11.Text = "10%";
        	this.toolStripMenuItem11.Click += new System.EventHandler(this.OnZoom);
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(34, 25);
        	this.toolStripLabel1.Text = "Page";
        	// 
        	// currentPageTextBox
        	// 
        	this.currentPageTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.currentPageTextBox.Margin = new System.Windows.Forms.Padding(0);
        	this.currentPageTextBox.Name = "currentPageTextBox";
        	this.currentPageTextBox.Size = new System.Drawing.Size(40, 25);
        	this.currentPageTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.currentPageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentPageTextBoxKeyDown);
        	this.currentPageTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CurrentPageTextBoxValidating);
        	this.currentPageTextBox.Click += new System.EventHandler(this.CurrentPageTextBoxClick);
        	// 
        	// toolStripLabel2
        	// 
        	this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
        	this.toolStripLabel2.Name = "toolStripLabel2";
        	this.toolStripLabel2.Size = new System.Drawing.Size(18, 25);
        	this.toolStripLabel2.Text = "of";
        	// 
        	// pageCountLabel
        	// 
        	this.pageCountLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.pageCountLabel.Margin = new System.Windows.Forms.Padding(0);
        	this.pageCountLabel.Name = "pageCountLabel";
        	this.pageCountLabel.Size = new System.Drawing.Size(14, 25);
        	this.pageCountLabel.Text = "1";
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// prevToolStripButton
        	// 
        	this.prevToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.prevToolStripButton.Enabled = false;
        	this.prevToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("prevToolStripButton.Image")));
        	this.prevToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.prevToolStripButton.Margin = new System.Windows.Forms.Padding(0);
        	this.prevToolStripButton.Name = "prevToolStripButton";
        	this.prevToolStripButton.Size = new System.Drawing.Size(23, 25);
        	this.prevToolStripButton.Text = "Previous";
        	this.prevToolStripButton.Click += new System.EventHandler(this.OnPreviousPage);
        	// 
        	// nextToolStripButton
        	// 
        	this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.nextToolStripButton.Enabled = false;
        	this.nextToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nextToolStripButton.Image")));
        	this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.nextToolStripButton.Margin = new System.Windows.Forms.Padding(0);
        	this.nextToolStripButton.Name = "nextToolStripButton";
        	this.nextToolStripButton.Size = new System.Drawing.Size(23, 25);
        	this.nextToolStripButton.Text = "Next";
        	this.nextToolStripButton.Click += new System.EventHandler(this.OnNextPage);
        	// 
        	// printPreviewControl1
        	// 
        	this.printPreviewControl1.AutoZoom = false;
        	this.printPreviewControl1.BackColor = System.Drawing.SystemColors.ControlLight;
        	this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.printPreviewControl1.Document = this.printDocument;
        	this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
        	this.printPreviewControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.printPreviewControl1.Name = "printPreviewControl1";
        	this.printPreviewControl1.Size = new System.Drawing.Size(350, 125);
        	this.printPreviewControl1.TabIndex = 4;
        	this.printPreviewControl1.Zoom = 0.7;
        	this.printPreviewControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PrintPreviewControl1PreviewKeyDown);
        	// 
        	// printDocument
        	// 
        	this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.OnPrintPage);
        	// 
        	// printDialog
        	// 
        	this.printDialog.AllowCurrentPage = true;
        	this.printDialog.AllowPrintToFile = false;
        	this.printDialog.AllowSomePages = true;
        	this.printDialog.Document = this.printDocument;
        	// 
        	// ReportPreviewControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.printPreviewControl1);
        	this.Controls.Add(this.toolStrip1);
        	this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.Name = "ReportPreviewControl";
        	this.Size = new System.Drawing.Size(350, 150);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripTextBox currentPageTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel pageCountLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PrintDialog printDialog;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton zoomToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.ToolStripButton prevToolStripButton;
        private System.Windows.Forms.ToolStripButton nextToolStripButton;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}
