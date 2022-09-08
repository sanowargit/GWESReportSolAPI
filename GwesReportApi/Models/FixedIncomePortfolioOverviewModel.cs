using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GwesReportApi.Models
{
    public class FixedIncomePortfolioOverviewInput
    {
        public int AsOfId { get; set; }
        public int PageId { get; set; }
    }

    public class FixedIncomePortfolioOverviewT1
    { 
        public int AcctId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey  { get; set; }
        public string Administrator { get; set; }
        public string Admin { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string Inv { get; set; }
        public bool DateTime { get; set; }
        public bool PageNo { get; set; }

    }

    public class FixedIncomePortfolioOverviewT2
    { 
        public int AcctId { get; set; }
        public int MoodyRtngId { get; set; }
        public string Rating { get; set; }
        public decimal RtngPercent { get; set; }
    }

    public class FixedIncomePortfolioOverviewT3
    { 
        public int AcctId { get; set; }
        public decimal MatIndx { get; set; }
        public string RatingDesc { get; set; }
        public decimal Shares { get; set; }
        public decimal AvgYield { get; set; }
        public decimal AvgYTM { get; set; }
        public decimal AvgDuration { get; set; }
        public decimal AvgMaturity { get; set; }
        public decimal AvgYTW { get; set; }
        public decimal AvgCalPutDuration { get; set; }
        public decimal AvgCalPutMaturity { get; set; }

    }

    public class FixedIncomePortfolioOverviewT4
    { 
        public int AcctId { get; set; }
        public int MnrAstTypId { get; set; }
        public int SrtKey { get; set; }
        public string MinorClass { get; set; }
        public decimal ClassPercent { get; set; }

    }

    public class FixedIncomePortfolioOverviewT5
    { 
        public int AcctId { get; set; }
        public int MjrIndstryTypId { get; set; }
        public int SrtKey { get; set; }
        public string IndSector { get; set; }
        public decimal SectorPct { get; set; }
    }

    public class FixedIncomePortfolioOverviewT6
    { 
        public char Side { get; set; }
        public string PortId { get; set; }
        public int AstId { get; set; }
        public DateTime TrdDt { get; set; }
        public string Comments { get; set; }
        public int AcctId { get; set; }
        public string ExtrnlAcctId { get; set; }
        public string Cusip { get; set; }
        public string AstShrtNm { get; set; }
        public string BrokerName { get; set; }
        public decimal OrdNbrShrs { get; set; }
        public decimal TrdAmt { get; set; }
    }

    public class FixedIncomePortfolioOverviewOutput
    {
        public List<FixedIncomePortfolioOverviewT1> lstFixedIncomePortfolioOverviewT1 { get; set; }
        public List<FixedIncomePortfolioOverviewT2> lstFixedIncomePortfolioOverviewT2 { get; set; }
        public List<FixedIncomePortfolioOverviewT3> lstFixedIncomePortfolioOverviewT3 { get; set; }
        public List<FixedIncomePortfolioOverviewT4> lstFixedIncomePortfolioOverviewT4 { get; set; }
        public List<FixedIncomePortfolioOverviewT5> lstFixedIncomePortfolioOverviewT5 { get; set; }
        public List<FixedIncomePortfolioOverviewT6> lstFixedIncomePortfolioOverviewT6 { get; set; }


    }

}
