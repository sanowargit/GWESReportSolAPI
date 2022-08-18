using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using GwesReportApi.Inventory;
using GwesReportApi.Models;
using Microsoft.EntityFrameworkCore;
using GwesReportApi.Helpers;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using  Newtonsoft.Json;
using System.Text;
using System;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

namespace GwesReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public DocController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }
        
        [HttpPost]
        /*[Authorize]*/
        public List<DocModel> Doc()
        {
            /*var currentUser = HttpContext.User;
            var docs = _context
                     .DbDocs
                     .FromSqlRaw("exec AdvGetDoc")
                     .ToList();
            return docs;*/
            var doc = new List<DocModel>();
            var database = new GwesDbContext();
            var connection= database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("AdvGetDoc", (Microsoft.Data.SqlClient.SqlConnection)connection);
            //command.Parameters.AddWithValue("@id", 1);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;

            adapter.Fill(dataset);
            doc = dataset.Tables[0].ToList<DocModel>();
            return doc;
        }

      
    }
}
