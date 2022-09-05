using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace GwesReportApi.Models
{
    public class AccountProfileModel
    {
        public int AcctId { get; set; }
        //--Sort Fields
        public string AccountNumber { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AcctTypeSortKey { get; set; }
        public string Admin { get; set; }
        public string Administrator { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string InvOff { get; set; }
        //-- Report Fields
        public string InvObjective { get; set; }
        public string InvAuthority { get; set; }
        public string Capacity { get; set; }
        public string IncptnDt { get; set; }
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
    public class LstAcctProfile
    {
        public ObservableCollection<AccountProfileModel> OCAcctProfile { get; set; }

    }
    public class AcctProfileInput
    {
        public int UserId { get; set; }
        public string Accounts { get; set; }
    }

    public class TopHolding
    {
        public int SequenceId { get; set; }//for getting unique Asset History Details
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        //public string AcctAlphaSortKey 
        public string AccountType { get; set; }
        //AcctTypeSortKey 
        public string Administrator { get; set; }
        public string Admin { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string Inv { get; set; }
        public string AstshrtNm { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal MarketPercent { get; set; }
        public string Cusip { get; set; }
        public string Ticker { get; set; }
        public string TickerCusipConcate { get; set; }
        public decimal TxcstAmt { get; set; }
        public bool DateTime { get; set; }
        public bool PageNo { get; set; }
        public int Star { get; set; }
        public string ExcldAssetMsg { get; set; }
        public string MinorAssetName { get; set; }
        public int MnrAstTypId { get; set; }
        public string MajorAssetName { get; set; }
        public int MjrAstTypId { get; set; }
    }
    public class LstTopHolding
    {
        public ObservableCollection<TopHolding> OCTopHolding { get; set; }

    }
    public class TopHoldingInput
    {
        public int UserId { get; set; }
        public int NumberOfRows { get; set; }
        public string selectedAcctId { get; set; }
    }

    public class AssetAllocVsModel
    {
        public int AcctId { get; set; }
        public string AccountNumber { get; set; }
        public string AcctAlphaSortKey { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int AcctTypeSortKey { get; set; }
        public string Admin { get; set; }
        public string Administrator { get; set; }
        public string BranchName { get; set; }
        public string InvestmentOfficer { get; set; }
        public string Inv { get; set; }
        public string MAJSrtKey { get; set; }
        public int GroupId { get; set; }
        public int GroupSort { get; set; }
        public string Descption { get; set; }
        public decimal Prtfolio { get; set; }
        public decimal PrtfolioWeigh { get; set; }
        public decimal mdl { get; set; }
        public decimal MdlWegh { get; set; }
        public decimal VaritoMdl { get; set; }
        public decimal VaritoMdl_Amt { get; set; }
        public bool DateTime { get; set; }
        public bool PageNo { get; set; }
        public bool ExcldInd { get; set; }
        public int HiLevelInd { get; set; }
        public decimal ExcludeVal { get; set; }
        public int PMRExcludeAstInd { get; set; }
        public decimal MinPct { get; set; }
        public decimal MaxPct { get; set; }
        public bool InvstMix { get; set; }
    }
    public class LstAssetAllocVsModel
    {
        public ObservableCollection<AssetAllocVsModel> OCAssetAllocVsModel { get; set; }

    }
    public class AccountInformationList
    {
        
        public LstAcctProfile AccountProf { get; set; }
        public LstTopHolding TopHold { get; set; }
        public LstAssetAllocVsModel AssetAllocVsMod { get; set; }
        public ModelsAndAccount ModelList { get; set; }
        
    }
    public class GetAcctInfoInput
    {
        public int UserId { get; set; }
        public string Accounts { get; set; }
        public int modelId { get; set; }
        public int invMix { get; set; }
        public int NumOfRows { get; set; }
        public int AcctId { get; set; }
    }
}
