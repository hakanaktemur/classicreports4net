namespace JasonJimenez.ClassicReport
{
    partial class TemplateUIForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateUIForm));
        	this.saveButon = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.openButton = new System.Windows.Forms.Button();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.reportDesigner1 = new JasonJimenez.ClassicReport.ReportDesigner();
        	this.panel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// saveButon
        	// 
        	this.saveButon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.saveButon.Image = ((System.Drawing.Image)(resources.GetObject("saveButon.Image")));
        	this.saveButon.Location = new System.Drawing.Point(83, 8);
        	this.saveButon.Name = "saveButon";
        	this.saveButon.Size = new System.Drawing.Size(64, 32);
        	this.saveButon.TabIndex = 1;
        	this.toolTip1.SetToolTip(this.saveButon, "Save");
        	this.saveButon.UseVisualStyleBackColor = true;
        	this.saveButon.Click += new System.EventHandler(this.SaveButtonClick);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.openButton);
        	this.panel1.Controls.Add(this.saveButon);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(719, 48);
        	this.panel1.TabIndex = 4;
        	// 
        	// openButton
        	// 
        	this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
        	this.openButton.Location = new System.Drawing.Point(12, 8);
        	this.openButton.Name = "openButton";
        	this.openButton.Size = new System.Drawing.Size(65, 32);
        	this.openButton.TabIndex = 0;
        	this.toolTip1.SetToolTip(this.openButton, "Open");
        	this.openButton.UseVisualStyleBackColor = true;
        	this.openButton.Click += new System.EventHandler(this.OpenButtonClick);
        	// 
        	// reportDesigner1
        	// 
        	this.reportDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reportDesigner1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.reportDesigner1.Location = new System.Drawing.Point(0, 48);
        	this.reportDesigner1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        	this.reportDesigner1.Name = "reportDesigner1";
        	this.reportDesigner1.Size = new System.Drawing.Size(719, 351);
        	this.reportDesigner1.TabIndex = 5;
        	// 
        	// TemplateUIForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(719, 399);
        	this.Controls.Add(this.reportDesigner1);
        	this.Controls.Add(this.panel1);
        	this.MinimizeBox = false;
        	this.Name = "TemplateUIForm";
        	this.Text = "ClassicReport Editor";
        	this.panel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButon;

        #endregion

        private ReportDesigner reportDesigner1;
        private System.Windows.Forms.Panel panel1;
    }
}
