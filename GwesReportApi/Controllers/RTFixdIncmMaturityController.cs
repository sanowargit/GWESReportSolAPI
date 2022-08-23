using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            command.Parameters.AddWithValue("@PrstInd", 0);// acctInput.PrstInd);
            command.Parameters.AddWithValue("@StrtDt", "01/01/2022");// acctInput.StrtDt);
            command.Parameters.AddWithValue("@EndDt", "04/30/2022"); // acctInput.EndDt);
            command.Parameters.AddWithValue("@AsOfDt", "04/20/2022");// acctInput.AsOfDt);
            command.Parameters.AddWithValue("@PriceDt", "04/20/2022");// acctInput.PriceDt);
            command.Parameters.AddWithValue("@PriceFlag", 1); // acctInput.PriceFlag);
            command.Parameters.AddWithValue("@IsConsolidation", 0);// acctInput.IsConsolidation);
            command.Parameters.AddWithValue("@ShowExcldAst", 1);// acctInput.ShowExcldAst);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            rtFixdIncmM.fIM1 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput1>(dataset.Tables[0]);
            rtFixdIncmM.fIM2 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput2>(dataset.Tables[1]);
            rtFixdIncmM.fIM3 = DataTableExtensions.ToList<FixedIncomeMaturityModelOutput3>(dataset.Tables[2]);
            return rtFixdIncmM;
        }
    }
}
