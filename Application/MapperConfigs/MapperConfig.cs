using Application.ViewModels.Authentication;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperConfigs
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            MappingSubject();
        }

        public void MappingSubject()
        {
            CreateMap<AccountRegistrationDTO, Account>()
                    .ForMember(dest => dest.Password, opt => opt.Ignore()) 
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Active")) 
                    .ForMember(dest => dest.ExternalProvider, opt => opt.Condition(src => src.IsExternal)); 
        }
    }
}
