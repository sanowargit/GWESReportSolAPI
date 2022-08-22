using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Author       :   Abhranil
 * Description  :   Model for Portfolio Holdings Report
 * Create Date  :   03-Aug-2022
*/

namespace GwesReportApi.Models
{
    public class PortfolioHoldings
    {
        public int AsOfId { get; set; }
    }

    

    public class PortFolioHoldingsMainOutPut
    {
        public string Acctno { get; set; }
        public string AcctName { get; set; }
        public string AcctSortKey { get; set; }
        public string AcctType { get; set; }
        public int AcctTypeSort { get; set; }
        public string Administrator { get; set; }
        public string Admin { get; set; }
        public string Branch { get; set; }
        public string InvestOffc { get; set; }
        public string IncCode { get; set; }
        public string LastShortName { get; set;}
        public string AstShrtNm { get; set; }
        public string AssettShrtNm { get; set; }
        public decimal CouponRate { get; set; }
        public DateTime MaturityDate { get; set; }
        public int MjrAstTypId { get; set; }
        public int MjrAstSort { get; set; }
        public string MjrAstType { get; set; }
        public int MnrAstTypId { get; set; }
        public int MnrAstSort { get; set; }
        public string MnrAstType { get; set; }
        public int DcmlPrcsn { get; set; }
        public string Units { get; set; }
        public decimal Shares { get; set; }
        public decimal Market { get; set; }
        public decimal MktPrcnt { get; set; }
        public string Cusip { get; set; }
        public string Ticker { get; set; }
        public decimal TxcstAmt { get; set; }
        public decimal Price { get; set; }
        public decimal GainLoss { get; set; }
        public int PortId { get; set; }
        public string Star { get; set; }
        public decimal Income { get; set; }
        public decimal Yield { get; set; }
        public bool TimeRun { get; set; }
        public bool PageNo { get; set; }
        public int IndstryTypeId { get; set; }
        public string IndstryTypeName { get; set; }
        public int IndstryTypeSort { get; set; }
        public bool IndstryInd{ get; set; }
        public decimal TotMkt { get; set; }
        public DateTime PriceDate { get; set; }
        public string ExcldAssetMsg { get; set; }
        public decimal P1CashBlncAmt { get; set; }
        public decimal P2P3CashBlncAmt { get; set; }
        public decimal UnExecCashAmt { get; set; }
        public decimal TradeCash { get; set; }
        public decimal ExcldCashAmt { get; set; }
        public int NoPosition { get; set; }
        public int EQFIIndicator { get; set; }
        public decimal EquityPerc { get; set; }
        public int AcctId { get; set; }
        public int AssetId { get; set; }
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
        public List<PortFolioHoldingsMainOutPut> ocPortFolioHoldingsMainOutPut { get; set; }
        public List<PortFolioHoldingsTradeTypeOutPut> ocPortFolioHoldingsTradeTypeOutPut { get; set; }


    }
}