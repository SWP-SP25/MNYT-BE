﻿using Application.ViewModels.Authentication;
using Application.ViewModels.MembershipPlan;
using Application.ViewModels.Payment;
using Application.ViewModels.Fetus;
using Application.ViewModels.Pregnancy;
using Application.ViewModels.FetusRecord;
using AutoMapper;
using Domain.Entities;
using Application.ViewModels.Accounts;
using Application.ViewModels.PregnancyStandard;

namespace Infrastructure.MapperConfigs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            MappingAccount();
            MappingMembershipPlan();
            MappingPaymentMethod();
            MappingPregnancy();
            MappingFetus();
            MappingFetusRecord();
            MappingPregnancyStandard();
        }

        private void MappingPregnancyStandard()
        {
            CreateMap<PregnancyStandardVM, PregnancyStandard>().ReverseMap();
        }

        public void MappingAccount()
        {
            CreateMap<AccountRegistrationDTO, Account>()
                    .ForMember(dest => dest.Password, opt => opt.Ignore())
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Active"))
                    .ForMember(dest => dest.ExternalProvider, opt => opt.Condition(src => src.IsExternal));
            CreateMap<Account, AccountDTO>();
        }

        public void MappingMembershipPlan()
        {
            CreateMap<CreateMembershipPlanDTO, MembershipPlan>();
            CreateMap<MembershipPlanDTO, MembershipPlan>();
            CreateMap<MembershipPlan, MembershipPlanDTO>();
        }

        public void MappingPaymentMethod()
        {
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
            CreateMap<TogglePaymentMethodDTO, PaymentMethod>();
        }
        public void MappingPregnancy()
        {
            CreateMap<PregnancyAddVM, Pregnancy>().ReverseMap();
            CreateMap<PregnancyVM, Pregnancy>().ReverseMap();

        }
        public void MappingFetus()
        {
            CreateMap<FetusAddVM, Fetus>().ReverseMap();
            CreateMap<FetusVM, Fetus>().ReverseMap();
        }
        public void MappingFetusRecord()
        {
            CreateMap<FetusRecordAddVM, FetusRecord>().ReverseMap();
            CreateMap<FetusRecordVM, FetusRecord>().ReverseMap();
        }
    }
}
