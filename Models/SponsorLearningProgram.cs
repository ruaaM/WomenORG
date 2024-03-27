using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class SponsorLearningProgram: General
    {
        [Key]
        public int SponsorLearningProgramID { get; set; }
        public virtual int? LearningProgramDetailsID { get; set; }

        [ForeignKey("LearningProgramDetailsID")]
        public virtual LearningProgramDetails? LearningProgramDetails { get; set; }
        public virtual int? SponsorID { get; set; }

        [ForeignKey("SponsorID")]
        public virtual Sponsor? Sponsor { get; set; }
        
    }
}
