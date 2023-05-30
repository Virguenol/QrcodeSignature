using AutoMapper;
using Grs.BioRestock.Infrastructure.Models.Identity;
using Grs.BioRestock.Transfer.Requests.Identity;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, UniRoleClaim>()
                .ForMember(nameof(UniRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(UniRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, UniRoleClaim>()
                .ForMember(nameof(UniRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(UniRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}