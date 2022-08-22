using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;

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
            command.Parameters.AddWithValue("@PrstInd", acctInput.PrstInd);
            command.Parameters.AddWithValue("@StrtDt", acctInput.StrtDt);
            command.Parameters.AddWithValue("@EndDt", acctInput.EndDt);
            command.Parameters.AddWithValue("@AsOfDt", acctInput.AsOfDt);
            command.Parameters.AddWithValue("@PriceDt", acctInput.PriceDt);
            command.Parameters.AddWithValue("@PriceFlag", acctInput.PriceFlag);
            command.Parameters.AddWithValue("@IsConsolidation", acctInput.IsConsolidation);
            command.Parameters.AddWithValue("@ShowExcldAst", acctInput.ShowExcldAst);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            rtFixdIncmM.fIM1 = dataset.Tables[0].ToList<FixedIncomeMaturityModelOutput1>();
            rtFixdIncmM.fIM2 = dataset.Tables[1].ToList<FixedIncomeMaturityModelOutput2>();
            rtFixdIncmM.fIM3 = dataset.Tables[2].ToList<FixedIncomeMaturityModelOutput3>();
            return rtFixdIncmM;
        }
    }
}
