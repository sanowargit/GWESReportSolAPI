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
    public class RTAccountProfileController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public RTAccountProfileController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public List<RTAccountProfile> RTAccount([FromBody] rtacctInput acctInput)
        {

            var doc = new List<RTAccountProfile>();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            var command = new SqlCommand("RT_AccountProfile", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", acctInput.UserId);
            //command.Parameters.AddWithValue("@mAccounts", acctInput.Accounts);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            doc = dataset.Tables[0].ToList<RTAccountProfile>();
            return doc;
        }
    }
}
