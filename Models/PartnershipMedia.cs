using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class PartnershipMedia:General
    {
        [Key]
        public int PartnershipMediaID { get; set; }
        public String? FileName { get; set; }
        public String? FilePath { get; set; }
        public virtual int? FileTypesID { get; set; }

        [ForeignKey("FileTypesID")]
        public virtual FileTypes? FileTypes { get; set; }
        public virtual int? PartnershipID { get; set; }

        [ForeignKey("PartnershipID")]
        public virtual Partnership? Partnership { get; set; }

    }
}
