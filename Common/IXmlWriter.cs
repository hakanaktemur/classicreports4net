using System.Xml;

namespace JasonJimenez.ClassicReport.Common
{
    interface IXmlWriter
    {
        void WriteXml(XmlTextWriter writer);
    }
}
