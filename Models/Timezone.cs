using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class Timezone:General
    {
        [Key]
        public int TimezoneID { get; set; }
        public String Name { get; set; } = null!;
        public String? UTCOffset { get; set; } 
        public String? DSTOffset { get; set; } 
        public DateTime? DSTStartDate { get; set; } 
        public DateTime? DSTEndDate { get; set; } 
    }
}
