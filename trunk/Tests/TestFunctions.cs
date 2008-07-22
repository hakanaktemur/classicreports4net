/*
 * User: Jason Jimenez
 * Date: 3/20/2007
 * Time: 9:13 AM
 * 
 */

using System;
using JasonJimenez.ClassicReport.Common;
using NUnit.Core;
using NUnit.Framework;


namespace Tests
{	
	[TestFixture]
	public class TestFunctions
	{
		[Test]
		public void TestSum()
		{
			IFunction func = FunctionFactory.Create(CalcEnum.Sum);
			func.Add(100);
			func.Add(200);
			Assert.AreEqual(func.GetValue(), 300);
		}
		
		[Test]
		public void TestCount()
		{
			IFunction func = FunctionFactory.Create(CalcEnum.Count);
			func.Add(1);
			func.Add(1);
			Assert.AreEqual(func.GetValue(), 2);
		}
		
		[Test]
		public void TestAve()
		{
			IFunction func = FunctionFactory.Create(CalcEnum.Ave);
			func.Add(100);
			func.Add(200);
			Assert.AreEqual(func.GetValue(), 150);
		}
	}
}
