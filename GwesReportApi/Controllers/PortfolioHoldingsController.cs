using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

            var PortfolioHoldingsRes = new PortfolioHoldingsOutput();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("ADB_PortFolioHoldings", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@AsOfId", PortfolioHoldings.AsOfId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);

            PortfolioHoldingsRes.ocPortFolioHoldingsMainOutPut = dataset.Tables[0].ToList<PortFolioHoldingsMainOutPut>();
            PortfolioHoldingsRes.ocPortFolioHoldingsTradeTypeOutPut = dataset.Tables[0].ToList<PortFolioHoldingsTradeTypeOutPut>();
            return PortfolioHoldingsRes;
        }

    }
}
