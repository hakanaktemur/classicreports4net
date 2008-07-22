using System;
using System.Windows.Forms;

namespace JasonJimenez.ClassicReport
{
	partial class TemplateUIForm : Form
	{
		string schema="";

		public TemplateUIForm()
		{
			InitializeComponent();
		}
		
		public TemplateUIForm(string template) : this()
		{
			if (template.Trim() == "")
				template = reportDesigner1.GetSchema();
			schema = template;
			reportDesigner1.OpenSchema(schema);
		}
		
		public string Template
		{
			get { return schema; }
			set {schema = value; }
		}
		
		void OpenButtonClick(object sender, EventArgs e)
		{
			reportDesigner1.OpenReport();
		}
		
		void SaveButtonClick(object sender, EventArgs e)
		{
			schema = reportDesigner1.GetSchema();
			DialogResult = DialogResult.OK;
		}
	}
}
