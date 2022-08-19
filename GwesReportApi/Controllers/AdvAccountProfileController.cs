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
    public class AdvAccountProfileController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AdvAccountProfileController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public AdvAccountProfile Account([FromBody] acctInput acctInput)
        {

            var doc = new AdvAccountProfile();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("AdvAccountProfile", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@UserId", acctInput.UserId);
            command.Parameters.AddWithValue("@RoleTypId", acctInput.RoleTypId);
            command.Parameters.AddWithValue("@AcctId", acctInput.AcctId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            doc.T1 = dataset.Tables[0].ToList<AcctProfileT1>();
            doc.T2 = dataset.Tables[1].ToList<AcctProfileT2>();
            doc.T3 = dataset.Tables[2].ToList<AcctProfileT3>();
            return doc;     
        }


    }
}


