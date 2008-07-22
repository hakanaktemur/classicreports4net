namespace JasonJimenez.ClassicReport
{
    partial class ReportDesignerPanel
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
        	this.bottomPanel = new System.Windows.Forms.Panel();
        	this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
        	this.label1 = new System.Windows.Forms.Label();
        	this.vScrollBar = new System.Windows.Forms.VScrollBar();
        	this.bottomPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.BackColor = System.Drawing.SystemColors.Window;
        	this.bottomPanel.Controls.Add(this.hScrollBar1);
        	this.bottomPanel.Controls.Add(this.label1);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.Location = new System.Drawing.Point(0, 213);
        	this.bottomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.Size = new System.Drawing.Size(287, 17);
        	this.bottomPanel.TabIndex = 2;
        	// 
        	// hScrollBar1
        	// 
        	this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.hScrollBar1.Location = new System.Drawing.Point(110, 0);
        	this.hScrollBar1.Name = "hScrollBar1";
        	this.hScrollBar1.Size = new System.Drawing.Size(177, 17);
        	this.hScrollBar1.TabIndex = 0;
        	this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
        	// 
        	// label1
        	// 
        	this.label1.Dock = System.Windows.Forms.DockStyle.Left;
        	this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(0, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(110, 17);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "0, 0";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// vScrollBar
        	// 
        	this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
        	this.vScrollBar.LargeChange = 1;
        	this.vScrollBar.Location = new System.Drawing.Point(270, 0);
        	this.vScrollBar.Name = "vScrollBar";
        	this.vScrollBar.Size = new System.Drawing.Size(17, 213);
        	this.vScrollBar.TabIndex = 3;
        	this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
        	// 
        	// ReportDesignerPanel
        	// 
        	this.AllowDrop = true;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.Window;
        	this.Controls.Add(this.vScrollBar);
        	this.Controls.Add(this.bottomPanel);
        	this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.Name = "ReportDesignerPanel";
        	this.Size = new System.Drawing.Size(287, 230);
        	this.bottomPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar;
    }
}
