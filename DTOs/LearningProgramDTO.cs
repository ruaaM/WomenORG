namespace WomenORG.DTOs
{
    public class LearningProgramDTO
    {
        public int LearningProgramDetailsID { get; set; }
        public String Name { get; set; } = null!;
        public int LearningProgramTypeID { get; set; }
        public String? Duration { get; set; }
        public int? LocationID { get; set; }
        public Boolean? isOnline { get; set; }
        public Double? Price { get; set; } = 0.0;
        public int? EnrollmentLimit { get; set; }
        public String Requirements { get; set; } = "No Requirements";
        public String? Curriculum { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Boolean? CompletionCertificate { get; set; }
        public int? LearningProgramStatusID { get; set; }
        public int SpecializationID { get; set; }
        public String? Description { get; set; }
        public String? CreateBy { get; set; } = "No";
        public String? UpdateBy { get; set; }
        public Boolean? Status { get; set; }
        public int? InstructorID { get; set; }
        public List<String>? learningProgramImagesPaths { get; set; } = new List<string>();

    }
}
