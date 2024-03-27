using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Instructor:General
    {
        [Key]
        public int InstructorID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Biography { get; set; }
        public String? ProfilePicture { get; set; }
        public String? Qualifications { get; set; }
        public String? Experience { get; set; }
    }
}
