using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class PortfolioMedia: General
    {
        [Key]
        public int PortfolioMediaID { get; set; }
        public String? FileName { get; set; }
        public String? FilePath { get; set; }
        public virtual int? FileTypesID { get; set; }

        [ForeignKey("FileTypesID")]
        public virtual FileTypes? FileTypes { get; set; }
        public virtual int? LearningProgramDetailsID { get; set; }

        [ForeignKey("LearningProgramDetailsID")]
        public virtual LearningProgramDetails? LearningProgramDetails { get; set; }
  
    }
}
