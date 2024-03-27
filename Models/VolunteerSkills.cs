using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class VolunteerSkills:General
    {
        [Key]
        public int VolunteerSkillsID { get; set; }
        public virtual int SkillsID { get; set; }

        [ForeignKey("SkillsID")]
        public virtual Skills? Skills { get; set; }
        public virtual int VolunteerID { get; set; }

        [ForeignKey("VolunteerID")]
        public virtual Volunteer? Volunteer { get; set;}

    }
}
