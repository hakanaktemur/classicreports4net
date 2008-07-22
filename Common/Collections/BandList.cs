/*
 * User: Jason D. Jimenez
 * Date: 12/8/2005
 * Time: 2:34 PM
 */

using System;
using System.Collections.Generic;
using System.Xml;
using JasonJimenez.ClassicReport.Common;

namespace JasonJimenez.ClassicReport.Common.Collections
{
	/// <summary>
	/// Description of BandCollection.
	/// </summary>
	internal class BandList : List<Band>, IXmlWriter
	{
 		public BandList()
		{
		}
		
		~BandList()
		{
			Clear();
		}

        public List<Band> FindAll(BandEnum bandType)
        {
            return base.FindAll(delegate(Band band) { return band.BandType == bandType; });
        }

        public List<Band> FindGroupBand(BandEnum bandType, int groupId)
        {
            return FindAll(bandType).FindAll(delegate(Band band) { return band.GroupId == groupId; });
        }
		
		public new void Add(Band band)
		{
			band.Row = Count;
			base.Add(band);
		}

   		public void Add(Group group)
		{
			// insert group header
			for(int row = 0; row < Count; row++)
			{
				if (this[row].BandType == BandEnum.PageDetailBand)
				{
					Insert(row, new Band(BandEnum.GroupHeaderBand, group));
					break;
				}
			}
			// insert group footer
			for(int row = Count - 1; row >= 0; row--)
			{
                Band b = this[row];
                if (b.BandType == BandEnum.PageDetailBand)
                {
                    Insert(row + 1, new Band(BandEnum.GroupFooterBand, group));
                    break;// might not be correct. Was : Exit For
                }
			}
			Reindex();
		}

		public void Insert(int Row)
		{
			if (Row < Count)
			{
				Insert(Row, new Band(this[Row].BandType, this[Row].Group));
				Reindex();
			}
		}

		public void Remove(Group group)
		{			
            RemoveAll(delegate(Band b) { return b.BandType == BandEnum.GroupHeaderBand && b.Group.ColumnName == group.ColumnName; });
            RemoveAll(delegate(Band b) { return b.BandType == BandEnum.GroupFooterBand && b.Group.ColumnName == group.ColumnName; });
			Reindex();
		}
	
		public void Remove(int Row)
		{
			if (Row < this.Count)
			{
				if (BandCount(this[Row]) > 1)
				{
					RemoveAt(Row);
					Reindex();
				}
			}
	    }

		public void Load(List<Band> list)
		{
			foreach (Band band in list)
			{
				Add(band);
			}
		}

        public void WriteXml(XmlTextWriter writer)
		{
			writer.WriteStartElement("bands");
			foreach (Band band in this)
			{
				band.WriteXml(writer);
			}
			writer.WriteEndElement();
		}
		
		private int BandCount(Band band)
		{
            return FindAll(delegate(Band b) { return b.BandType == band.BandType && b.GroupId == band.GroupId; }).Count;
		}

		private void Reindex()
		{
			int i=0;
			foreach(Band band in this)
			{
				band.Row = i++;
			}
		}
		
	}
}
