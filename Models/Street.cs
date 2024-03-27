using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Street : General
    {
        [Key]
        public int StreetID { get; set; }
        public String Name { get; set; } = null!;
        public virtual int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual City? City { get; set; }
        public String? PostalCode { get; set; }
    }
}
