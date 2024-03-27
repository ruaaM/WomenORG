namespace WomenORG.DTOs
{
    public class VolunteerDTO
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Experience { get; set; }
        public String? AdditionalInformation { get; set; }
        public DateTime? AvailabilityStartDate { get; set; }
        public DateTime? AvailabilityEndDate { get; set; }
        public int StreetID { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
    }
}
