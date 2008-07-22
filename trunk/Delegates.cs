/*
 * User: Jason D. Jimenez
 * Date: 3/28/2007
 * Time: 6:04 AM
 * 
 */

using System;

namespace JasonJimenez.ClassicReport
{
	public delegate void ClassicReportDataHandler(object sender, ClassicReportDataEventArgs e);
	
	public class ClassicReportDataEventArgs 
	{
	    private bool _handled = false;
	    private object _target = null;
	    object _value = null;
	    string _colname = "";
	    string _tablename = "";
	    int _index = -1;
	    int _arrindex = 0;
	
	   
	    public ClassicReportDataEventArgs(object target, ReportComposerEventArgs e)
	    {            
	        this._target = target;
	        this.ArrayIndex = e.ArrayIndex;
	        this.ColumnName = e.ColumnName;
	        this.Index = e.Index;
	        this.TableName = e.TableName;
	        this.Value = e.Value;
	    }
	
	    public int Index
	    {
	        get { return _index; }
	        set { _index = value; }
	    }
	
	    public int ArrayIndex
	    {
	        get { return _arrindex; }
	        set { _arrindex = value; }
	    }
	
	    public object Value
	    {
	        get { return _value; }
	        set { _value = value; }
	    }
	
	    public string ColumnName
	    {
	        get { return _colname; }
	        set { _colname = value; }
	    }
	
	    public string TableName
	    {
	        get { return _tablename; }
	        set { _tablename = value; }
	    }
	    
	    public object Target
	    {
	        get { return _target; }
	        set { _target = value; }
	    }
	
	    public bool Handled
	    {
	        get { return _handled; }
	        set { _handled = value; }
	    }
	
	}
}
