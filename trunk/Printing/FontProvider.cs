using System;
using System.Drawing;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport.Printing
{
	class FontProvider
	{
        const string fontname = "Courier New";
        
		public static Font GetFont(CPIEnum cpi)
		{           
			System.Drawing.Font font = new Font(fontname, 12, FontStyle.Regular, GraphicsUnit.Point);
			switch (cpi)
			{
				case CPIEnum.Default:
					//float em = (1 / pageWidth) * previewWidth;
					//font = new Font("courier new", em, FontStyle.Regular, GraphicsUnit.Point);
					//break;
				case CPIEnum._10cpi:
                    font = new Font(fontname, 12F, FontStyle.Regular, GraphicsUnit.Point);
					break;
				case CPIEnum._12cpi:
                    font = new Font(fontname, 10F, FontStyle.Regular, GraphicsUnit.Point);
					break;
				case CPIEnum._15cpi:
                    font = new Font(fontname, 8F, FontStyle.Regular, GraphicsUnit.Point);
					break;
				case CPIEnum._17cpi:
                    font = new Font(fontname, 7F, FontStyle.Regular, GraphicsUnit.Point);
					break;
				case CPIEnum._20cpi:
                    font = new Font(fontname, 6F, FontStyle.Regular, GraphicsUnit.Point);
					break;
			}
			return font;
		}

	}
}
