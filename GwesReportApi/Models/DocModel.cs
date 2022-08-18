using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GwesReportApi.Models
{
    public class DocModel
    {
        public int AttachmentId { get; set; }
        public string NoteAttachment { get; set; }
        public string AttachmentDesc { get; set; }
        public byte[] AttachmentData { get; set; }
        public string ObjectNm { get; set; }
        public string CrtUserNm { get; set; }
        public DateTime CrtDt { get; set; }
    }
    
}
