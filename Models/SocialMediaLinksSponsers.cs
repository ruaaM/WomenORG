using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomenORG.Models
{
    public class SocialMediaLinksSponsers:General
    {
        [Key]
        public int SocialMediaLinksSponsorsID { get; set; }
        public String Name { get; set; } = null!;
        public String LinkURL { get; set; } = null!;
        public virtual int SponsorID { get; set; }

        [ForeignKey("SponsorID")]
        public virtual Sponsor? Sponsor { get; set; }

    }
}
