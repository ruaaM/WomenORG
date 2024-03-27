using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Continent:General
    {
        [Key]
        public int ContinentID { get; set; }
        public String Name { get; set; } = null!;
        public int? Countries { get; set; }

    }
}
