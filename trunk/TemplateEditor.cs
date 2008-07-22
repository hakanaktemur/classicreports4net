using System;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace JasonJimenez.ClassicReport
{
	class TemplateEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (service != null)
			{
				TemplateUIForm form;				
				string template;
				
				template = value as string;
				if (template == null || template.Trim() == "")
					form = new TemplateUIForm("");
				else
					form = new TemplateUIForm(template);
				if (service.ShowDialog(form) == DialogResult.OK)
					return form.Template;
			}
			return value;
		}

	}
}
