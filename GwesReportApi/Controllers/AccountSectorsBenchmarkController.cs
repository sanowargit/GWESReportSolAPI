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
    public class AccountSectorsBenchmarkController : Controller
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public AccountSectorsBenchmarkController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }

        [HttpPost]
        public AcctSectOutput AccountSectorsBenchmark([FromBody] AcctSectInputs AcctSectInputs)
        {

            var AcctSectOutput = new AcctSectOutput();
            var database = new GwesDbContext();
            var connection = database.Database.GetDbConnection();
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();

            var command = new SqlCommand("ADV_AccountSectorsBenchmark", (Microsoft.Data.SqlClient.SqlConnection)connection);
            command.Parameters.AddWithValue("@mSpUserId", AcctSectInputs.mSpUserId);
            command.Parameters.AddWithValue("@mBenchMarkId", AcctSectInputs.mBenchMarkId);
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            AcctSectOutput.OcAcctSectT1 = dataset.Tables[0].ToList<AcctSectT1>();
            AcctSectOutput.OcAcctSectT2 = dataset.Tables[0].ToList<AcctSectT2>();
            return AcctSectOutput;
        }
    }
}
