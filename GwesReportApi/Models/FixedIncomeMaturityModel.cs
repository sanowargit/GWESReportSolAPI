using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Globalization;

namespace GwesReportApi.Models
{
    public class FixedIncomeMaturityModelInput
    {
        public int UserId { get; set; }
        public string acctIds { get; set; }
        public int PrstInd { get; set; }
        public string StrtDt { get; set; }
        public string EndDt { get; set; }
        public string AsOfDt { get; set; }
        public string PriceDt { get; set; }
        public int PriceFlag { get; set; }
        public bool IsConsolidation { get; set; }
        public bool ShowExcldAst { get; set; }
        public int PageId { get; set; }
    }
    public class FixedIncomeMaturityModelOutput
    {
       public  List<FixedIncomeMaturityModelOutput1> fIM1 { get; set; }
       public List<FixedIncomeMaturityModelOutput2> fIM2 { get; set; }
       public List<FixedIncomeMaturityModelOutput3> fIM3 { get; set; }
    }
    public class FixedIncomeMaturityModelOutput1
    {
        public int AcctId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey { get; set; }
        public string Administrator { get; set; }
        public string Admin { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string Inv { get; set; }
        public int MtrtyYr { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal Income { get; set; }
        public decimal Yield { get; set; }
        public double MarketPercent { get; set; }
        public bool DateTm { get; set; }
        public bool PageNo { get; set; }
    }
    public class FixedIncomeMaturityModelOutput2
    {
        public int AcctId { get; set; }
        public int CallOrPutYr { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal Income { get; set; }
        public decimal Yield { get; set; }
        public double MarketPercent { get; set; }
    }
    public class FixedIncomeMaturityModelOutput3
    {
        public int AcctId { get; set; }
        public int CallOrPutYr { get; set; }
        public decimal MtrShares { get; set; }
        public decimal CallPutShares { get; set; }
    }    
}
