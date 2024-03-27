using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class LearningProgramSpecialization :General
    {
        [Key]
        public int LearningProgramSpecializationID { get; set; }
        public virtual int LearningProgramDetailsID { get; set; }

        [ForeignKey("LearningProgramDetailsID")]
        public virtual LearningProgramDetails? LearningProgramDetails { get; set; }
        public virtual int SpecializationID { get; set; }

        [ForeignKey("SpecializationID")]
        public virtual Specialization? Specialization { get; set; }
    }
}
