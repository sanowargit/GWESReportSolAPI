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
        public List<AcctTransactDateRange> Index([FromBody] AcctTransactDateRangeInput objInput)
        {
            var objAcctTransactDateRange = new List<AcctTransactDateRange>();
            var database = new GwesDbContext();
            //objInput.StartDate = "06/30/2021";
            //objInput.Accounts= "<root><Account AcctId='13559'/></root>";
            var connection = database.Database.GetDbConnection();

            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_AcctTransactionDateRange", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", objInput.UserId);
            command.Parameters.AddWithValue("@mStartDt", objInput.StartDate);
            command.Parameters.AddWithValue("@mAccounts", objInput.Accounts);

            command.CommandTimeout = 180;
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            objAcctTransactDateRange = dataset.Tables[0].ToList<AcctTransactDateRange>();

            return objAcctTransactDateRange;
        }
    }
}
