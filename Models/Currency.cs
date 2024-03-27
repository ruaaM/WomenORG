using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Currency:General
    {
        [Key]
        public int CurrencyID { get; set; }
        public String Name { get; set; } = null!;
        public String CurrencyCode { get; set; } = null!;
        public String? Symbol { get; set; } = null!;
        public Double? ExchangeRate { get; set; } = null!;
        public String? Subunit { get; set; } = null!;
        public Double? SubunitValue { get; set; } = null!;

    }
}
