/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 12/8/2005
 * Time: 6:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using JasonJimenez.ClassicReport.Common.Widgets;

namespace JasonJimenez.ClassicReport.Common.Collections
{
    internal class ControlList : List<BaseWidget>, IXmlWriter
	{
		public ControlList()
		{		
		}
			
		~ControlList()
		{
			Clear();
		}
	
		public void Reindex(int row)
		{
			foreach (BaseWidget control in this) 
			{
				control.Row = row;
			}
		}
		
		public void WriteXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("widgets");
			foreach (BaseWidget w in this) 
			{
				w.WriteXml(writer);
			}
			writer.WriteEndElement();
		}

        internal List<BaseWidget> FindAll(Type type)
        {
            return base.FindAll(delegate(BaseWidget widget) {return widget.GetType() == type;});
        }
		
	}

}
