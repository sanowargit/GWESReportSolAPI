using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GwesReportApi.Models
{
    
        public class AcctSectInputs
        {
            public int mSpUserId { get; set; }
            public int mBenchMarkId { get; set; }
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
            public int RptTmpltId { get; set; }
            public int RowAltColorIdFirst { get; set; }
            public int RowAltColorIdSecond { get; set; }
            public byte[] LogoFileImage { get; set; }
        }

        public class AcctSectT2
        {
            public int AcctId { get; set; }
            public int GroupId { get; set; }
            public int SrtKey { get; set; }
            public string GroupHeader { get; set; }
            public double MarketPercent { get; set; }
            public double BMPcnt { get; set; }
            public double VarBMPcnt { get; set; }
            public double PcntOfBMPcnt { get; set; }
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

