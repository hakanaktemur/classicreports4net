/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 5/1/2007
 * Time: 5:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JasonJimenez.ClassicReport
{
	partial class ZoomPreviewControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoomPreviewControl));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.currentPageTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.pageCountLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.prevToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.printToolStripButton,
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
			this.toolStrip1.TabIndex = 4;
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
			this.prevToolStripButton.Click += new System.EventHandler(this.prevToolStripButton_Click);
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
			this.nextToolStripButton.Click += new System.EventHandler(this.nextToolStripButton_Click);
			// 
			// ZoomPreviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Name = "ZoomPreviewControl";
			this.Size = new System.Drawing.Size(350, 150);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
        }

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox currentPageTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel pageCountLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton prevToolStripButton;
        private System.Windows.Forms.ToolStripButton nextToolStripButton;
	}
}

