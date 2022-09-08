using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GwesReportApi.Models
{
    
        public class AcctSectInputs
        {
        public int mAsOfId { get; set; }
        public int PageId { get; set; }
        public int mBenchMark { get; set; }
        }

        public class AcctSectT1
        {
            public int AcctId { get; set; }
            public string AccountNumber { get; set; }
            public string AccountName { get; set; }
            public string AcctAlphaSortKey { get; set; }
            public string AccountType { get; set; }
            public int AcctTypeSortKey { get; set; }
            public string Administrator { get; set; }
            public string Admin { get; set; }
            public string Inv { get; set; }
            public string BranchName { get; set; }
            public string InvestmentOfficer { get; set; }
            public bool DateTime { get; set; }
            public bool PageNo { get; set; }
        }

        public class AcctSectT2
        {
            public int AcctId { get; set; }
            public int GroupId { get; set; }
            public int SrtKey { get; set; }
            public string GroupHeader { get; set; }
            public decimal MarketPercent { get; set; }
            public decimal BMPcnt { get; set; }
            public decimal VarBMPcnt { get; set; }
            public decimal PcntOfBMPcnt { get; set; }
            public int ExcldInd { get; set; }
            public int MjrMnrIndstryInd { get; set; }
            public int ModelTypeId { get; set; }
        }

    public class AcctSectOutput
    { 
        public List<AcctSectT1> OcAcctSectT1 { get; set; }
        public List<AcctSectT2> OcAcctSectT2 { get; set; }
    }

 }

