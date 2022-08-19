using Microsoft.VisualBasic;
using System;

namespace GwesReportApi.Models
{
    public class RTAccountProfile
    {
        public int AcctId { get; set; }
        //--Sort Fields
        public string AccountNumber { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey { get; set; }
        public string Admin { get; set; }
        public string Administrator { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string InvOff { get; set; }
        //-- Report Fields
        public string InvObjective { get; set; }
        public string InvAuthority { get; set; }
        public string Capacity { get; set; }
        public DateTime IncptnDt { get; set; }
        public decimal YTDGainLoss { get; set; }
        public int GroupId { get; set; }
        public string GroupSort { get; set; }
        public string GroupName { get; set; }
        public decimal TxCstAmt { get; set; }
        public decimal Market { get; set; }
        public int ExcldInd { get; set; }
        public decimal Income { get; set; }
        public decimal Yield { get; set; }
        public decimal MarketPercent { get; set; }
        public string RunDateTime { get; set; }
        public bool PageNo { get; set; }
        public bool IsCurrentInfoLine { get; set; }


    }
    public class rtacctInput
    {
        public int UserId { get; set; }
        public string Accounts { get; set; }


    }

}
