using Grs.BioRestock.Application.Interfaces.Services;
using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Infrastructure.Contexts;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.BonDeRetourDtos;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Services.Cliient
{
    public interface IClientService
    {
        Task<Result<List<Customer>>> GetClients();
    }
    public class ClientService : IClientService
    {
        private readonly IStringLocalizer<ClientService> _localizer;
        private readonly ICurrentUserService _currentUserService;
        private readonly UniContext _context;

        public ClientService(IStringLocalizer<ClientService> localizer,
            ICurrentUserService currentUserService,
            UniContext context)
        {
            _localizer = localizer;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<Result<List<Customer>>> GetClients()
        {
            var bonderetour = await _context.Customers.ToListAsync();
            var bonderetourResponse = bonderetour.Adapt<List<Customer>>();
            return await Result<List<Customer>>.SuccessAsync(bonderetourResponse);
        }
    }
}
