using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();

            CreateMap<Language, DeletedLanguageDto>().ReverseMap();

            CreateMap<UpdateLanguageCommand, Language>();
            CreateMap<Language, UpdatedLanguageDto>();

            CreateMap<Language, GetByIdLanguageDto>();

            CreateMap<IPaginate<Language>, GetListLanguageModel>();
            CreateMap<Language, GetListLanguageDto>();
        }
    }
}
