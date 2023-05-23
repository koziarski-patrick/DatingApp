using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile // This class will be used to map the properties from one class to another
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AppUser, MemberDto>(); // Map the properties from AppUser to MemberDto
            CreateMap<Survey, SurveyDto>(); // Map the properties from Survey to SurveyDto
        }
    }

}