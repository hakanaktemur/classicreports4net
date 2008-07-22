/*
 * Author: jason d. jimenez
 * Date  : 12/8/2005
 * Time  : 3:14 PM
 * 
 */

using System;
using System.Collections.Generic;
using System.Xml;

namespace JasonJimenez.ClassicReport.Common.Collections
{
	/// <summary>
	/// Description of GroupCollection.
	/// </summary>
    internal class GroupList : List<Group>, IXmlWriter
	{
		public GroupList()
		{
		}
		
		~GroupList()
		{
			
		}

		public new void Add(Group group)
		{
			base.Add(group);
			group.Id = Count;
		}
		
		public new void Remove(Group group)
		{
			base.Remove(group);
			Reindex();
		}
		
		public void Load(List<Group> list)
		{
			foreach (Group group in list) 
			{
				Add(group);
			}
		}

		public void Reindex()
		{
			for(int i = 0; i <= Count - 1; i++)
			{
				this[i].Id = i + 1;
			}
		}

        public void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("groups");
            foreach (Group g in this)
            {
                g.WriteXml(writer);
            }
            writer.WriteEndElement();
        }
	}
}
