using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Enrollment:General
    {
        [Key]
        public int EnrollmentID { get; set; }
        public virtual int ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public virtual Participant? Participant { get; set; }
        public virtual int LearningProgramDetailsID { get; set; }

        [ForeignKey("LearningProgramDetailsID")]
        public virtual LearningProgramDetails? LearningProgramDetails { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual int EnrollmentStatusID { get; set; }

        [ForeignKey("EnrollmentStatusID")]
        public virtual EnrollmentStatus? EnrollmentStatus { get; set; }
        public Double? Grade { get; set; }
        public virtual int? PaymentStatusID { get; set; }

        [ForeignKey("PaymentStatusID")]
        public virtual PaymentStatus? PaymentStatus { get; set; }

    }
}
