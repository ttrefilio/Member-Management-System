using AutoMapper;
using Project.Domain.DTOs;
using Project.Domain.Models;

namespace Project.API.Profiles
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            #region Members
            CreateMap<Member, MemberDTO>();
            #endregion

            #region Accounts
            CreateMap<Account, AccountDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            #endregion

            #region Companies
            CreateMap<Company, CompanyDTO>();
            #endregion
        }
    }
}
