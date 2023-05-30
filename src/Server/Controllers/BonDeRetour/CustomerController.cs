using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Server.Services.Cliient;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Controllers.BonDeRetour
{
    public class CustomerController : ControllerBase
    {
        private readonly IClientService _clientService;

        public CustomerController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet(nameof(GetAllClient))]
        public async Task<Result<List<Customer>>> GetAllClient()
        {
            return await _clientService.GetClients();
        }
    }
}
