using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Sponsor:General
    {
        [Key]
        public int SponsorID { get; set; }
        public String Name { get; set; } = null!;
        public String? Email { get; set; } 
        public String? ContactName { get; set; } 
        public String? ContactEmail { get; set; } 
        public String? ContactPhoneNumber { get; set; }
        public virtual int? LocationID { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location? Location { get; set; }
        public String? Caption { get; set; } 
        public DateTime? SponsorshipStartDate { get; set; } 
        public DateTime? SponsorshipEndDate { get; set; } 
        public String? Duration { get; set; } 
    }
}
