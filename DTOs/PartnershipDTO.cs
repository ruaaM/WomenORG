namespace WomenORG.DTOs
{
    public class PartnershipDTO
    {
        public String PartnerOrganization { get; set; } = null!;
        public DateTime? PartnershipStartDate { get; set; }
        public DateTime? PartnershipEndDate { get; set; }
        public String? Email { get; set; }
        public String? ContactName { get; set; }
        public String? ContactEmail { get; set; }
        public String? Duration { get; set; }
        public String? ContactPhoneNumber { get; set; }
        public virtual int? LocationID { get; set; }
        public List<String>? PartnershipImagesPaths { get; set; } = new List<String>();
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public String? Caption { get; set; }

    }
}
