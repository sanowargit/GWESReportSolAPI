using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GwesReportApi.Models
{
    public class RTGetDefault
    {
        public List<GetDefaultContact> Contact { get; set; }
        public List<GetDefaultRole> Role { get; set; }
    }
    public class GetDefaultContact
    {
        public int CntctId { get; set; }
        public string Nm { get; set; }
    }
    public class GetDefaultRole
    {
        public int RoleTypId { get; set; }
        public string RoleTypDesc { get; set; }
    }
    public class gdInput
    {
        public string EmailAdrs { get; set; }
    }
}
