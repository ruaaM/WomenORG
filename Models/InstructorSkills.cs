using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class InstructorSkills:General
    {
        [Key]
        public int InstructorSkillsID { get; set; }
        public virtual int SkillsID { get; set; }

        [ForeignKey("SkillsID")]
        public virtual Skills? Skills { get; set; }

        public virtual int? InstructorID { get; set; }
        [ForeignKey("InstructorID")]
        public virtual Instructor? Instructor { get; set; }
    }
}
