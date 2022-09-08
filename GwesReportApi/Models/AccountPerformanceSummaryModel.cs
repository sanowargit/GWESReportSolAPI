using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GwesReportApi.Models
{
    public class AccountPerformanceSummaryInput
    {
        public int AsOfId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int PageId { get; set; }

    }

    public class AccountPerformanceSummaryActivity
    { 
        public int AcctId { get; set; }
        public string ExtrnlAcctId { get; set; }
        public string ShrtNm { get; set; }
        public string LngNm { get; set; }
        public int RptTmpltId { get; set; }
        public decimal StartMarket { get; set; }
        public decimal Receipt { get; set; }
        public int CshRcpt { get; set; }
        public int AstRcpt { get; set; }
        public decimal Disbursement { get; set; }
        public int CshDsb { get; set; }
        public int AstDsb { get; set; }
        public decimal Fees { get; set; }
        public decimal Income { get; set; }
        public decimal RLGainLoss { get; set; }
        public decimal ULGainLoss { get; set; }
        public decimal EndMarket { get; set; }
        public bool FeeRollUpInd { get; set; }
    }

    public class AccountPerformanceSummaryAllocation
    {
        public int MainAcctId { get; set; }
        public int MjrAstTypId { get; set; }
        public string AssetType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartMarket { get; set; }
        public decimal EndMarket { get; set; }
        public decimal StartPercent { get; set; }
        public decimal EndPercent { get; set; }
        public decimal TotStartMarket { get; set; }
        public decimal TotEndMarket { get; set; }
    }

    public class AccountPerformanceSummaryROR
    { 
        public int AcctId { get; set; }
        public int OrderLevel1 { get; set; }
        public DateTime IncptnDt { get; set; }
        public string IOBDesc { get; set; }
        public int IOBId { get; set; }
        public string IOBNm { get; set; }
        public decimal MonthToDate { get; set; }
        public decimal QuarterToDate { get; set; }
        public decimal YearToDate { get; set; }
        public decimal OneYear { get; set; }
        public decimal ThreeYear { get; set; }
        public decimal FiveYear { get; set; }
        public decimal Inception { get; set; }
        public decimal TenYear { get; set; }

    }

    public class AccountPerformanceSummaryOutPut
    { 
        public List<AccountPerformanceSummaryActivity> lstAccountPerformanceSummaryActivity { get; set; }
        public List<AccountPerformanceSummaryAllocation> lstAccountPerformanceSummaryAllocation { get; set; }
        public List<AccountPerformanceSummaryROR> lstAccountPerformanceSummaryROR { get; set; }
    }
}
