namespace WomenORG.DTOs
{
    public class EnrollmentDTO
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
        public DateTime? EnrollmentDate { get; set; }
        public int? StreetID { get; set; }
        public int SpecializationID { get; set; }
        public int ParticipantID { get; set; }
        public int LearningProgramDetailsID { get; set; }
        public int EnrollmentStatusID { get; set; }
        public int? PaymentStatusID { get; set; }
        public String? Description { get; set; }
        public String? CreateBy { get; set; }
        public String? UpdateBy { get; set; }
        public Boolean? Status { get; set; }
    }
}
