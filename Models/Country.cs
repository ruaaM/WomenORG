using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class Country : General
    {
        [Key]
        public int CountryID { get; set; }
        public String Name { get; set; } = null!;
        public String? CountryCode { get; set; }
        public String? Capital { get; set; }
        public virtual int? ContinentID { get; set; }

        [ForeignKey("ContinentID")]
        public virtual Continent? Contient { get; set; }
        public virtual int? CurrencyID { get; set; }

        [ForeignKey("CurrencyID")]
        public virtual Currency? Currency { get; set; }
        public virtual int? LanguageID { get; set; }

        [ForeignKey("LanguageID")]
        public virtual Language? Language { get; set; }
        public String? Flag { get; set; }
    }
}
