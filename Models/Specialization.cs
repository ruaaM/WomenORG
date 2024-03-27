using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Specialization:General
    {
        [Key]
        public int SpecializationID { get; set; }
        public String Name { get; set; } = null!;

    }
}
