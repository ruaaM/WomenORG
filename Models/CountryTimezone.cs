using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class CountryTimezone:General
    {
        [Key]
        public int CountryTimezoneID { get; set; }
        public virtual int CountryID { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country? Country { get; set; }
        public virtual int TimezoneID { get; set; }
        [ForeignKey("TimezoneID")]
        public virtual Timezone? Timezone { get; set; }
    }
}
