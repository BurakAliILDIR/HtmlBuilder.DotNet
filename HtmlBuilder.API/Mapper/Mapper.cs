using AutoMapper;
using HtmlBuilder.API.CQRS.Component.Find;
using HtmlBuilder.API.CQRS.Component.GetAll;
using HtmlBuilder.API.CQRS.Page.Find;
using HtmlBuilder.API.CQRS.Page.GetAll;
using HtmlBuilder.API.CQRS.User.GetAll;
using HtmlBuilder.API.Entities;

namespace HtmlBuilder.API.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AppUser, GetAllUserDto>().ReverseMap();
            CreateMap<Page, GetAllPageDto>().ReverseMap();
            CreateMap<Page, FindPageDto>().ReverseMap(); 
            CreateMap<Component, FindComponentDto>().ReverseMap();
            CreateMap<Component, GetAllComponentDto>().ReverseMap();
        }
    }
}