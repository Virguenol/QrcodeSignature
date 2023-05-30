using AutoMapper;
using Grs.BioRestock.Infrastructure.Models.Audit;
using Grs.BioRestock.Transfer.Responses.Audit;

namespace Grs.BioRestock.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}