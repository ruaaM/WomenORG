namespace WomenORG.DTOs
{
    public class ParticipantDTO
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? Nationality { get; set; }
        public String? PhoneNumber { get; set; }
        public String? PlaceOfWork { get; set; }
        public int? Age { get; set; }
        public Boolean? Gender { get; set; }
        public Boolean? IsEmployee { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? StreetID { get; set; }
        public List<int>? SpecializationIDs { get; set; } = new List<int>();
        public String? Description { get; set; }
        public String? EnrollmentDescription { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public Boolean? Status { get; set; }
        public List<String>? ParticipantImagesPaths { get; set; } = new List<String>();

    }
}
