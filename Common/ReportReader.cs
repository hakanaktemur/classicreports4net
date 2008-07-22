/*
 * Author: Jason Jimenez
 * Date  : 12/8/2005
 * Time  : 6:01 AM
 * 
 */

using System;
using System.Collections.Generic;
using System.Xml;
using JasonJimenez.ClassicReport.Common.Widgets;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport.Common
{
	class ReportReader
	{
		XmlDocument doc = new XmlDocument();
		
		public static string GetValue(XmlNode node, string key)
        {
            foreach (XmlElement element in node)
            {
                if (key == element.Name)
                {
                    return element.InnerText;
                }
            }
            return "";
        }

        public bool IsMasterDetail()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            bool retval;
            try
            {
                retval = Convert.ToBoolean(GetValue(nodes[0], "master"));
            }
            catch
            {
                retval = false;
            }
            return retval;
        }

        public bool hasSubFooter()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            bool retval;
            try
            {
                retval = Convert.ToBoolean(GetValue(nodes[0], "subfooter"));
            }
            catch
            {
                retval = false;
            }
            return retval;
        }

        public string GetMasterTable()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            string retVal;
            try
            {
                retVal = GetValue(nodes[0], "mastertable").ToString();
            }
            catch
            {
                retVal = "";
            }
            return retVal;
        }

        public string GetDetailTable()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            string retVal;
            try
            {
                retVal = GetValue(nodes[0], "detailtable").ToString();
            }
            catch
            {
                retVal = "";
            }
            return retVal;
        }

        public int GetPaperWidth()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            try
            {
                return int.Parse(GetValue(nodes[0], "paperwidth"));
            }
            catch
            {
                return 850;
            }
        }

        public int GetPaperHeight()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            try
            {
                return int.Parse(GetValue(nodes[0], "paperheight"));
            }
            catch
            {
                return 1150;
            }
        }


        public bool ShowHeader()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            return Convert.ToBoolean(GetValue(nodes[0], "header"));
        }

        public bool ShowFooter()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            return Convert.ToBoolean(GetValue(nodes[0], "footer"));
        }
		
		public bool ShowSummary()
		{			
			XmlNodeList nodes = doc.GetElementsByTagName("attributes");
			return Convert.ToBoolean(GetValue(nodes[0], "summary"));
		}

        public CPIEnum GetCpi()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            return (CPIEnum) Enum.Parse(typeof(CPIEnum),GetValue(nodes[0],"cpi"));
        }

       
        public int GetHeight()
		{			
			XmlNodeList nodes = doc.GetElementsByTagName("attributes");
			return Convert.ToInt32(GetValue(nodes[0], "height"));
		}
		
		public int GetWidth()
		{			
			XmlNodeList nodes = doc.GetElementsByTagName("attributes");
			return Convert.ToInt32(GetValue(nodes[0], "width"));
		}

        public string GetName()
        {
            XmlNodeList nodes = doc.GetElementsByTagName("attributes");
            return GetValue(nodes[0], "name");
        }
		
		public List<Group> GetGroups()
		{
			List<Group> list = new List<Group>();
			foreach (XmlNode  node in doc.GetElementsByTagName("group"))
			{
				list.Add(new Group(node));
			}
			return list;
		}
		
		public List<Band> GetBands()
		{
			List<Band> list = new List<Band>();
			foreach (XmlNode node in doc.GetElementsByTagName("band")) 
			{
				list.Add(new Band(node));
			}
			return list;
		}
		
		public List<BaseWidget> GetWidgets()
		{			
			List<BaseWidget> list = new List<BaseWidget>();
			foreach (XmlNode node in doc.GetElementsByTagName("widget")) 
            {				
                list.Add(WidgetFactory.Create(node));	
			}
			return list;
		}
		
		public void LoadFile(string filename)
		{
			doc.Load(filename);
		}
		
		public void LoadSchema(string schema)
		{
			doc.LoadXml(schema);
		}
        
	}
}
