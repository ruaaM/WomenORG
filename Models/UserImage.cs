using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class UserImage:General
    {
        [Key]
        public int UserImageID { get; set; }
        public String? FileName { get; set; }
        public String? FilePath { get; set; }
        public virtual int? FileTypesID { get; set; }

        [ForeignKey("FileTypesID")]
        public virtual FileTypes? FileTypes { get; set; }
    }
}
