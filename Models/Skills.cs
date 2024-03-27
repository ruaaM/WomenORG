using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Skills:General
    {
        [Key]
        public int SkillsID { get; set; }
        public String Name { get; set; } = null!;
        public virtual int SpecializationID { get; set; }
        [ForeignKey("SpecializationID")]
        public virtual Specialization? Specialization { get; set; }
    }
}
