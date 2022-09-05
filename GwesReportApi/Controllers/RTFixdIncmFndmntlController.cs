using GwesReportApi.Helpers;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataTableExtensions = GwesReportApi.Helpers.DataTableExtensions;

namespace GwesReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RTFixdIncmFndmntlController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public RTFixdIncmFndmntlController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public List<FixedIncomeFundamentalsModelOutput> RTFixdIncmFndmntl([FromBody] FixedIncomeFundamentalsModelInput acctInput)
        {

            var rtFixedIncm = new List<FixedIncomeFundamentalsModelOutput>();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            var command = new SqlCommand("RT_FixedIncomeFundamentalsReport", (SqlConnection)connection);
            command.Parameters.AddWithValue("@userId", acctInput.UserId);
            command.Parameters.AddWithValue("@mAccounts", "");// acctInput.Accounts);
            command.Parameters.AddWithValue("@PageId", 1);// acctInput.PageId);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 50;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            rtFixedIncm = DataTableExtensions.ToList<FixedIncomeFundamentalsModelOutput>(dataset.Tables[0]);//.ToList<FixedIncomeFundamentalsModelOutput>();
            rtFixedIncm=rtFixedIncm.Where(x => x.MtrtyYr != 0).ToList();
            return rtFixedIncm;
        }
    }
}

