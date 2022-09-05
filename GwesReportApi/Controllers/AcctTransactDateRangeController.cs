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
using System;

namespace GwesReportApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AcctTransactDateRangeController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AcctTransactDateRangeController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public LstAcctTransaction Index([FromBody] AcctTransactDateRangeInput objInput)
        {
            var objAcctTransactDateRange = new List<AcctTransactDateRange>();
            var database = new GwesDbContext();
            

            var connection = database.Database.GetDbConnection();

            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_AcctTransactionDateRange", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command.Parameters.AddWithValue("@mStartDt", objInput.StartDate);
            command.Parameters.AddWithValue("@PageId", objInput.PageId);

            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            //objAcctTransactDateRange = dataset.Tables[0].ToList<AcctTransactDateRange>();

            var AcctTransList = new LstAcctTransaction();
            var ocAcctTransaction = new ObservableCollection<AcctTransactDateRange>();
            var objAcctTransaction = new AcctTransactDateRange();

            if (dataset.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow DR in dataset.Tables[0].Rows)
                {
                    objAcctTransaction = new AcctTransactDateRange();
                    objAcctTransaction.AcctId = (DR["AcctId"].ToString() != null && DR["AcctId"].ToString() != "") ? int.Parse(DR["AcctId"].ToString()) : 0;
                    objAcctTransaction.TranId = (DR["TranId"].ToString() != null && DR["TranId"].ToString() != "") ? int.Parse(DR["TranId"].ToString()) : 0;
                    objAcctTransaction.TranTypId = (DR["TranTypId"].ToString() != null && DR["TranTypId"].ToString() != "") ? int.Parse(DR["TranTypId"].ToString()) : 0;
                    objAcctTransaction.TranTypNm = (DR["TranTypNm"].ToString() != null && DR["TranTypNm"].ToString() != "") ? (DR["TranTypNm"].ToString()) : "";
                    objAcctTransaction.ActvtyTranTypId = (DR["ActvtyTranTypId"].ToString() != null && DR["ActvtyTranTypId"].ToString() != "") ? int.Parse(DR["ActvtyTranTypId"].ToString()) : 0;
                    objAcctTransaction.PortId = (DR["PortId"].ToString() != null && DR["PortId"].ToString() != "") ? int.Parse(DR["PortId"].ToString()) : 0;
                    objAcctTransaction.AccountNumber = (DR["AccountNumber"].ToString() != null && DR["AccountNumber"].ToString() != "") ? (DR["AccountNumber"].ToString()) : "";
                    objAcctTransaction.AccountName = (DR["AccountName"].ToString() != null && DR["AccountName"].ToString() != "") ? (DR["AccountName"].ToString()) : "";
                    objAcctTransaction.AcctAlphaSortKey = (DR["AcctAlphaSortKey"].ToString() != null && DR["AcctAlphaSortKey"].ToString() != "") ? (DR["AcctAlphaSortKey"].ToString()) : "";
                    objAcctTransaction.PrcsDt = (DR["PrcsDt"].ToString() != null && DR["PrcsDt"].ToString() != "") ? DateTime.Parse(DR["PrcsDt"].ToString()) : default(DateTime);
                    objAcctTransaction.FeeGroup = (DR["FeeGroup"].ToString() != null && DR["FeeGroup"].ToString() != "") ? int.Parse(DR["FeeGroup"].ToString()) : 0;
                    objAcctTransaction.ScheduleName = (DR["ScheduleName"].ToString() != null && DR["ScheduleName"].ToString() != "") ? (DR["ScheduleName"].ToString()) : "";
                    objAcctTransaction.ScheduleTotal = (DR["ScheduleTotal"].ToString() != null && DR["ScheduleTotal"].ToString() != "") ? decimal.Parse(DR["ScheduleTotal"].ToString()) : 0;
                    objAcctTransaction.DetailSort = (DR["DetailSort"].ToString() != null && DR["DetailSort"].ToString() != "") ? int.Parse(DR["DetailSort"].ToString()) : 0;
                    objAcctTransaction.Code = (DR["Code"].ToString() != null && DR["Code"].ToString() != "") ? (DR["Code"].ToString()) : "";
                    objAcctTransaction.Cusip = (DR["Cusip"].ToString() != null && DR["Cusip"].ToString() != "") ? (DR["Cusip"].ToString()) : "";
                    objAcctTransaction.positionInd = (DR["positionInd"].ToString() != null && DR["positionInd"].ToString() != "") ? int.Parse(DR["positionInd"].ToString()) : 0;
                    objAcctTransaction.Line1 = (DR["Line1"].ToString() != null && DR["Line1"].ToString() != "") ? (DR["Line1"].ToString()) : "";
                    objAcctTransaction.Line2 = (DR["Line2"].ToString() != null && DR["Line2"].ToString() != "") ? (DR["Line2"].ToString()) : "";
                    objAcctTransaction.Line2a = (DR["Line2a"].ToString() != null && DR["Line2a"].ToString() != "") ? (DR["Line2a"].ToString()) : "";
                    objAcctTransaction.CPIAdjstdShrs = (DR["CPIAdjstdShrs"].ToString() != null && DR["CPIAdjstdShrs"].ToString() != "") ? decimal.Parse(DR["CPIAdjstdShrs"].ToString()) : 0;
                    objAcctTransaction.Line2b = (DR["Line2b"].ToString() != null && DR["Line2b"].ToString() != "") ? (DR["Line2b"].ToString()) : "";
                    objAcctTransaction.Line3 = (DR["Line3"].ToString() != null && DR["Line3"].ToString() != "") ? (DR["Line3"].ToString()) : "";
                    objAcctTransaction.Line4 = (DR["Line4"].ToString() != null && DR["Line4"].ToString() != "") ? (DR["Line4"].ToString()) : "";
                    objAcctTransaction.Line5 = (DR["Line5"].ToString() != null && DR["Line5"].ToString() != "") ? (DR["Line5"].ToString()) : "";
                    objAcctTransaction.Line6 = (DR["Line6"].ToString() != null && DR["Line6"].ToString() != "") ? (DR["Line6"].ToString()) : "";
                    objAcctTransaction.Line7 = (DR["Line7"].ToString() != null && DR["Line7"].ToString() != "") ? (DR["Line7"].ToString()) : "";
                    objAcctTransaction.Line8 = (DR["Line8"].ToString() != null && DR["Line8"].ToString() != "") ? (DR["Line8"].ToString()) : "";
                    objAcctTransaction.Line9 = (DR["Line9"].ToString() != null && DR["Line9"].ToString() != "") ? (DR["Line9"].ToString()) : "";
                    objAcctTransaction.Line10 = (DR["Line10"].ToString() != null && DR["Line10"].ToString() != "") ? (DR["Line10"].ToString()) : "";
                    objAcctTransaction.Line11 = (DR["Line11"].ToString() != null && DR["Line11"].ToString() != "") ? (DR["Line11"].ToString()) : "";
                    objAcctTransaction.Line11a = (DR["Line11a"].ToString() != null && DR["Line11a"].ToString() != "") ? decimal.Parse(DR["Line11a"].ToString()) : 0;
                    objAcctTransaction.Line11b = (DR["Line11b"].ToString() != null && DR["Line11b"].ToString() != "") ? decimal.Parse(DR["Line11b"].ToString()) : 0;
                    objAcctTransaction.Line12 = (DR["Line12"].ToString() != null && DR["Line12"].ToString() != "") ? (DR["Line12"].ToString()) : "";
                    objAcctTransaction.Line12a = (DR["Line12a"].ToString() != null && DR["Line12a"].ToString() != "") ? decimal.Parse(DR["Line12a"].ToString()) : 0;
                    objAcctTransaction.Line12b = (DR["Line12b"].ToString() != null && DR["Line12b"].ToString() != "") ? decimal.Parse(DR["Line12b"].ToString()) : 0;
                    objAcctTransaction.Line13 = (DR["Line13"].ToString() != null && DR["Line13"].ToString() != "") ? (DR["Line13"].ToString()) : "";
                    objAcctTransaction.Line14 = (DR["Line14"].ToString() != null && DR["Line14"].ToString() != "") ? (DR["Line14"].ToString()) : "";
                    objAcctTransaction.Line15 = (DR["Line15"].ToString() != null && DR["Line15"].ToString() != "") ? (DR["Line15"].ToString()) : "";
                    objAcctTransaction.Line16 = (DR["Line16"].ToString() != null && DR["Line16"].ToString() != "") ? (DR["Line16"].ToString()) : "";
                    objAcctTransaction.Line17 = (DR["Line17"].ToString() != null && DR["Line17"].ToString() != "") ? (DR["Line17"].ToString()) : "";
                    objAcctTransaction.Line18 = (DR["Line18"].ToString() != null && DR["Line18"].ToString() != "") ? (DR["Line18"].ToString()) : "";
                    objAcctTransaction.Line19 = (DR["Line19"].ToString() != null && DR["Line19"].ToString() != "") ? (DR["Line19"].ToString()) : "";
                    objAcctTransaction.Line20 = (DR["Line20"].ToString() != null && DR["Line20"].ToString() != "") ? (DR["Line20"].ToString()) : "";
                    objAcctTransaction.Line21 = (DR["Line21"].ToString() != null && DR["Line21"].ToString() != "") ? (DR["Line21"].ToString()) : "";
                    objAcctTransaction.Line22 = (DR["Line22"].ToString() != null && DR["Line22"].ToString() != "") ? (DR["Line22"].ToString()) : "";
                    objAcctTransaction.Line23 = (DR["Line23"].ToString() != null && DR["Line23"].ToString() != "") ? (DR["Line23"].ToString()) : "";
                    objAcctTransaction.Line23a = (DR["Line23a"].ToString() != null && DR["Line23a"].ToString() != "") ? decimal.Parse(DR["Line23a"].ToString()) : 0;
                    objAcctTransaction.Line24 = (DR["Line24"].ToString() != null && DR["Line24"].ToString() != "") ? (DR["Line24"].ToString()) : "";
                    objAcctTransaction.Line25 = (DR["Line25"].ToString() != null && DR["Line25"].ToString() != "") ? (DR["Line25"].ToString()) : "";
                    objAcctTransaction.Line26 = (DR["Line26"].ToString() != null && DR["Line26"].ToString() != "") ? (DR["Line26"].ToString()) : "";
                    objAcctTransaction.Line27 = (DR["Line27"].ToString() != null && DR["Line27"].ToString() != "") ? (DR["Line27"].ToString()) : "";
                    objAcctTransaction.Line28 = (DR["Line28"].ToString() != null && DR["Line28"].ToString() != "") ? (DR["Line28"].ToString()) : "";
                    objAcctTransaction.Line29 = (DR["Line29"].ToString() != null && DR["Line29"].ToString() != "") ? (DR["Line29"].ToString()) : "";
                    objAcctTransaction.PdForCntctNm = (DR["PdForCntctNm"].ToString() != null && DR["PdForCntctNm"].ToString() != "") ? (DR["PdForCntctNm"].ToString()) : "";
                    objAcctTransaction.FeeCalOnAcct = (DR["FeeCalOnAcct"].ToString() != null && DR["FeeCalOnAcct"].ToString() != "") ? (DR["FeeCalOnAcct"].ToString()) : "";
                    objAcctTransaction.PCash = (DR["PCash"].ToString() != null && DR["PCash"].ToString() != "") ? decimal.Parse(DR["PCash"].ToString()) : 0;
                    objAcctTransaction.ICash = (DR["ICash"].ToString() != null && DR["ICash"].ToString() != "") ? decimal.Parse(DR["ICash"].ToString()) : 0;
                    objAcctTransaction.IICash = (DR["IICash"].ToString() != null && DR["IICash"].ToString() != "") ? decimal.Parse(DR["IICash"].ToString()) : 0;
                    objAcctTransaction.Shares = (DR["Shares"].ToString() != null && DR["Shares"].ToString() != "") ? decimal.Parse(DR["Shares"].ToString()) : 0;
                    objAcctTransaction.PC = (DR["PC"].ToString() != null && DR["PC"].ToString() != "") ? decimal.Parse(DR["PC"].ToString()) : 0;
                    objAcctTransaction.IC = (DR["IC"].ToString() != null && DR["IC"].ToString() != "") ? decimal.Parse(DR["IC"].ToString()) : 0;
                    objAcctTransaction.IIC = (DR["IIC"].ToString() != null && DR["IIC"].ToString() != "") ? decimal.Parse(DR["IIC"].ToString()) : 0;
                    objAcctTransaction.P1CashBlncAmt = (DR["P1CashBlncAmt"].ToString() != null && DR["P1CashBlncAmt"].ToString() != "") ? decimal.Parse(DR["P1CashBlncAmt"].ToString()) : 0;
                    objAcctTransaction.P2CashBlncAmt = (DR["P2CashBlncAmt"].ToString() != null && DR["P2CashBlncAmt"].ToString() != "") ? decimal.Parse(DR["P2CashBlncAmt"].ToString()) : 0;
                    objAcctTransaction.NbrShrs = (DR["NbrShrs"].ToString() != null && DR["NbrShrs"].ToString() != "") ? decimal.Parse(DR["NbrShrs"].ToString()) : 0;
                    objAcctTransaction.P1ICM = (DR["P1ICM"].ToString() != null && DR["P1ICM"].ToString() != "") ? decimal.Parse(DR["P1ICM"].ToString()) : 0;
                    objAcctTransaction.P2ICM = (DR["P2ICM"].ToString() != null && DR["P2ICM"].ToString() != "") ? decimal.Parse(DR["P2ICM"].ToString()) : 0;
                    objAcctTransaction.StartingP1 = (DR["StartingP1"].ToString() != null && DR["StartingP1"].ToString() != "") ? decimal.Parse(DR["StartingP1"].ToString()) : 0;
                    objAcctTransaction.StartingP2 = (DR["StartingP2"].ToString() != null && DR["StartingP2"].ToString() != "") ? decimal.Parse(DR["StartingP2"].ToString()) : 0;
                    objAcctTransaction.StartingP3 = (DR["StartingP3"].ToString() != null && DR["StartingP3"].ToString() != "") ? decimal.Parse(DR["StartingP3"].ToString()) : 0;
                    objAcctTransaction.StartingShare = (DR["StartingShare"].ToString() != null && DR["StartingShare"].ToString() != "") ? decimal.Parse(DR["StartingShare"].ToString()) : 0;
                    objAcctTransaction.Admin = (DR["Admin"].ToString() != null && DR["Admin"].ToString() != "") ? (DR["Admin"].ToString()) : "";
                    objAcctTransaction.Administrator = (DR["Administrator"].ToString() != null && DR["Administrator"].ToString() != "") ? (DR["Administrator"].ToString()) : "";
                    objAcctTransaction.Inv = (DR["Inv"].ToString() != null && DR["Inv"].ToString() != "") ? (DR["Inv"].ToString()) : "";
                    objAcctTransaction.InvestmentOfficer = (DR["InvestmentOfficer"].ToString() != null && DR["InvestmentOfficer"].ToString() != "") ? (DR["InvestmentOfficer"].ToString()) : "";
                    objAcctTransaction.BranchId = (DR["BranchId"].ToString() != null && DR["BranchId"].ToString() != "") ? int.Parse(DR["BranchId"].ToString()) : 0;
                    objAcctTransaction.BranchName = (DR["BranchName"].ToString() != null && DR["BranchName"].ToString() != "") ? (DR["BranchName"].ToString()) : "";
                    objAcctTransaction.MnrAcctTypId = (DR["MnrAcctTypId"].ToString() != null && DR["MnrAcctTypId"].ToString() != "") ? int.Parse(DR["MnrAcctTypId"].ToString()) : 0;
                    objAcctTransaction.AccountType = (DR["AccountType"].ToString() != null && DR["AccountType"].ToString() != "") ? (DR["AccountType"].ToString()) : "";
                    objAcctTransaction.AcctTypeSortKey = (DR["AcctTypeSortKey"].ToString() != null && DR["AcctTypeSortKey"].ToString() != "") ? int.Parse(DR["AcctTypeSortKey"].ToString()) : 0;
                    objAcctTransaction.NumberofPayments = (DR["NumberofPayments"].ToString() != null && DR["NumberofPayments"].ToString() != "") ? (DR["NumberofPayments"].ToString()) : "";
                    objAcctTransaction.StlmntCrncyAstId = (DR["StlmntCrncyAstId"].ToString() != null && DR["StlmntCrncyAstId"].ToString() != "") ? int.Parse(DR["StlmntCrncyAstId"].ToString()) : 0;
                    objAcctTransaction.LocalCrncyId = (DR["LocalCrncyId"].ToString() != null && DR["LocalCrncyId"].ToString() != "") ? int.Parse(DR["LocalCrncyId"].ToString()) : 0;
                    objAcctTransaction.LocalCntryId = (DR["LocalCntryId"].ToString() != null && DR["LocalCntryId"].ToString() != "") ? int.Parse(DR["LocalCntryId"].ToString()) : 0;
                    objAcctTransaction.EvntNm = (DR["EvntNm"].ToString() != null && DR["EvntNm"].ToString() != "") ? (DR["EvntNm"].ToString()) : "";

                    objAcctTransaction.TotalLine = objAcctTransaction.Line1 + objAcctTransaction.Line2 + objAcctTransaction.Line2a + objAcctTransaction.Line2b + objAcctTransaction.Line3 + objAcctTransaction.Line4 + objAcctTransaction.Line5 + objAcctTransaction.Line6 + objAcctTransaction.Line7 + objAcctTransaction.Line8 + objAcctTransaction.Line9 + objAcctTransaction.Line10 + objAcctTransaction.Line11 + objAcctTransaction.Line11a + objAcctTransaction.Line11b + objAcctTransaction.Line12 + objAcctTransaction.Line12a + objAcctTransaction.Line12b + objAcctTransaction.Line13 + objAcctTransaction.Line14 + objAcctTransaction.Line15 + objAcctTransaction.Line16 + objAcctTransaction.Line17 + objAcctTransaction.Line18 + objAcctTransaction.Line19 + objAcctTransaction.Line20 + objAcctTransaction.Line21 + objAcctTransaction.Line22 + objAcctTransaction.Line23 + objAcctTransaction.Line23a + objAcctTransaction.Line24 + objAcctTransaction.Line25 + objAcctTransaction.Line26 + objAcctTransaction.Line27 + objAcctTransaction.Line28 + objAcctTransaction.Line29;
                    ocAcctTransaction.Add(objAcctTransaction);

                }
            }
            AcctTransList.OCAcctTransaction = ocAcctTransaction;

            return AcctTransList;
        }

    }
}
