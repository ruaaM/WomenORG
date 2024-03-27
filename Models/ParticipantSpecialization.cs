using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class ParticipantSpecialization : General
    {
        [Key]
        public int ParticipantSpecializationID { get; set; }
        public virtual int? ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public virtual Participant? Participant { get; set; }
        public int SpecializationID { get; set; }

        [ForeignKey("SpecializationID")]
        public virtual Specialization? Specialization { get; set; }
    }
}
