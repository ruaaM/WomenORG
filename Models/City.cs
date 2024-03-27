using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class City : General
    {
        [Key]
        public int CityID { get; set; }
        public String Name { get; set; } = null!;
        public int ProvinceID { get; set; }

        [ForeignKey("ProvinceID")]
        public virtual Province? Province { get; set; }
    }
}
