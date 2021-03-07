using AutoMapper;
using Project.API.Commands.Accounts;
using Project.API.Commands.Companies;
using Project.API.Commands.Members;
using Project.Domain.Enums;
using Project.Domain.Models;
using System;

namespace Project.API.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            #region Members

            CreateMap<CreateMemberCommand, Member>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());
            #endregion

            #region Accounts

            CreateMap<CreateAccountCommand, Account>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<AccountStatus>(src.Status.ToUpper())))
            .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => Guid.Parse(src.MemberId)))
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => Guid.Parse(src.CompanyId)))
            .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            #endregion

            #region Companies

            CreateMap<CreateCompanyCommand, Company>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            #endregion
        }
    }
}
