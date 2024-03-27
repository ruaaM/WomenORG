using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class SocialMediaProfilesInstructor:General
    {
        [Key]
        public int SocialMediaProfilesInstructorID { get; set; }
        public String Name  { get; set; }=null!;
        public String ProfileURL  { get; set; }=null!;
        public virtual int InstructorID  { get; set; }
        [ForeignKey("InstructorID")]
        public virtual Instructor? Instructor { get; set; }
    }
}
