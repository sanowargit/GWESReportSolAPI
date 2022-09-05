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
    [Authorize]
    public class GetModelInfoController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public GetModelInfoController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public ModelsAndAccount Index([FromBody] GetModelInfoInput objInput)
        {
            var database = new GwesDbContext();

            var connection = database.Database.GetDbConnection();

            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("ADB_ModelList", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@acctId", objInput.AcctId);
            
            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            var dataFormat = new DataFormat();
            
            
            var mdlAcct = new ModelsAndAccount();
           
            if (dataset != null)
            {
                if (dataset.Tables.Count > 0)
                {
                    #region MODEL LIST
                    ObservableCollection<TT3ModelS> mdlObj = new ObservableCollection<TT3ModelS>();

                    foreach (DataRow DR in dataset.Tables[0].Rows)
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

                    if (dataset.Tables[1].Rows.Count == 0)
                    {
                        AccountModelAssociation acctMdl = new AccountModelAssociation();

                        acctMdl.ModelId = -1;

                        acctMdlObj.Add(acctMdl);
                    }
                    else
                    {
                        foreach (DataRow DR in dataset.Tables[1].Rows)
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

                    foreach (DataRow DR in dataset.Tables[2].Rows)
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

                    foreach (DataRow DR in dataset.Tables[3].Rows)
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
            return mdlAcct;
        }
    }
}
