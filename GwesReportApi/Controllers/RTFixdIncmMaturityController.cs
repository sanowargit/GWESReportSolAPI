using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using DataTableExtensions = GwesReportApi.Helpers.DataTableExtensions;

namespace GwesReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RTFixdIncmMaturityController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public RTFixdIncmMaturityController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public FixedIncomeMaturityModelOutput GetFixdIncmMaturityDetails([FromBody] FixedIncomeMaturityModelInput acctInput)
        {

            var rtFixdIncmM = new FixedIncomeMaturityModelOutput();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_FixedIncomeMaturityReport", (SqlConnection)connection);
            command.Parameters.AddWithValue("@UserId", acctInput.UserId);
            command.Parameters.AddWithValue("@Accounts", acctInput.acctIds);
            command.Parameters.AddWithValue("@PageId", acctInput.PageId);
            command.Parameters.AddWithValue("@PrstInd", acctInput.PrstInd);
            if(string.IsNullOrEmpty(acctInput.StrtDt))
                command.Parameters.AddWithValue("@StrtDt", DBNull.Value);
            else
                command.Parameters.AddWithValue("@StrtDt", acctInput.StrtDt);
            if (string.IsNullOrEmpty(acctInput.EndDt))
                command.Parameters.AddWithValue("@EndDt", DBNull.Value);
            else
                command.Parameters.AddWithValue("@EndDt", acctInput.EndDt);
            command.Parameters.AddWithValue("@AsOfDt", acctInput.AsOfDt);
            command.Parameters.AddWithValue("@PriceDt", acctInput.PriceDt);
            command.Parameters.AddWithValue("@PriceFlag", acctInput.PriceFlag);
            command.Parameters.AddWithValue("@IsConsolidation", acctInput.IsConsolidation);
            command.Parameters.AddWithValue("@ShowExcldAst", acctInput.ShowExcldAst);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 180;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            rtFixdIncmM.fIM1 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput1>(dataset.Tables[0]).Where(x => x.MtrtyYr != 0).ToList(); ;
            rtFixdIncmM.fIM2 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput2>(dataset.Tables[1]);
            rtFixdIncmM.fIM3 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput3>(dataset.Tables[2]);
            return rtFixdIncmM;
        }
    }
}
