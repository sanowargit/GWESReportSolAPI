using Microsoft.VisualBasic;
using System;

namespace GwesReportApi.Models
{
    public class AcctTransactDateRange
    {
        public int AcctId { get; set; }
        public int TranTypId { get; set; }
        public int ActvtyTranTypId { get; set; }
        public int PortId { get; set; }
        public int TranId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public DateTime PrcsDt { get; set; }
        public int FeeGroup { get; set; }
        public string ScheduleName { get; set; }
        public decimal ScheduleTotal { get; set; }
        public int DetailSort { get; set; }
        public string Code { get; set; }
        public string Cusip { get; set; }
        public int positionInd { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line2a { get; set; }
        public decimal CPIAdjstdShrs { get; set; }
        public string Line2b { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
        public string Line6 { get; set; }
        public string Line7 { get; set; }
        public string Line8 { get; set; }
        public string Line9 { get; set; }
        public string Line10 { get; set; }
        public string Line11 { get; set; }
        public decimal Line11a { get; set; }
        public decimal Line11b { get; set; }
        public string Line12 { get; set; }
        public decimal Line12a { get; set; }
        public decimal Line12b { get; set; }
        public string Line13 { get; set; }
        public string Line14 { get; set; }
        public string Line15 { get; set; }
        public string Line16 { get; set; }
        public string Line17 { get; set; }
        public string Line18 { get; set; }
        public string Line19 { get; set; }
        public string Line20 { get; set; }
        public string Line21 { get; set; }
        public string Line22 { get; set; }
        public string Line23 { get; set; }
        public decimal Line23a { get; set; }
        public string Line24 { get; set; }
        public string Line25 { get; set; }
        public string Line26 { get; set; }
        public string Line27 { get; set; }
        public string Line28 { get; set; }
        public string Line29 { get; set; }
        public string TotalLine { get; set; }
        public string PdForCntctNm { get; set; }
        public string FeeCalOnAcct { get; set; }
        public decimal PCash { get; set; }
        public decimal ICash { get; set; }
        public decimal IICash { get; set; }
        public decimal Shares { get; set; }
        public decimal PC { get; set; }
        public decimal IC { get; set; }
        public decimal IIC { get; set; }
        public decimal P1CashBlncAmt { get; set; }
        public decimal P2CashBlncAmt { get; set; }
        public decimal NbrShrs { get; set; }
        public decimal P1ICM { get; set; }
        public decimal P2ICM { get; set; }
        public decimal StartingP1 { get; set; }
        public decimal StartingP2 { get; set; }
        public decimal StartingP3 { get; set; }
        public decimal StartingShare { get; set; }
        public string Admin { get; set; }
        public string Administrator { get; set; }
        public string Inv { get; set; }
        public string InvestmentOfficer { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int MnrAcctTypId { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey { get; set; }
        public string NumberofPayments { get; set; }
        public int StlmntCrncyAstId { get; set; }
        public int LocalCrncyId { get; set; }
        public int LocalCntryId { get; set; }
        public string EvntNm { get; set; }

        public string TranTypNm { get; set; }
    }
    public class AcctTransactDateRangeInput
    {
        public int UserId { get; set; }
        public string Accounts { get; set; }
        public string StartDate { get; set; }
        


    }
}
