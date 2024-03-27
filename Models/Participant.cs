using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Participant:General
    {
        [Key]
        public int ParticipantID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? Nationality { get; set; }
        public String? PhoneNumber { get; set; }
        public String? PlaceOfWork { get; set; }
        public int? Age { get; set; }
        public Boolean? Gender { get; set; }
        public Boolean? IsEmployee { get; set; }
        public DateTime? DateofBirth { get; set; }
        public virtual int? StreetID { get; set; }

        [ForeignKey("StreetID")]
        public virtual Street? Street { get; set; }
      
    }
}
