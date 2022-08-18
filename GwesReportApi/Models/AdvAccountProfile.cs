using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GwesReportApi.Models
{
    public class AdvAccountProfile
    {
        public List<AcctProfileT1> T1 { get; set; }
        public List<AcctProfileT2> T2 { get; set; }
        public List<AcctProfileT3> T3 { get; set; }


    }
    public class AcctProfileT1
    {
        public int AcctId { get; set; }
        //--Sort Fields
        public string ExtrnlAcctId { get; set; }
        public decimal MrktVlAmt { get; set; }
        public decimal AvailableCash { get; set; }
        public decimal ExcludedCash { get; set; }
    }

    public class AcctProfileT2
    {
        public int AcctId { get; set; }
        //--Sort Fields
        public int MjrAstTypId { get; set; }
        public string MjrAstType { get; set; }
        public decimal MrktVlAmt { get; set; }
        public decimal Mv { get; set; }
        public decimal MvPercent { get; set; }
    }


    public class AcctProfileT3
    {
        public int AcctId { get; set; }
        //--Sort Fields
        public int MjrAstTypId { get; set; }
        public int MnrAstTypId { get; set; }

        public string MnrAstType { get; set; }
        public decimal MrktVlAmt { get; set; }
        public decimal Mv { get; set; }
        public decimal MvPercent { get; set; }


    }

    public class acctInput
    {
        public int UserId { get; set; }
        public int RoleTypId { get; set; }
        public int AcctId { get; set; }


    }

}
