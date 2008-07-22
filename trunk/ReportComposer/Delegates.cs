using System;

namespace JasonJimenez.ClassicReport
{

    public delegate void ReportComposerEventHandler(object sender, ReportComposerEventArgs e);

    public class ReportComposerEventArgs : EventArgs
    {
        object _value = null;
        string _colname = "";
        string _tablename = "";
        int _index = -1;
        int _arrindex = 0;
        int _count = -1;
        //int _width = 10;
        bool _eof = false;
        bool _bof = true;
        
		public bool Bof 
		{
			get { return _bof; }
			set { _bof = value; }
		}
        
		public bool Eof 
		{
			get { return _eof; }
			set { _eof = value; }
		}

        //public int Width
        //{
        //    get { return _width; }
        //    set { _width = value; }
        //}
     
        /// <summary>
        /// The number of rows in the datasource.
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        /// <summary>
        /// The pointer to a row in the Datasource.
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        
        /// <summary>
        /// The control array index
        /// </summary>
        public int ArrayIndex
        {
        	get { return _arrindex; }
        	set { _arrindex = value; }
        }

        /// <summary>
        /// The value of the requested column or property.
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// The name of the requested column or property.
        /// </summary>
        public string ColumnName
        {
            get { return _colname; }
            set { _colname = value; }
        }

        /// <summary>
        /// The name of the requested datatable or class.
        /// </summary>
        public string TableName
        {
            get { return _tablename; }
            set { _tablename = value; }
        }
          
    }
}
