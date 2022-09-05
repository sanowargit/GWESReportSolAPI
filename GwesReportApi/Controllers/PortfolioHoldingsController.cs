using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace GwesReportApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PortfolioHoldingsController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public PortfolioHoldingsController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public PortfolioHoldingsOutput PortFolioHoldings([FromBody] PortfolioHoldings PortfolioHoldings)
        {
            var objportfolioHoldings = new PortfolioHoldingsOutput();
            var objportfolioHoldingsOutput = new ObservableCollection<PortFolioHoldingsMainOutPut>();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_PortFolioHoldings", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@AsOfId", PortfolioHoldings.AsOfId);
            command.Parameters.AddWithValue("@PageId", PortfolioHoldings.PageId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);



            if (dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DR in dataset.Tables[0].Rows)
                {
                    //write codes here;
                    var objT1 = new PortFolioHoldingsMainOutPut();

                    objT1.AccountNumber = (DR["Account Number"].ToString() != null && DR["Account Number"].ToString() != "") ? (DR["Account Number"].ToString()) : "";
                    objT1.AccountName = (DR["Account Name"].ToString() != null && DR["Account Name"].ToString() != "") ? (DR["Account Name"].ToString()) : ""; objT1.AcctAlphaSortKey = (DR["AcctAlphaSortKey"].ToString() != null && DR["AcctAlphaSortKey"].ToString() != "") ? (DR["AcctAlphaSortKey"].ToString()) : "";
                    objT1.Account = objT1.AccountNumber + ':' +objT1.AccountName;
                    objT1.AccountType = (DR["Account Type"].ToString() != null && DR["Account Type"].ToString() != "") ? (DR["Account Type"].ToString()) : "";
                    objT1.AcctTypeSortKey = int.Parse(DR["AcctTypeSortKey"].ToString());
                    objT1.Administrator = (DR["Administrator"].ToString() != null && DR["Administrator"].ToString() != "") ? (DR["Administrator"].ToString()) : "";
                    objT1.Admin = (DR["Admin"].ToString() != null && DR["Admin"].ToString() != "") ? (DR["Admin"].ToString()) : "";
                    objT1.BranchName = (DR["Branch Name"].ToString() != null && DR["Branch Name"].ToString() != "") ? (DR["Branch Name"].ToString()) : "";
                    objT1.InvestmentOfficer = (DR["Investment Officer"].ToString() != null && DR["Investment Officer"].ToString() != "") ? (DR["Investment Officer"].ToString()) : "";
                    objT1.Inv = (DR["Inv"].ToString() != null && DR["Inv"].ToString() != "") ? (DR["Inv"].ToString()) : "";
                    objT1.LastShort= (DR["Last Short"].ToString() != null && DR["Last Short"].ToString() != "") ? (DR["Last Short"].ToString()) : "";

                    objT1.AstShrtNm = (DR["AstShrtNm"].ToString() != null && DR["AstShrtNm"].ToString() != "") ? (DR["AstShrtNm"].ToString()) : "";
                    objT1.AssetShrtNm = (DR["AssetShrtNm"].ToString() != null && DR["AssetShrtNm"].ToString() != "") ? (DR["AssetShrtNm"].ToString()) : "";

                    objT1.CouponRate = (DR["Coupon Rate"].ToString() != null && DR["Coupon Rate"].ToString() != "") ? decimal.Parse(DR["Coupon Rate"].ToString()) : 0;
                    //objT1.MaturityDt = (DR["MaturityDt"].ToString() != null && DR["MaturityDt"].ToString() != "") ? DateTime.Parse(DR["MaturityDt"].ToString()) : "";
                    objT1.MjrAstTypId = (DR["MjrAstTypId"].ToString() != null && DR["MjrAstTypId"].ToString() != "") ? int.Parse(DR["MjrAstTypId"].ToString()) : 0;
                    objT1.MajorAssetSort= (DR["Major Asset Sort"].ToString() != null && DR["Major Asset Sort"].ToString() != "") ? int.Parse(DR["Major Asset Sort"].ToString()) : 0;

                    objT1.MajorAssetType = (DR["Major Asset Type"].ToString() != null && DR["Major Asset Type"].ToString() != "") ? (DR["Major Asset Type"].ToString()) : "";
                    objT1.MnrAstTypId = (DR["MnrAstTypId"].ToString() != null && DR["MnrAstTypId"].ToString() != "") ? int.Parse(DR["MnrAstTypId"].ToString()) : 0;
                    objT1.MinorAssetSort= (DR["Minor Asset Sort"].ToString() != null && DR["Minor Asset Sort"].ToString() != "") ? int.Parse(DR["Minor Asset Sort"].ToString()) : 0;

                    objT1.MinorAssetType = (DR["Minor Asset Type"].ToString() != null && DR["Minor Asset Type"].ToString() != "") ? (DR["Minor Asset Type"].ToString()) : "";
                    objT1.DcmlPrcsn=(DR["DcmlPrcsn"].ToString() != null && DR["DcmlPrcsn"].ToString() != "") ? int.Parse(DR["DcmlPrcsn"].ToString()) : 0;

                    objT1.Units = (DR["Units"].ToString() != null && DR["Units"].ToString() != "") ? (DR["Units"].ToString()) : "";

                    objT1.Shares = (DR["Shares"].ToString() != null && DR["Shares"].ToString() != "") ? decimal.Parse(DR["Shares"].ToString()) : 0;
                    objT1.MarketPercent = (DR["Market Percent"].ToString() != null && DR["Market Percent"].ToString() != "") ? decimal.Parse(DR["Market Percent"].ToString()) : 0;
                    objT1.Cusip = (DR["Cusip"].ToString() != null && DR["Cusip"].ToString() != "") ? (DR["Cusip"].ToString()) : "";
                    objT1.Ticker = (DR["Ticker"].ToString() != null && DR["Ticker"].ToString() != "") ? (DR["Ticker"].ToString()) : "";
                    objT1.tckerCusip = (objT1.Cusip != null && objT1.Ticker != "") ? objT1.Cusip + '/' + objT1.Ticker : "";
                    objT1.TxcstAmt = (DR["TxcstAmt"].ToString() != null && DR["TxcstAmt"].ToString() != "") ? decimal.Parse(DR["TxcstAmt"].ToString()) : 0;
                    objT1.Price = (DR["Price"].ToString() != null && DR["Price"].ToString() != "") ? decimal.Parse(DR["Price"].ToString()) : 0;

                    objT1.GainLoss = (DR["GainLoss"].ToString() != null && DR["GainLoss"].ToString() != "") ? decimal.Parse(DR["GainLoss"].ToString()) : 0;
                    objT1.PortId = (DR["PortId"].ToString() != null && DR["PortId"].ToString() != "") ? int.Parse(DR["PortId"].ToString()) : 0;
                    objT1.Star = (DR["Star"].ToString() != null && DR["Star"].ToString() != "") ? (DR["Star"].ToString()) : "";

                    objT1.Income = (DR["Income"].ToString() != null && DR["Income"].ToString() != "") ? decimal.Parse(DR["Income"].ToString()) : 0;
                    objT1.Yield = (DR["Yield"].ToString() != null && DR["Yield"].ToString() != "") ? decimal.Parse(DR["Yield"].ToString()) : 0;
                    objT1.DateTime=Boolean.Parse(DR["Date Time"].ToString());

                    objT1.PageNo= Boolean.Parse(DR["PageNo"].ToString());

                    objT1.IndustryTypeID = (DR["Industry Type ID"].ToString() != null && DR["Industry Type ID"].ToString() != "") ? int.Parse(DR["Industry Type ID"].ToString()) : 0;

                    objT1.IndustryTypeName = (DR["Industry Type Name"].ToString() != null && DR["Industry Type Name"].ToString() != "") ? (DR["Industry Type Name"].ToString()) : "";

                    objT1.IndustryTypeSort= (DR["Industry Type Sort"].ToString() != null && DR["Industry Type Sort"].ToString() != "") ? int.Parse(DR["Industry Type Sort"].ToString()) : 0;

                    objT1.IndustryIndicator = Boolean.Parse(DR["Industry Indicator"].ToString());

                    objT1.TotMarket = (DR["TotMarket"].ToString() != null && DR["TotMarket"].ToString() != "") ? decimal.Parse(DR["TotMarket"].ToString()) : 0;
                    objT1.PriceDate = (DR["Price Date"].ToString() != null && DR["Price Date"].ToString() != "") ? DateTime.Parse(DR["Price Date"].ToString()) :DateTime.Parse("");

                    objT1.ExcldAssetMsg = (DR["ExcldAssetMsg"].ToString() != null && DR["ExcldAssetMsg"].ToString() != "") ? (DR["ExcldAssetMsg"].ToString()) : "";

                    objT1.P1CashBlncAmt = (DR["P1CashBlncAmt"].ToString() != null && DR["P1CashBlncAmt"].ToString() != "") ? decimal.Parse(DR["P1CashBlncAmt"].ToString()) : 0;

                    objT1.P2P3CashBlncAmt = (DR["P2P3CashBlncAmt"].ToString() != null && DR["P2P3CashBlncAmt"].ToString() != "") ? decimal.Parse(DR["P2P3CashBlncAmt"].ToString()) : 0;

                    objT1.UnExecCashAmt = (DR["UnExecCashAmt"].ToString() != null && DR["UnExecCashAmt"].ToString() != "") ? decimal.Parse(DR["UnExecCashAmt"].ToString()) : 0;

                    objT1.TradeCash = (DR["TradeCash"].ToString() != null && DR["TradeCash"].ToString() != "") ? decimal.Parse(DR["TradeCash"].ToString()) : 0;
                    objT1.ExcldCashAmt = (DR["ExcldCashAmt"].ToString() != null && DR["ExcldCashAmt"].ToString() != "") ? decimal.Parse(DR["ExcldCashAmt"].ToString()) : 0;

                    objT1.NoPosition = (DR["NoPosition"].ToString() != null && DR["NoPosition"].ToString() != "") ? int.Parse(DR["NoPosition"].ToString()) : 0;

                    objT1.EQFIIndicator = (DR["EQFIIndicator"].ToString() != null && DR["EQFIIndicator"].ToString() != "") ? int.Parse(DR["EQFIIndicator"].ToString()) : 0;

                    objT1.EquityPercent = (DR["Equity Percent"].ToString() != null && DR["Equity Percent"].ToString() != "") ? decimal.Parse(DR["Equity Percent"].ToString()) : 0;

                    objT1.AcctId = int.Parse(DR["AcctId"].ToString());
                    objT1.AstId = (DR["AstId"].ToString() != null && DR["AstId"].ToString() != "") ? int.Parse(DR["AstId"].ToString()) : 0;
                    objT1.Level1TypeId = (DR["Level1TypeId"].ToString() != null && DR["Level1TypeId"].ToString() != "") ? int.Parse(DR["Level1TypeId"].ToString()) : 0;

                    objT1.Level1Desc= (DR["Level1Desc"].ToString() != null && DR["Level1Desc"].ToString() != "") ? (DR["Level1Desc"].ToString()) : "";

                    objT1.Level2TypeId = (DR["Level2TypeId"].ToString() != null && DR["Level2TypeId"].ToString() != "") ? int.Parse(DR["Level2TypeId"].ToString()) : 0;

                    objT1.Level2Desc = (DR["Level2Desc"].ToString() != null && DR["Level2Desc"].ToString() != "") ? (DR["Level2Desc"].ToString()) : "";

                    objT1.Level3TypeId = (DR["Level3TypeId"].ToString() != null && DR["Level3TypeId"].ToString() != "") ? int.Parse(DR["Level3TypeId"].ToString()) : 0;

                    objT1.Level3Desc = (DR["Level3Desc"].ToString() != null && DR["Level3Desc"].ToString() != "") ? (DR["Level3Desc"].ToString()) : "";

                    objT1.Level4TypeId = (DR["Level4TypeId"].ToString() != null && DR["Level4TypeId"].ToString() != "") ? int.Parse(DR["Level4TypeId"].ToString()) : 0;

                    objT1.Level4Desc = (DR["Level4Desc"].ToString() != null && DR["Level4Desc"].ToString() != "") ? (DR["Level4Desc"].ToString()) : "";

                    objT1.Level5TypeId = (DR["Level5TypeId"].ToString() != null && DR["Level5TypeId"].ToString() != "") ? int.Parse(DR["Level5TypeId"].ToString()) : 0;

                    objT1.Level5Desc = (DR["Level5Desc"].ToString() != null && DR["Level5Desc"].ToString() != "") ? (DR["Level5Desc"].ToString()) : "";

                    objT1.InvstmntObj = (DR["InvstmntObj"].ToString() != null && DR["InvstmntObj"].ToString() != "") ? (DR["InvstmntObj"].ToString()) : "";
                    objT1.ModelPct = (DR["ModelPct"].ToString() != null && DR["ModelPct"].ToString() != "") ? decimal.Parse(DR["ModelPct"].ToString()) : 0;
                    objT1.ModelNm = (DR["ModelNm"].ToString() != null && DR["ModelNm"].ToString() != "") ? (DR["ModelNm"].ToString()) : "";

                    objT1.AstSymbl = (DR["AstSymbl"].ToString() != null && DR["AstSymbl"].ToString() != "") ? (DR["AstSymbl"].ToString()) : "";

                    objT1.SecIdenType = (DR["SecIdenType"].ToString() != null && DR["SecIdenType"].ToString() != "") ? int.Parse(DR["SecIdenType"].ToString()) : 0;

                    objT1.IntDivRate = (DR["IntDivRate"].ToString() != null && DR["IntDivRate"].ToString() != "") ? decimal.Parse(DR["IntDivRate"].ToString()) : 0;

                    //objT1.MtrtyDt = (DR["MtrtyDt"].ToString() != null && DR["MtrtyDt"].ToString() != "") ? DateTime.Parse(DR["MtrtyDt"].ToString()) : DateTime.Parse("");
                    objT1.PrmryAstClsSrtFld = (DR["PrmryAstClsSrtFld"].ToString() != null && DR["PrmryAstClsSrtFld"].ToString() != "") ? int.Parse(DR["PrmryAstClsSrtFld"].ToString()) : 0;

                    objT1.SecSrtID = (DR["SecSrtID"].ToString() != null && DR["SecSrtID"].ToString() != "") ? int.Parse(DR["SecSrtID"].ToString()) : 0;

                    objT1.SecSrtNm = (DR["SecSrtNm"].ToString() != null && DR["SecSrtNm"].ToString() != "") ? (DR["SecSrtNm"].ToString()) : "";

                    objT1.SecSrtKey = (DR["SecSrtKey"].ToString() != null && DR["SecSrtKey"].ToString() != "") ? int.Parse(DR["SecSrtKey"].ToString()) : 0;

                    objT1.NbrShrs = (DR["NbrShrs"].ToString() != null && DR["NbrShrs"].ToString() != "") ? decimal.Parse(DR["NbrShrs"].ToString()) : 0;

                    objT1.Pledge = (DR["Pledge"].ToString() != null && DR["Pledge"].ToString() != "") ? (DR["Pledge"].ToString()) : "";



                    objportfolioHoldingsOutput.Add(objT1);


                }
            }
            objportfolioHoldings.ocPortFolioHoldingsMainOutPut = objportfolioHoldingsOutput;

            return objportfolioHoldings;
        }

    }
}
