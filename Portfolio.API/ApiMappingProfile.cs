using Portfolio.API.Models.Post;
using Portfolio.Core.Entities;
using AutoMapper;
using System.Data;
using Portfolio.API.Models.DTOs;


namespace Portfolio.API
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<MyProfilePostModel, MyProfile>();

            CreateMap<ExperiencePostModel, Experience>();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<ProjectPostModel, Project>().ForMember(dest => dest.Technologies, opt => opt.Ignore()); ;
            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<ProjectSkill, ProjectSkillPostModel>().ReverseMap();
            




        }

    }
}
