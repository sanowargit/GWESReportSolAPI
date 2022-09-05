using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using GwesReportApi.Inventory;
using GwesReportApi.Models;
using Microsoft.EntityFrameworkCore;
using GwesReportApi.Helpers;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;

namespace GwesReportApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AcctHoldingController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AcctHoldingController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public LstAcctHolding Index([FromBody] AcctHoldingInput objInput)
        {

            //var objAcctHolding = new List<AcctHolding>();
            var database = new GwesDbContext();
            
            var connection = database.Database.GetDbConnection();
            
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_AcctHolding", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command.Parameters.AddWithValue("@PageId", objInput.PageId); 
            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            //objAcctHolding = dataset.Tables[0].ToList<AcctHolding>();

            var objAcctHolding = new AcctHolding();
            var ocAcctHolding = new ObservableCollection<AcctHolding>();
            var AcctHoldConslist = new LstAcctHolding();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DR in dataset.Tables[0].Rows)
                {
                    //write codes here;
                    objAcctHolding = new AcctHolding();

                    objAcctHolding.AcctId = int.Parse(DR["AcctId"].ToString());
                    //objAcctHolding.AstId = (DR["AstId"].ToString() != null && DR["AstId"].ToString() != "") ? int.Parse(DR["AstId"].ToString()) : 0;
                    //objAcctHolding.PortId = (DR["PortId"].ToString() != null && DR["PortId"].ToString() != "") ? int.Parse(DR["PortId"].ToString()) : 0;
                    //objAcctHolding.PendingInd = (DR["PendingInd"].ToString() != null && DR["PendingInd"].ToString() != "") ? int.Parse(DR["PendingInd"].ToString()) : 0;
                    objAcctHolding.Asset = (DR["Asset"].ToString() != null && DR["Asset"].ToString() != "") ? (DR["Asset"].ToString()) : "";
                    ////objAcctHolding.MtrtyDt = (DR["MtrtyDt"].ToString() != null && DR["MtrtyDt"].ToString() != "") ? DateTime.Parse(DR["MtrtyDt"].ToString()) : "";
                    //objAcctHolding.AssetLongName = (DR["AssetLongName"].ToString() != null && DR["AssetLongName"].ToString() != "") ? (DR["AssetLongName"].ToString()) : "";
                    //objAcctHolding.MajorAssetTypId = (DR["MajorAssetTypId"].ToString() != null && DR["MajorAssetTypId"].ToString() != "") ? int.Parse(DR["MajorAssetTypId"].ToString()) : 0;
                    //objAcctHolding.AssetTypeId = (DR["AssetTypeId"].ToString() != null && DR["AssetTypeId"].ToString() != "") ? int.Parse(DR["AssetTypeId"].ToString()) : 0;
                    //objAcctHolding.AssetType = (DR["Asset Type"].ToString() != null && DR["Asset Type"].ToString() != "") ? (DR["Asset Type"].ToString()) : "";
                    objAcctHolding.TckrSymbl = (DR["TckrSymbl"].ToString() != null && DR["TckrSymbl"].ToString() != "") ? (DR["TckrSymbl"].ToString()) : "";
                    objAcctHolding.Cusip = (DR["Cusip"].ToString() != null && DR["Cusip"].ToString() != "") ? (DR["Cusip"].ToString()) : "";
                    objAcctHolding.PMRDesc = (DR["PMRDesc"].ToString() != null && DR["PMRDesc"].ToString() != "") ? (DR["PMRDesc"].ToString()) : "";
                    objAcctHolding.SrtKey = (DR["SrtKey"].ToString() != null && DR["SrtKey"].ToString() != "") ? int.Parse(DR["SrtKey"].ToString()) : 0;
                    objAcctHolding.Shares = (DR["Shares"].ToString() != null && DR["Shares"].ToString() != "") ? decimal.Parse(DR["Shares"].ToString()) : 0;
                    objAcctHolding.Cost = (DR["Cost"].ToString() != null && DR["Cost"].ToString() != "") ? decimal.Parse(DR["Cost"].ToString()) : 0;
                    objAcctHolding.Market = (DR["Market"].ToString() != null && DR["Market"].ToString() != "") ? decimal.Parse(DR["Market"].ToString()) : 0;
                    objAcctHolding.UnrGainLoss = (DR["Unr Gain Loss"].ToString() != null && DR["Unr Gain Loss"].ToString() != "") ? decimal.Parse(DR["Unr Gain Loss"].ToString()) : 0;
                    objAcctHolding.EstAnnInc = (DR["Est Ann Inc"].ToString() != null && DR["Est Ann Inc"].ToString() != "") ? decimal.Parse(DR["Est Ann Inc"].ToString()) : 0;
                    objAcctHolding.Yield = (DR["Yield"].ToString() != null && DR["Yield"].ToString() != "") ? decimal.Parse(DR["Yield"].ToString()) : 0;
                    objAcctHolding.AccruedInterest = (DR["Accrued Interest"].ToString() != null && DR["Accrued Interest"].ToString() != "") ? decimal.Parse(DR["Accrued Interest"].ToString()) : 0;
                    objAcctHolding.TradeType = (DR["TradeType"].ToString() != null && DR["TradeType"].ToString() != "") ? (DR["TradeType"].ToString()) : "";
                    //objAcctHolding.TrdDtSrt = (DR["TrdDtSrt"].ToString() != null && DR["TrdDtSrt"].ToString() != "") ? DateTime.Parse(DR["TrdDtSrt"].ToString()) : "";
                    objAcctHolding.AccountNumber = (DR["Account Number"].ToString() != null && DR["Account Number"].ToString() != "") ? (DR["Account Number"].ToString()) : "";
                    objAcctHolding.AcctAlphaSortKey = (DR["AcctAlphaSortKey"].ToString() != null && DR["AcctAlphaSortKey"].ToString() != "") ? (DR["AcctAlphaSortKey"].ToString()) : "";

                    objAcctHolding.AccountName = objAcctHolding.AccountNumber + " : " + objAcctHolding.AcctAlphaSortKey;//(DR["Account Name"].ToString() != null && DR["Account Name"].ToString() != "") ? (DR["Account Name"].ToString()) : "";

                    objAcctHolding.PrincipalCash = decimal.Parse(DR["Principal Cash"].ToString());
                    objAcctHolding.IncomeCash = decimal.Parse(DR["Income Cash"].ToString());
                    objAcctHolding.InvestedIncome = decimal.Parse(DR["Invested Income"].ToString());
                    objAcctHolding.BranchId = int.Parse(DR["BranchId"].ToString());
                    objAcctHolding.Branch = (DR["Branch"].ToString() != null && DR["Branch"].ToString() != "") ? (DR["Branch"].ToString()) : "";
                    objAcctHolding.InvstmntObjctvId = int.Parse(DR["InvstmntObjctvId"].ToString());
                    objAcctHolding.InvestmentObjective = (DR["Investment Objective"].ToString() != null && DR["Investment Objective"].ToString() != "") ? (DR["Investment Objective"].ToString()) : "";
                    objAcctHolding.AccountTypeId = int.Parse(DR["AccountTypeId"].ToString());
                    objAcctHolding.AccountType = (DR["Account Type"].ToString() != null && DR["Account Type"].ToString() != "") ? (DR["Account Type"].ToString()) : "";
                    objAcctHolding.AcctTypeSortKey = int.Parse(DR["AcctTypeSortKey"].ToString());
                    objAcctHolding.InvstmntModelId = (DR["InvstmntModelId"].ToString() != null && DR["InvstmntModelId"].ToString() != "") ? int.Parse(DR["InvstmntModelId"].ToString()) : 0;
                    objAcctHolding.ModelPortfolio = (DR["Model Portfolio"].ToString() != null && DR["Model Portfolio"].ToString() != "") ? (DR["Model Portfolio"].ToString()) : "";
                    objAcctHolding.AdministratorId = int.Parse(DR["AdministratorId"].ToString());
                    objAcctHolding.Administrator = (DR["Administrator"].ToString() != null && DR["Administrator"].ToString() != "") ? (DR["Administrator"].ToString()) : "";
                    objAcctHolding.AdmnInitils = (DR["AdmnInitils"].ToString() != null && DR["AdmnInitils"].ToString() != "") ? (DR["AdmnInitils"].ToString()) : "";
                    objAcctHolding.Admin = (DR["Admin"].ToString() != null && DR["Admin"].ToString() != "") ? (DR["Admin"].ToString()) : "";
                    objAcctHolding.InvID = int.Parse(DR["InvID"].ToString());
                    objAcctHolding.InvestmentOfficer = (DR["Investment Officer"].ToString() != null && DR["Investment Officer"].ToString() != "") ? (DR["Investment Officer"].ToString()) : "";
                    objAcctHolding.InvInitils = (DR["InvInitils"].ToString() != null && DR["InvInitils"].ToString() != "") ? (DR["InvInitils"].ToString()) : "";
                    objAcctHolding.Inv = (DR["Inv"].ToString() != null && DR["Inv"].ToString() != "") ? (DR["Inv"].ToString()) : "";
                    objAcctHolding.Rate = (DR["Rate"].ToString() != null && DR["Rate"].ToString() != "") ? decimal.Parse(DR["Rate"].ToString()) : 0;
                    objAcctHolding.TxCstAmt = (DR["TxCstAmt"].ToString() != null && DR["TxCstAmt"].ToString() != "") ? decimal.Parse(DR["TxCstAmt"].ToString()) : 0;
                    objAcctHolding.YldToCost = decimal.Parse(DR["YldToCost"].ToString());
                    //objAcctHolding.FAS157LvlId = (DR["FAS157LvlId"].ToString() != null && DR["FAS157LvlId"].ToString() != "") ? int.Parse(DR["FAS157LvlId"].ToString()) : 0;
                    //objAcctHolding.ASC820 = (DR["ASC820"].ToString() != null && DR["ASC820"].ToString() != "") ? (DR["ASC820"].ToString()) : "";



                    ocAcctHolding.Add(objAcctHolding);


                }
            }

            AcctHoldConslist.OCAcctHolding = ocAcctHolding;

            return AcctHoldConslist;
        }

    }
}
