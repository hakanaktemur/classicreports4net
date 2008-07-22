/*
 * Author: Jason D. Jimenez
 * Date  : 5/30/2004
 * Time  : 9:14 AM
 * 
 */

using System;

namespace JasonJimenez.ClassicReport
{
	internal class CBuffer
	{
		char[] _buffer;
		int _size;

		public CBuffer()
		{
			_size=512;
			_buffer=new char[_size];
			this.Clear();
		}
		
		public CBuffer(int size)
		{
			_buffer = new char[size];
			_size = size;
			this.Clear();			
		}
		
		public void Clear()
		{
			for (int i=0; i<_size; i++)
				_buffer[i] = ' ';
		}
		
		public void Insert(ClassicReportItem item)
		{
			CopyString(item.Value,item.Offset);
		}
	
		public override string ToString()
		{
			string s = "";
			for (int i=0; i<_size; ++i)
				s += _buffer[i];
			return s.TrimEnd(' ');
		}

		private void CopyString(string src,int offset)
		{
			for(int i=0; i<src.Length; i++)
				_buffer[i+offset] = src[i];
		}
		
	}
}
