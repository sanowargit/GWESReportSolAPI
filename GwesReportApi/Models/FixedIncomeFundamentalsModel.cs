using System;
using System.ComponentModel.DataAnnotations;

namespace GwesReportApi.Models
{
    public class FixedIncomeFundamentalsModelInput
    {
        public int UserId { get; set; }
        public string acctIds { get; set; }
        
        //public int PrstInd { get; set; }
        //public string AsOfDt { get; set; }
        //public string PriceDt { get; set; }
        //public int PriceFlag { get; set; }
        //public bool IsConsolidation { get; set; }
        //public bool ShowExcldAst { get; set; }
    }
    public class FixedIncomeFundamentalsModelOutput
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
        public int AstId { get; set; }
        public int MtrtyYr { get; set; }
        public string AstShrtNm { get; set; }
        public double CouponRate { get; set; }
        public DateTime MaturityDt { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal Yield { get; set; }
        public double YldToMtrty { get; set; }
        public double Duration { get; set; }
        public double YldCalPut { get; set; }
        public double CalPutDuration { get; set; }
        public string MoodyRating { get; set; }
        public string SPRating { get; set; }
        public double Income { get; set; }
        public bool DateTm { get; set; }
        public bool PageNo { get; set; }
        public string ExcldAssetMsg { get; set; }
    }
}
