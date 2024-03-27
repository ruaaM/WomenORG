using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class EnrollmentStatus: General
    {
        [Key]
        public int EnrollmentStatusID { get; set; }
        public String Name { get; set; } = null!;
        public Boolean IsFinal { get; set; }
        public int Order { get; set; }
        public String? ColorCode { get; set; }

    }
}
