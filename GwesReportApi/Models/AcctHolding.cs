using Microsoft.VisualBasic;
using System;

namespace GwesReportApi.Models
{
    public class AcctHolding
    {
        public int AcctId { get; set; }
        public int AstId { get; set; }
        public int PortId { get; set; }
        public int PendingInd { get; set; }
        public string Asset { get; set; }
        public DateTime MtrtyDt { get; set; }
        public string AssetLongName { get; set; }
        public int MajorAssetTypId { get; set; }
        public int AssetTypeId { get; set; }
        public string AssetType { get; set; } //
        public string TckrSymbl { get; set; }
        public string Cusip { get; set; }

        public string PMRDesc { get; set; }
        public int SrtKey { get; set; }
        public decimal Shares { get; set; }
        public decimal Cost { get; set; }
        public decimal Market { get; set; }
        public decimal UnrGainLoss { get; set; }//
        public decimal EstAnnInc { get; set; }//
        public decimal Yield { get; set; }
        public decimal AccruedInterest { get; set; }//
        public string TradeType { get; set; }
        public DateTime TrdDtSrt { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AcctAlphaSortKey { get; set; }

        public decimal PrincipalCash { get; set; }
        public decimal IncomeCash { get; set; }
        public decimal InvestedIncome { get; set; }
        public int BranchId { get; set; }
        public string Branch { get; set; }
        public int InvstmntObjctvId { get; set; }
        public string InvestmentObjective { get; set; }

        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey { get; set; }
        public int InvstmntModelId { get; set; }
        public string ModelPortfolio { get; set; }

        public int AdministratorId { get; set; }
        public string Administrator { get; set; }
        public string AdmnInitils { get; set; }
        public string Admin { get; set; }
        public int InvID { get; set; }
        public string InvestmentOfficer { get; set; }
        public string InvInitils { get; set; }
        public string Inv { get; set; }
        public decimal Rate { get; set; }
        public decimal TxCstAmt { get; set; }
        public decimal YldToCost { get; set; }
        public int FAS157LvlId { get; set; }
        public string ASC820 { get; set; }

<<<<<<< HEAD
=======

>>>>>>> 5b991a82402d314b2500366d960e0112a44d507e
    }
    public class AcctHoldingInput
    {
        public int UserId { get; set; }
        


    }
}
