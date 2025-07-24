using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core
{
    using AutoMapper;
    using Portfolio.API.Models.DTOs;
    using Portfolio.Core.Entities;

    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            // Experience
            //CreateMap<Experience, ExperienceDto>()
            //    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToString("yyyy-MM-dd")))
            //    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? src.EndDate.Value.ToString("yyyy-MM-dd") : null)).ReverseMap();

            CreateMap<Experience, ExperienceDto>()
                // Location קיים ב-Entity אבל לא ב-DTO, אז לא ממפים אותו
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<ExperienceDto, Experience>()
                .ForMember(dest => dest.Location, opt => opt.Ignore()) // Location לא קיים ב-DTO, אז מתעלמים ממנו כאן
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)); 
            

            // Profile
            CreateMap<MyProfile, MyProfileDto>().ReverseMap();

            // Project
            CreateMap<Project, ProjectDto>().ReverseMap();
        
        }
    }


}
