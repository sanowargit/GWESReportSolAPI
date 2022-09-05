using System.Collections.ObjectModel;

namespace GwesReportApi.Models
{
    public class GetModelInfoInput
    {
        public int AcctId { get; set; }
    }
    #region MODEL CLASS
    public class TT3ModelS
    {
        public int ModelId { get; set; }
        public string ModelNm { get; set; }
        public int ModelTypeId { get; set; }
        public string ModelTypeNm { get; set; }
    }

    public class HierarchyLevels
    {
        public int cdid { get; set; }
        public string cdDesc { get; set; }
    }

    public class AccountModelAssociation
    {
        public int ModelId { get; set; }
    }

    public class Portfolio
    {
        public int PortId { get; set; }
        public string Nm { get; set; }
    }



    #endregion
    public class ModelsAndAccount
    {
        public ObservableCollection<TT3ModelS> Model { get; set; }
        public ObservableCollection<AccountModelAssociation> AcctMdl { get; set; }
        public ObservableCollection<Portfolio> Port { get; set; }
        public ObservableCollection<HierarchyLevels> HierarchyLvl { get; set; }
    }
}
