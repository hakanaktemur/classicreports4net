/*
 * User: Jason D. Jimenez
 * Date: 12/8/2005
 * Time: 1:37 PM
 * 
 */

using System;

namespace JasonJimenez.ClassicReport.Common
{
	
	public class FunctionFactory
	{
		static public IFunction Create(CalcEnum mode)
		{
			switch (mode)
			{
				case CalcEnum.Ave:
					return new AveFunction();
				case CalcEnum.Sum:
					return new SumFunction();
				case CalcEnum.Count:
					return new CountFunction();
			}
			return null;
		}
	}
	
	
//	class Aggregator
//	{
//		CalcEnum m_mode;
//		decimal m_value = 0;
//		int m_count = 0;
//		
//		public Aggregator(CalcEnum type)
//		{
//			m_mode = type;
//		}
//		
//		public object GetValue()
//        {
//                switch (m_mode)
//                {
//                    case CalcEnum.Ave:
//                        return m_value / m_count;
//                    case CalcEnum.Count:
//                        return m_count;
//                    case CalcEnum.Sum:
//                        return m_value;
//                }
//                return 0;
//		}
//		
//		public void Add(object value)
//		{
//            switch (m_mode)
//            {
//                case CalcEnum.Sum:
//                    m_value += Convert.ToDecimal(value);
//                    break;
//                case CalcEnum.Ave:
//                    m_value += Convert.ToDecimal(value);
//                    m_count++;
//                    break;
//                case CalcEnum.Count:
//                    m_count++;
//                    break;
//                default:
//                    break;
//            }		
//		}
//		
//		public void Reset()
//		{
//			m_value = 0;
//			m_count = 0;
//		}
//	}
	
	public interface IFunction
	{
		object GetValue();
		void Add(object value);
		void Reset();
		void Rollback();
	}
	
	class SumFunction : IFunction
	{
		decimal m_sum = 0;
		decimal m_sum_old = 0;
		
		public object GetValue()
		{
			return m_sum;
		}
		
		public void Add(object value)
		{
			m_sum_old = m_sum;
			m_sum += Convert.ToDecimal(value);
		}
		
		public void Reset()
		{
			m_sum = 0;
		}
		
		public void Rollback()
		{
			m_sum = m_sum_old; 
		}
	}
	
	class AveFunction : IFunction
	{	
		decimal m_sum = 0;
		int m_count = 0;
		decimal m_sum_old = 0;
		int m_count_old = 0;
		
		public object GetValue()
		{
			return m_sum / m_count;
		}
		
		public void Add(object value)
		{
			m_sum_old = m_sum;
			m_count_old = m_count;
			m_sum += Convert.ToDecimal(value);
			m_count++;
		}
		
		public void Reset()
		{
			m_sum = 0;
			m_count = 0;
		}
		
		public void Rollback()
		{
			m_sum = m_sum_old; 
			m_count = m_count_old;
		}
	}
	
	class CountFunction : IFunction
	{
		int m_count = 0;
		int m_count_old = 0;
		
		public object GetValue()
		{
			return m_count;
		}
		
		public void Add(object value)
		{
			m_count_old = m_count;
			m_count++;
		}
		
		public void Reset()
		{
			m_count = 0;
		}
		
		public void Rollback()
		{
			m_count = m_count_old;
		}
		
	}
}
