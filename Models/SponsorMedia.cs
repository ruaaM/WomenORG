using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class SponsorMedia:General
    {
        [Key]
        public int SponsorMediaID { get; set; }
        public String? FileName { get; set; }
        public String? FilePath { get; set; }
        public virtual int? FileTypesID { get; set; }

        [ForeignKey("FileTypesID")]
        public virtual FileTypes? FileTypes { get; set; }
        public virtual int? SponsorID { get; set; }

        [ForeignKey("SponsorID")]
        public virtual Sponsor? Sponsor { get; set; }

    }
}
