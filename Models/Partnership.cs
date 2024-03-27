using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Partnership:General
    {
        [Key]
        public int PartnershipID { get; set; }
        public String PartnerOrganization { get; set; } = null!;
        public DateTime? PartnershipStartDate { get; set; }
        public DateTime? PartnershipEndDate { get; set; }
        public String? Email { get; set; }
        public String? ContactName { get; set; }
        public String? ContactEmail { get; set; }
        public String? Duration { get; set; }
        public String? ContactPhoneNumber { get; set; }
        public virtual int? LocationID { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location? Location { get; set; }
        public String? Caption { get; set; }
    }
}
