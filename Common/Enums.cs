/*
 * Author: jason d. jimenez
 * Date  : 12/8/2005
 * Time  : 6:19 AM
 */

using System;

namespace JasonJimenez.ClassicReport.Common
{
    public enum CPIEnum
    {
        Default,
        _10cpi,
        _12cpi,
        _15cpi,
        _17cpi,
        _20cpi        
    }

    public enum AlignmentEnum 
    {
        AlignLeft,
        AlignRight
    }

    public enum JustifyEnum 
    {
        JustifyNone,
        JustifyLeft,
        JustifyRight,
        JustifyCenter 
    }

	public enum BandEnum 
	{
		PageHeaderBand,
		PageFooterBand,
		PageDetailBand,
  		SummaryBand,
		GroupHeaderBand,
		GroupFooterBand 
	}
	public enum CalcEnum
	{
		None,
		Sum,
		Ave,
		Count
	}
	public enum ResetEnum 
	{
		Default,
        EndOfGroup,
		EndOfReport,
		EndOfPage
	}
	public enum TypeEnum
	{
		String ,
		Integer,
		Currency,
		Date,
		Boolean
	}
	public enum CasingEnum
	{
		None,
		Upper,
		Lower,
		Proper
	}
	public enum FunctionEnum 
	{
		DateTime,
		Page,
		PageEx
	}

 }
