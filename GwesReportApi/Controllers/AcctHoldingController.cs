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
    public class AcctHoldingController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AcctHoldingController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public List<AcctHolding> Index([FromBody] AcctHoldingInput objInput)
        {

            var objAcctHolding = new List<AcctHolding>();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_AcctHolding", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mUserId", objInput.UserId);
            
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            objAcctHolding = dataset.Tables[0].ToList<AcctHolding>();

            return objAcctHolding;
        }

    }
}
