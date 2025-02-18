using Application.ViewModels.Authentication;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MapperConfigs
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            // MappingsAuthentication
            CreateMap<AccountRegistrationDTO, Account>()
                .ForMember(dest => dest.AccountPassword, opt => opt.Ignore())
                .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => true)) // Default status
                .ForMember(dest => dest.AccountIsExternal, opt => opt.MapFrom(src => src.AccountIsExternal))
                .ForMember(dest => dest.AccountExternalProvider, opt => opt.MapFrom(src => src.AccountExternalProvider ?? null));
        }
    }
}
