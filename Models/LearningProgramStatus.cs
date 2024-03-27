using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class LearningProgramStatus:General
    {
        [Key]
        public int LearningProgramStatusID { get; set; }
        public String Name { get; set; } = null!;
        public int Order { get; set; }
        public Boolean IsFinal { get; set; }
        public String? ColorCode { get; set; }
        public String? Icon { get; set; }
    }
}
