using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class PaymentStatus: General
    {
        [Key]
        public int PaymentStatusID { get; set; }
        public String Name { get; set; } = null!;
        public Boolean IsFinal { get; set; }
        public int Order { get; set; }
        public String? ColorCode { get; set; }
        public String? Icon { get; set; }
    }
}
