using AutoMapper;
using Grs.BioRestock.Infrastructure.Models.Identity;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, UniUser>().ReverseMap();
            //CreateMap<ChatUserResponse, UniUser>().ReverseMap()
            //    .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}