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
    public class FixedIncomePortfolioOverviewController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public FixedIncomePortfolioOverviewController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public FixedIncomePortfolioOverviewOutput FixedIncomePortfolioOverview([FromBody] FixedIncomePortfolioOverviewInput FixedIncomePortfolioOverview)
        {

            var FixedIncomePortfolioOverviewDs = new FixedIncomePortfolioOverviewOutput();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_FixedIncomePortfolioOverview", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@AsOfId", FixedIncomePortfolioOverview.AsOfId);
            command.Parameters.AddWithValue("@PageId", FixedIncomePortfolioOverview.PageId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);

            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT1 = dataset.Tables[0].ToList<FixedIncomePortfolioOverviewT1>();
            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT2 = dataset.Tables[1].ToList<FixedIncomePortfolioOverviewT2>();
            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT3 = dataset.Tables[2].ToList<FixedIncomePortfolioOverviewT3>();
            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT4 = dataset.Tables[3].ToList<FixedIncomePortfolioOverviewT4>();
            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT5 = dataset.Tables[4].ToList<FixedIncomePortfolioOverviewT5>();
            FixedIncomePortfolioOverviewDs.lstFixedIncomePortfolioOverviewT6 = dataset.Tables[5].ToList<FixedIncomePortfolioOverviewT6>();
            return FixedIncomePortfolioOverviewDs;
        }

    }
}
