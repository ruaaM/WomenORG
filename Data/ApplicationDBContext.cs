using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WomenORG.Models;

namespace WomenORG.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserModel>
    {
        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CountryTimezone> CountryTimezone { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<EnrollmentStatus> EnrollmentStatus { get; set; }
        public DbSet<FileTypes> FileTypes { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstructorLearningProgram> InstructorLearningProgram { get; set; }
        public DbSet<InstructorSkills> InstructorSkills { get; set; }
        public DbSet<InstructorSpecialization> InstructorSpecialization { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LearningProgramDetails> LearningProgramDetails { get; set; }
        public DbSet<LearningProgramSpecialization> LearningProgramSpecialization { get; set; }
        public DbSet<LearningProgramStatus> LearningProgramStatus { get; set; }
        public DbSet<LearningProgramType> LearningProgramType { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<ParticipantSpecialization> ParticipantSpecialization { get; set; }
        public DbSet<Partnership> Partnership { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<PortfolioMedia> PortfolioMedia { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialMediaLinksSponsers> SocialMediaLinksSponsers { get; set; }
        public DbSet<SocialMediaProfilesInstructor> SocialMediaProfilesInstructor { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<SponsorLearningProgram> SponsorLearningProgram { get; set; }
        public DbSet<Street> Street { get; set; }
        public DbSet<Timezone> Timezone { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<VolunteerSkills> VolunteerSkills { get; set; }
        public DbSet<UserImage> UserImage { get; set; }
        public DbSet<ParticipantMedia> ParticipantMedia { get; set; }
        public DbSet<PartnershipMedia> PartnershipMedia { get; set; }
        public DbSet<SponsorMedia> SponsorMedia { get; set; }
    }
}
