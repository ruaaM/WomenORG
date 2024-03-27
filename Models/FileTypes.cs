using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class FileTypes:General
    {
        [Key]
        public int FileTypesID { get; set; }
        public String? Name { get; set; }
    }
}
