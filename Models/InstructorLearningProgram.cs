using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class InstructorLearningProgram:General
    {
        [Key]
        public int InstructorLearningProgramID { get; set; }
        public virtual int? InstructorID { get; set; }

        [ForeignKey("InstructorID")]
        public virtual Instructor? Instructor { get; set; }

        public virtual int? LearningProgramDetailsID { get; set; }

        [ForeignKey("LearningProgramDetailsID")]
        public virtual LearningProgramDetails? LearningProgramDetails { get; set; }
    }
}

