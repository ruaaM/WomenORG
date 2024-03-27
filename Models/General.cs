using System.ComponentModel.DataAnnotations;

namespace WomenORG.Models
{
    public class General
    {
       
        public String? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public Boolean Status { get; set; }
    }
}
