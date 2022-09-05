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
    public class AccountProfileController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AccountProfileController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public ObservableCollection<AccountInformationList> Index([FromBody] GetAcctInfoInput objInput)
        {
            //int selectedAcctId = int.Parse(objInput.Accounts);
            ObservableCollection<AccountInformationList> acctProfObj = new ObservableCollection<AccountInformationList>();
            AccountInformationList obj1 = new AccountInformationList();

            var database = new GwesDbContext();

            var connection = database.Database.GetDbConnection();

            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("ADB_AccountProfile", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command.Parameters.AddWithValue("@mAccounts", objInput.Accounts);
            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);



            var ocAcctProfile = new ObservableCollection<AccountProfileModel>();
            var AcctProfileList = new LstAcctProfile();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DR in dataset.Tables[0].Rows)
                {
                    //write codes here;
                    AccountProfileModel acctProf = new AccountProfileModel();

                    acctProf.AcctId = (DR["AcctId"].ToString() != null && DR["AcctId"].ToString() != "") ? int.Parse(DR["AcctId"].ToString()) : 0;

                    acctProf.AccountNumber = (DR["Account Number"].ToString());
                    acctProf.AcctAlphaSortKey = (DR["AcctAlphaSortKey"].ToString());
                    acctProf.AccountName = (DR["Account Name"].ToString());
                    acctProf.AccountType = (DR["Account Type"].ToString());
                    acctProf.AcctTypeSortKey = (DR["AcctTypeSortKey"].ToString());
                    acctProf.Admin = (DR["Admin"].ToString());
                    acctProf.Administrator = (DR["Administrator"].ToString());
                    acctProf.BranchName = (DR["BranchName"].ToString());
                    acctProf.InvestmentOfficer = (DR["Investment Officer"].ToString());
                    acctProf.InvOff = (DR["Inv"].ToString());
                    //-- Report Fields
                    acctProf.InvObjective = (DR["InvObjective"].ToString());
                    acctProf.InvAuthority = (DR["InvAuthority"].ToString());
                    acctProf.Capacity = (DR["Capacity"].ToString());
                    acctProf.IncptnDt = (DR["IncptnDt"].ToString());
                    acctProf.YTDGainLoss = (DR["YTDGainLoss"].ToString() != null && DR["YTDGainLoss"].ToString() != "") ? decimal.Parse(DR["YTDGainLoss"].ToString()) : 0;
                    acctProf.GroupId = (DR["Group Id"].ToString() != null && DR["Group Id"].ToString() != "") ? int.Parse(DR["Group Id"].ToString()) : 0;
                    acctProf.GroupSort = (DR["Group Sort"].ToString());
                    acctProf.TxCstAmt = (DR["TxCstAmt"].ToString() != null && DR["TxCstAmt"].ToString() != "") ? decimal.Parse(DR["TxCstAmt"].ToString()) : 0;
                    acctProf.Market = (DR["Market"].ToString() != null && DR["Market"].ToString() != "") ? decimal.Parse(DR["Market"].ToString()) : 0;
                    acctProf.ExcldInd = (DR["ExcldInd"].ToString() != null && DR["ExcldInd"].ToString() != "") ? int.Parse(DR["ExcldInd"].ToString()) : 0;
                    acctProf.GroupName = (acctProf.ExcldInd == 1 ? "^" : "").ToString() + (DR["Group Name"].ToString());
                    acctProf.Income = (DR["Income"].ToString() != null && DR["Income"].ToString() != "") ? decimal.Parse(DR["Income"].ToString()) : 0;
                    acctProf.Yield = (DR["Yield"].ToString() != null && DR["Yield"].ToString() != "") ? decimal.Parse(DR["Yield"].ToString()) : 0;
                    acctProf.MarketPercent = (DR["Market Percent"].ToString() != null && DR["Market Percent"].ToString() != "") ? decimal.Parse(DR["Market Percent"].ToString()) : 0;
                    acctProf.RunDateTime = (DR["Date Time"].ToString());
                    acctProf.PageNo = (DR["PageNo"].ToString()) == "True" ? true : false;
                    acctProf.IsCurrentInfoLine = (DR["IsCurrentInfo Line"].ToString()) == "True" ? true : false;


                    ocAcctProfile.Add(acctProf);


                }
            }
            
            AcctProfileList.OCAcctProfile = ocAcctProfile;

            obj1.AccountProf = AcctProfileList;

            //Top Holdings

            var dataset1 = new DataSet();
            var adapter1 = new SqlDataAdapter();
            string numOfRows = "10";

            var command1 = new SqlCommand("ADB_AccountTopHolding", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command1.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command1.Parameters.AddWithValue("@AcctId", objInput.Accounts);
            command1.Parameters.AddWithValue("@NumOfRows", numOfRows);
            command1.CommandTimeout = 180;
            command1.CommandType = CommandType.StoredProcedure;
            adapter1.SelectCommand = command1;
            adapter1.Fill(dataset1);


            var dataFormat = new DataFormat();
            int RowCount = 0;
            var ocTopHolding = new ObservableCollection<TopHolding>();
            var TopHoldingList = new LstTopHolding();

            if (dataset1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DR in dataset1.Tables[0].Rows)
                {
                    //write codes here;
                    TopHolding topHldng = new TopHolding();
                    RowCount++;
                    topHldng.SequenceId = RowCount;
                    topHldng.AccountNumber = dataFormat.GetStringValue(DR, "Account Number");
                    topHldng.AccountName = dataFormat.GetStringValue(DR, "Account Name");
                    //asstAlloc.AcctAlphaSortKey 
                    topHldng.AccountType = dataFormat.GetStringValue(DR, "Account Type");
                    //AcctTypeSortKey 
                    topHldng.Administrator = dataFormat.GetStringValue(DR, "Administrator");
                    topHldng.Admin = dataFormat.GetStringValue(DR, "Admin");
                    topHldng.BranchName = dataFormat.GetStringValue(DR, "Branch Name");
                    topHldng.InvestmentOfficer = dataFormat.GetStringValue(DR, "Investment Officer");
                    topHldng.Inv = dataFormat.GetStringValue(DR, "Inv");
                    topHldng.AstshrtNm = (dataFormat.GetIntValue(DR, "Star") == 1 ? "*" : "") + dataFormat.GetStringValue(DR, "AstshrtNm");
                    topHldng.Shares = dataFormat.GetDecimalValue(DR, "Shares");
                    topHldng.Market = dataFormat.GetDecimalValue(DR, "Market");
                    topHldng.MarketPercent = dataFormat.GetDecimalValue(DR, "Market Percent");
                    topHldng.Cusip = dataFormat.GetStringValue(DR, "Cusip");
                    topHldng.Ticker = dataFormat.GetStringValue(DR, "Ticker");

                    topHldng.TickerCusipConcate = concatination(topHldng.Ticker, topHldng.Cusip, topHldng.AstshrtNm);

                    topHldng.TxcstAmt = dataFormat.GetDecimalValue(DR, "TxcstAmt");
                    //topHldng.DateTime = dataFormat.GetStringValue(DR, "Date Time");
                    //topHldng.PageNo = dataFormat.GetIntValue(DR, "PageNo");
                    topHldng.Star = dataFormat.GetIntValue(DR, "Star");
                    topHldng.ExcldAssetMsg = dataFormat.GetStringValue(DR, "ExcldAssetMsg");
                    topHldng.MinorAssetName = dataFormat.GetStringValue(DR, "MinorAssetName");
                    topHldng.MnrAstTypId = dataFormat.GetIntValue(DR, "MnrAstTypId");
                    topHldng.MajorAssetName = dataFormat.GetStringValue(DR, "MajorAssetName");
                    topHldng.MjrAstTypId = dataFormat.GetIntValue(DR, "MjrAstTypId");

                    ocTopHolding.Add(topHldng);


                }
            }

            TopHoldingList.OCTopHolding = ocTopHolding;

            obj1.TopHold= TopHoldingList;

            //Asset Allocation Vs Model
            var dataset2 = new DataSet();
            var adapter2 = new SqlDataAdapter();

            var command2 = new SqlCommand("ADB_AssetAllocVsModel", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command2.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command2.Parameters.AddWithValue("@mModelId", objInput.modelId);
            command2.Parameters.AddWithValue("@mInvstMix", objInput.invMix);
            command2.Parameters.AddWithValue("@AcctId", objInput.Accounts);
            command2.CommandTimeout = 180;
            command2.CommandType = CommandType.StoredProcedure;
            adapter2.SelectCommand = command2;
            adapter2.Fill(dataset2);



            var ocAssetAllocVsModel = new ObservableCollection<AssetAllocVsModel>();
            var AssetAllocVsModelList = new LstAssetAllocVsModel();
            
            if (dataset2.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow DR in dataset2.Tables[0].Rows)
                {
                    //write codes here;
                    AssetAllocVsModel asstAlloc = new AssetAllocVsModel();

                    asstAlloc.AcctId = dataFormat.GetIntValue(DR, "AcctId");
                    asstAlloc.AccountNumber = dataFormat.GetStringValue(DR, "Account Number");
                    asstAlloc.AcctAlphaSortKey = dataFormat.GetStringValue(DR, "AcctAlphaSortKey");
                    asstAlloc.AccountName = dataFormat.GetStringValue(DR, "Account Name");
                    asstAlloc.AccountType = dataFormat.GetStringValue(DR, "Account Type");
                    asstAlloc.AcctTypeSortKey = dataFormat.GetIntValue(DR, "AcctTypeSortKey");
                    asstAlloc.Admin = dataFormat.GetStringValue(DR, "Admin");
                    asstAlloc.Administrator = dataFormat.GetStringValue(DR, "Administrator");
                    asstAlloc.BranchName = dataFormat.GetStringValue(DR, "BranchName");
                    asstAlloc.InvestmentOfficer = dataFormat.GetStringValue(DR, "Investment Officer");
                    asstAlloc.Inv = dataFormat.GetStringValue(DR, "Inv");
                    asstAlloc.MAJSrtKey = dataFormat.GetStringValue(DR, "MAJSrtKey");
                    asstAlloc.GroupId = dataFormat.GetIntValue(DR, "Group Id");
                    asstAlloc.GroupSort = dataFormat.GetIntValue(DR, "Group Sort");
                    asstAlloc.Descption = (dataFormat.GetIntValue(DR, "ExcldInd") == 1 ? "^" : "") + dataFormat.GetStringValue(DR, "Descption");
                    asstAlloc.Prtfolio = dataFormat.GetDecimalValue(DR, "Prtfolio");
                    asstAlloc.PrtfolioWeigh = dataFormat.GetDecimalValue(DR, "PrtfolioWeigh");
                    asstAlloc.mdl = dataFormat.GetDecimalValue(DR, "mdl");
                    asstAlloc.MdlWegh = dataFormat.GetDecimalValue(DR, "MdlWegh");
                    asstAlloc.VaritoMdl = dataFormat.GetDecimalValue(DR, "VaritoMdl");
                    //asstAlloc.VaritoMdl_Amt = dataFormat.GetDecimalValue(DR, "VaritoMdl_Amt");
                    asstAlloc.VaritoMdl_Amt = dataFormat.GetDecimalValue(DR, "Prtfolio") - dataFormat.GetDecimalValue(DR, "mdl");
                    asstAlloc.DateTime = dataFormat.GetStringValue(DR, "Date Time") == "True" ? true : false;
                    asstAlloc.PageNo = dataFormat.GetStringValue(DR, "PageNo") == "True" ? true : false;
                    asstAlloc.ExcldInd = dataFormat.GetStringValue(DR, "ExcldInd") == "True" ? true : false;
                    asstAlloc.HiLevelInd = dataFormat.GetIntValue(DR, "HiLevelInd");
                    asstAlloc.ExcludeVal = dataFormat.GetDecimalValue(DR, "ExcludeVal");
                    asstAlloc.PMRExcludeAstInd = dataFormat.GetIntValue(DR, "PMRExcludeAstInd");
                    asstAlloc.MinPct = dataFormat.GetDecimalValue(DR, "MinPct");
                    asstAlloc.MaxPct = dataFormat.GetDecimalValue(DR, "MaxPct");
                    asstAlloc.InvstMix = dataFormat.GetStringValue(DR, "InvstMix") == "True" ? true : false;

                    ocAssetAllocVsModel.Add(asstAlloc);


                }
            }

            AssetAllocVsModelList.OCAssetAllocVsModel = ocAssetAllocVsModel;

            obj1.AssetAllocVsMod = AssetAllocVsModelList;

            //Get TTModels
            var dataset3 = new DataSet();
            var adapter3 = new SqlDataAdapter();

            var command3 = new SqlCommand("ADB_ModelList", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command3.Parameters.AddWithValue("@acctId", objInput.AcctId);

            command3.CommandTimeout = 180;
            command3.CommandType = CommandType.StoredProcedure;
            adapter3.SelectCommand = command3;
            adapter3.Fill(dataset3);
           


            var mdlAcct = new ModelsAndAccount();

            if (dataset3 != null)
            {
                if (dataset3.Tables.Count > 0)
                {
                    #region MODEL LIST
                    ObservableCollection<TT3ModelS> mdlObj = new ObservableCollection<TT3ModelS>();

                    foreach (DataRow DR in dataset3.Tables[0].Rows)
                    {
                        TT3ModelS mdl = new TT3ModelS();

                        mdl.ModelId = dataFormat.GetIntValue(DR, "ModelId");
                        mdl.ModelNm = dataFormat.GetStringValue(DR, "ModelDesc");
                        mdl.ModelTypeId = dataFormat.GetIntValue(DR, "ModelTypeId");
                        mdl.ModelTypeNm = dataFormat.GetStringValue(DR, "ModelTypeNm"); ;

                        mdlObj.Add(mdl);

                    }

                    mdlAcct.Model = mdlObj;
                    #endregion

                    #region ACCOUNT MODEL ASSOCIATION
                    ObservableCollection<AccountModelAssociation> acctMdlObj = new ObservableCollection<AccountModelAssociation>();

                    if (dataset3.Tables[1].Rows.Count == 0)
                    {
                        AccountModelAssociation acctMdl = new AccountModelAssociation();

                        acctMdl.ModelId = -1;

                        acctMdlObj.Add(acctMdl);
                    }
                    else
                    {
                        foreach (DataRow DR in dataset3.Tables[1].Rows)
                        {
                            AccountModelAssociation acctMdl = new AccountModelAssociation();

                            acctMdl.ModelId = dataFormat.GetIntValue(DR, "ModelId");

                            acctMdlObj.Add(acctMdl);
                        }
                    }

                    mdlAcct.AcctMdl = acctMdlObj;
                    #endregion

                    #region PORTFOLIO
                    ObservableCollection<Portfolio> portObj = new ObservableCollection<Portfolio>();

                    foreach (DataRow DR in dataset3.Tables[2].Rows)
                    {
                        Portfolio prt = new Portfolio();

                        prt.PortId = dataFormat.GetIntValue(DR, "PortId");
                        prt.Nm = dataFormat.GetStringValue(DR, "Port");

                        portObj.Add(prt);
                    }

                    mdlAcct.Port = portObj;
                    #endregion

                    #region HEIRARCHY
                    ObservableCollection<HierarchyLevels> hlObj = new ObservableCollection<HierarchyLevels>();

                    foreach (DataRow DR in dataset3.Tables[3].Rows)
                    {
                        HierarchyLevels hl = new HierarchyLevels();

                        hl.cdid = dataFormat.GetIntValue(DR, "CdId");
                        hl.cdDesc = dataFormat.GetStringValue(DR, "CdVlDesc");

                        hlObj.Add(hl);
                    }

                    mdlAcct.HierarchyLvl = hlObj;
                    #endregion



                }
            }
            obj1.ModelList = mdlAcct;

            

            acctProfObj.Add(obj1);
            return acctProfObj;
        }
        

       

       

        
        public static string concatination(string arg1, string arg2, string arg3)
        {
            
            string final_Ticker;
            if (arg1 != "" && arg2 != "")
            {
                final_Ticker = arg1 + ":" + arg3;
            }
            else if (arg1 == "")
            {
                final_Ticker = arg2 + ":" + arg3;
            }
            else
            {
                final_Ticker = arg1 + ":" + arg3;
            }
            return final_Ticker;
        }
    }
}
