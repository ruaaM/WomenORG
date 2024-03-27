using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Language:General
    {
        [Key]
        public int LanguageID { get; set; }
        public String Name { get; set; } = null!;
        public String? Code { get; set; } 
        public String? Icon { get; set; } 

    }
}
