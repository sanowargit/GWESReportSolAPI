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
    public class AccountPerformanceSummaryController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AccountPerformanceSummaryController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public AccountPerformanceSummaryOutPut AccountPerformanceSummary([FromBody] AccountPerformanceSummaryInput AccountPerformanceSummary)
        {

            var AccountPerformanceSummaryDs = new AccountPerformanceSummaryOutPut();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_AccountPerformanceSummary", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@AsOfId", AccountPerformanceSummary.AsOfId);
            command.Parameters.AddWithValue("@StartDate", AccountPerformanceSummary.StartDate);
            command.Parameters.AddWithValue("@EndDate", AccountPerformanceSummary.EndDate);
            command.Parameters.AddWithValue("@PageId", AccountPerformanceSummary.PageId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);

            AccountPerformanceSummaryDs.lstAccountPerformanceSummaryActivity = dataset.Tables[0].ToList<AccountPerformanceSummaryActivity>();
            AccountPerformanceSummaryDs.lstAccountPerformanceSummaryAllocation = dataset.Tables[1].ToList<AccountPerformanceSummaryAllocation>();
            AccountPerformanceSummaryDs.lstAccountPerformanceSummaryROR = dataset.Tables[2].ToList<AccountPerformanceSummaryROR>();
            return AccountPerformanceSummaryDs;
        }
    }
}
