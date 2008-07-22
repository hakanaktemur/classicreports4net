/*
 * Author: Jason Jimenez
 * Date	 : 4/29/2007  7:12 PM
 * 
 */

using System;

namespace JasonJimenez.ClassicReport
{
	static class Utility
	{
		public static string RepeatChar(char ch, int length)
		{
			string s = "";
			for (int i = 0; i < length; i++)
			{
				s += ch;
			}
			return s;
		}
	}
}
