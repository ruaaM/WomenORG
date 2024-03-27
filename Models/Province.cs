using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Province : General
    {
        [Key]
        public int ProvinceID { get; set; }
        public String Name { get; set; } = null!;
        public virtual int CountryID { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country? Country { get; set; }

    }
}
