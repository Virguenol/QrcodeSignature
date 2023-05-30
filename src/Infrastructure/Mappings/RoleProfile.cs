using AutoMapper;
using Grs.BioRestock.Infrastructure.Models.Identity;
using Grs.BioRestock.Transfer.Responses.Identity;

namespace Grs.BioRestock.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, UniRole>().ReverseMap();
        }
    }
}