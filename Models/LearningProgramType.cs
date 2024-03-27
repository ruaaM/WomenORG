using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class LearningProgramType: General
    {
        [Key]
        public int LearningProgramTypeID { get; set; }
        public String? Name { get; set; }
        public String? ProgramCode { get; set; }
        public String? ProgramIcon { get; set; }
    }
}
