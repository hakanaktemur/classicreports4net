/*
 * User: Jason Jimenez
 * Date: 12/8/2005
 * Time: 8:53 AM
 * 
 */

using System;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common
{
	/// <summary>
	/// Description of Factory.
	/// </summary>
	class WidgetFactory
	{
		public static BaseWidget Create(System.Xml.XmlNode node)
		{
            switch (ReportReader.GetValue(node, "_type"))
            {
                case "0":
                    return new TextWidget(node);
                case "1":
                    return new ValueWidget(node);
                case "2":
                    return new HorizontalLineWidget(node);
                case "3":
                    return new FunctionWidget(node);
                default:
                    return null;
            }
		}

        public static BaseWidget Create(string name)
        {
            FunctionWidget widget;
            switch (name)
            {
                case "Text":
                    return new TextWidget(0);
                case "Field":
                    return new ValueWidget(0);
                case "Horizontal Line":
                    return new HorizontalLineWidget(0);
                case "DateTime":
                    widget = new FunctionWidget(0);
                    widget.Function = FunctionEnum.DateTime;
                    return widget;
                case "Page":
                    widget = new FunctionWidget(0);
                    widget.Function = FunctionEnum.PageEx;
                    return widget;
                default:
                    return null;
            }
        }
	}
}
