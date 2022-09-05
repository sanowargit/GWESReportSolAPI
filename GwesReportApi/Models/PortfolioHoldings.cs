using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GwesReportApi.Models
{
    public class PortfolioHoldings
    {
        public int AsOfId { get; set; }
        public int PageId { get; set; }
    }

    

    public class PortFolioHoldingsMainOutPut
    {
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
        public string LastShort { get; set;}
        public string AstShrtNm { get; set; }
        public string AssetShrtNm { get; set; }
        public decimal CouponRate { get; set; }
        public DateTime MaturityDt { get; set; }
        public int MjrAstTypId { get; set; }
        public int MajorAssetSort { get; set; }
        public string MajorAssetType { get; set; }
        public int MnrAstTypId { get; set; }
        public int MinorAssetSort { get; set; }
        public string MinorAssetType { get; set; }
        public int DcmlPrcsn { get; set; }
        public string Units { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal MarketPercent { get; set; }
        public string Cusip { get; set; }
        public string Ticker { get; set; }
        public decimal TxcstAmt { get; set; }
        public decimal Price { get; set; }
        public decimal GainLoss { get; set; }
        public int PortId { get; set; }
        public string Star { get; set; }
        public decimal Income { get; set; }
        public decimal Yield { get; set; }
        public bool DateTime { get; set; }
        public bool PageNo { get; set; }
        public int IndustryTypeID { get; set; }
        public string IndustryTypeName { get; set; }
        public int IndustryTypeSort { get; set; }
        public bool IndustryIndicator { get; set; }
        public decimal TotMarket { get; set; }
        public DateTime PriceDate { get; set; }
        public string ExcldAssetMsg { get; set; }
        public decimal P1CashBlncAmt { get; set; }
        public decimal P2P3CashBlncAmt { get; set; }
        public decimal UnExecCashAmt { get; set; }
        public decimal TradeCash { get; set; }
        public decimal ExcldCashAmt { get; set; }
        public int NoPosition { get; set; }
        public int EQFIIndicator { get; set; }
        public decimal EquityPercent { get; set; }
        public int AcctId { get; set; }
        public int AstId { get; set; }
        public int Level1TypeId { get; set; }
        public string Level1Desc { get; set; }
        public int Level2TypeId { get; set; }
        public string Level2Desc { get; set; }
        public int Level3TypeId { get; set; }
        public string Level3Desc { get; set; }
        public int Level4TypeId { get; set; }
        public string Level4Desc { get; set; }
        public int Level5TypeId { get; set; }
        public string Level5Desc { get; set; }
        public string InvstmntObj { get; set; }
        public decimal ModelPct { get; set; }
        public string ModelNm { get; set; }
        public string AstSymbl { get; set; }
        public int SecIdenType { get; set; }
        public decimal IntDivRate { get; set; }
        public DateTime MtrtyDt { get; set; }
        public string IssueId { get; set; }
        public bool MfInd { get; set; }
        public int PrmryAstClsSrtFld { get; set; }
        public int SecSrtID { get; set; }
        public string SecSrtNm { get; set; }
        public int SecSrtKey { get; set; }
        public decimal NbrShrs { get; set; }
        public string Pledge { get; set; }
        public string tckerCusip { get; set; }
        public string Account { get; set; }
    }

    public class PortFolioHoldingsTradeTypeOutPut
    {
        public string TradeType { get; set; }
        public int AstId { get; set; }
        public int AcctId { get; set; }
        public int PortId { get; set; }
        public decimal Price { get; set; }
        public decimal NbrShrs { get; set; }
        public decimal NetTrdAmt { get; set; }
        public string Portfolio { get; set; }
        public string TckrSymbl { get; set; }
        public string Cusip { get; set; }
        public string AstShrtNm { get; set; }
    }

    public class PortfolioHoldingsOutput
    {
        public ObservableCollection<PortFolioHoldingsMainOutPut> ocPortFolioHoldingsMainOutPut { get; set; }
        public List<PortFolioHoldingsTradeTypeOutPut> ocPortFolioHoldingsTradeTypeOutPut { get; set; }


    }
}