using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class UserModel:IdentityUser
    {
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Nationality { get; set; }
        public String? PlaceOfWork { get; set; }
        public String? AdditionalInfo { get; set; }
        public Boolean? IsEmployee { get; set; }
        public virtual int? StreetID { get; set; }

        [ForeignKey("StreetID")]
        public virtual Street? Street { get; set; }
        public virtual int? UserImageID { get; set; }

        [ForeignKey("UserImageID")]
        public virtual UserImage? UserImage { get; set; }
    }
}
