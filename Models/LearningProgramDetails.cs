using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class LearningProgramDetails: General
    {
        [Key]
        public int LearningProgramDetailsID { get; set; }
        public String? Name { get; set; }
        public virtual int LearningProgramTypeID { get; set; }

        [ForeignKey("LearningProgramTypeID")]
        public virtual LearningProgramType? LearningProgramType { get; set; }
        public String? Duration { get; set; }
        public virtual int? LocationID { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location? Location { get; set; }
        public Double? Price { get; set; }
        public int? EnrollmentLimit { get; set; }
        public String? Requirements { get; set; }
        public String? Curriculum { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Boolean? CompletionCertificate { get; set; }
        public virtual int? LearningProgramStatusID { get; set; }

        [ForeignKey("LearningProgramStatusID")]
        public virtual LearningProgramStatus? LearningProgramStatus { get; set; }
        public Boolean? isOnline { get; set; }
    }
}
