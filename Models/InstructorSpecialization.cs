using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class InstructorSpecialization:General
    {
        [Key]
        public int InstructorSpecializationID { get; set; }
        public virtual int? InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public virtual Instructor? Instructor { get; set; }
        public virtual int SpecializationID { get; }

        [ForeignKey("SpecializationID")]
        public virtual Specialization? Specialization { get; set; }
    }
}
