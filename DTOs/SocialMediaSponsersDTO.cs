namespace WomenORG.DTOs
{
    public class SocialMediaSponsersDTO
    {
        public String Name { get; set; } = null!;
        public String LinkURL { get; set; } = null!;
        public virtual int SponsorID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public Boolean Status { get; set; }
    }
}
