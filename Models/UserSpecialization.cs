using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class UserSpecialization:General
    {
        [Key]
        public int UserSpecializationID { get; set; }
        public virtual int SpecializationID { get; }

        [ForeignKey("SpecializationID")]
        public virtual Specialization? Specialization { get; set; }
        public virtual int UserModelID { get; }

        [ForeignKey("Id")]
        public virtual UserModel? UserModel { get; set; }
    }
}
