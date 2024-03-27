using AutoMapper;
using WomenORG.DTOs;
using WomenORG.Models;

namespace BlackListSmartNotifications.Helper
{
	public class MappingProfiles : Profile
	{
        public MappingProfiles()
        {
            CreateMap<LearningProgramDetails, LearningProgramDTO>();
            CreateMap<LearningProgramDTO, LearningProgramDetails>();
            CreateMap<Participant, ParticipantDTO>();
            CreateMap<ParticipantDTO, Participant>();
            CreateMap<SponsorDTO, Sponsor>();
            CreateMap<Sponsor, SponsorDTO>();
            CreateMap<Partnership, PartnershipDTO>();
            CreateMap<PartnershipDTO, Partnership>();
            CreateMap<VolunteerDTO, Volunteer>();
            CreateMap<Volunteer, VolunteerDTO>();
        }
    }
}
