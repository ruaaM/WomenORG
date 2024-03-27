using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Location: General
    {
        [Key]
        public int LocationID { get; set; }
        public String Name { get; set; } = null!;
        public virtual int StreetID { get; set; }

        [ForeignKey("StreetID")]
        public virtual Street? Street { get; set; }
    }
}
