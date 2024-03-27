using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Volunteer:General
    {
        [Key]
        public int VolunteerID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Experience { get; set; }
        public String? AdditionalInformation { get; set; }
        public DateTime? AvailabilityStartDate { get; set; }
        public DateTime? AvailabilityEndDate { get; set; }
        public virtual int StreetID { get; set; }

        [ForeignKey("StreetID")]
        public virtual Street? Street { get; set; }
    }
}
