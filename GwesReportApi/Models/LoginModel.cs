using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GwesReportApi.Models
{
    
    public class UserModel
    {
        
        public string Username { get; set; }
        public string Password { get; set; }        
    }
}
