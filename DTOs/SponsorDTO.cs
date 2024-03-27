using WomenORG.Models;

namespace WomenORG.DTOs
{
    public class SponsorDTO
    {
        public String Name { get; set; } = null!;

        public String? Email { get; set; }
        public String? ContactName { get; set; }
        public String? ContactEmail { get; set; }
        public String? ContactPhoneNumber { get; set; }
        public int? LocationID { get; set; }
        public String? Caption { get; set; }
        public DateTime? SponsorshipStartDate { get; set; }
        public DateTime? SponsorshipEndDate { get; set; }
        public String? Duration { get; set; }
        public List<SocialMediaSponsersDTO> SocialMediaLinksSponsers { get; set; } = new List<SocialMediaSponsersDTO>();
        public String? Description { get; set; } = null!;
        public List<int>? LearningProgramDetailsID { get; set; } = new List<int>();
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public Boolean? Status { get; set; }
        public List<String>? SponsorImagesPaths { get; set; } = new List<String>();

    }
}
