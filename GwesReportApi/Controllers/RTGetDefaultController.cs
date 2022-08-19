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
    public class RTGetDefaultController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public RTGetDefaultController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        /*[Authorize]*/
        public RTGetDefault Account([FromBody] gdInput acctInput)
        {

            var rtGetDefault = new RTGetDefault();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("RT_GetDefault", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@EmailAdrs", acctInput.EmailAdrs);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            rtGetDefault.Contact = dataset.Tables[0].ToList<GetDefaultContact>();
            rtGetDefault.Role = dataset.Tables[1].ToList<GetDefaultRole>();
            return rtGetDefault;
        }


    }
}


