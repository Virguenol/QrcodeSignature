using Grs.BioRestock.Application.Interfaces.Services;
using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Infrastructure.Contexts;
using Grs.BioRestock.Shared.Enums.BonDeRetour;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.BonDeRetourDtos;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Services.BonDeRetourService
{
    public interface IBonDeRetour
    {
        Task<Result<List<GetBonDeRetourDto>>> GetBonDeRetours();
        Task<Result<GetBonDeRetourDto>> GetByIdBonDeRetour(int id);
        Task<Result<string>> AddBonDeRetour(AddBonDeRetourDto bonderetour);
        Task<Result<string>> DeleteBonDeRetour(int id);
        Task<Result<string>> Validation(int id);
        Task<Result<string>> ChoixDepot(GetBonDeRetourDto request);
    }
    
       
    public class BonDeRetourService : IBonDeRetour
    {
        private readonly IStringLocalizer<BonDeRetourService> _localizer;
        private readonly ICurrentUserService _currentUserService;
        private readonly UniContext _context;

        public BonDeRetourService(
            IStringLocalizer<BonDeRetourService> localizer,
            ICurrentUserService currentUserService,
            UniContext context)
        {
            _localizer = localizer;
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<Result<string>> AddBonDeRetour(AddBonDeRetourDto request)
        {
            if (request.Id == 0)
            {
                var bonderetour = request.Adapt<BonDeRetour>();
                await _context.BonDeRetours.AddAsync(bonderetour);
                await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("the return slip created.");
            }
            else
            {
                var existingBonDeRetour =
                    await _context.BonDeRetours.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (existingBonDeRetour == null)
                {
                    return await Result<string>.SuccessAsync("the return slip does not exist.");
                }
                else
                {
                    existingBonDeRetour.ArticleName = request.ArticleName;
                    existingBonDeRetour.ClientName = request.ClientName;
                    existingBonDeRetour.Quantity = request.Quantity;
                    _context.BonDeRetours.Update(existingBonDeRetour);
                    await _context.SaveChangesAsync();
                    return await Result<string>.SuccessAsync("the return slip {0} for Role {1} updated."); 
                }
            }
        }
        public async Task<Result<string>> DeleteBonDeRetour(int id)
        {
            var existingBonDeRetour = await _context.BonDeRetours.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBonDeRetour != null)
            {
                _context.BonDeRetours.Remove(existingBonDeRetour);
                 await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("the return slip deleted");
            }
            else
            {
                return  await Result<string>.FailAsync("the return slip does not exist.");
            }
        }

        public async Task<Result<List<GetBonDeRetourDto>>> GetBonDeRetours()
        {
            var bonderetour = await _context.BonDeRetours.OrderByDescending(x=>x.Id).Include(c => c.Articles).Include(c => c.Customers).ToListAsync();
            var bonderetourResponse = bonderetour.Adapt<List<GetBonDeRetourDto>>();
            return await Result<List<GetBonDeRetourDto>>.SuccessAsync(bonderetourResponse);
        }

        public async Task<Result<GetBonDeRetourDto>> GetByIdBonDeRetour(int id)
        {
            var bonderetour = await _context.BonDeRetours
                .SingleOrDefaultAsync(x => x.Id == id);
            var bonderetourResponse = bonderetour.Adapt<GetBonDeRetourDto>();
            return await Result<GetBonDeRetourDto>.SuccessAsync(bonderetourResponse);
        }

        public async Task<Result<string>> Validation(int id)
        {
            var bonderetour = await _context.BonDeRetours.FirstOrDefaultAsync(x => x.Id == id);
        
            bonderetour.Status = BonDeRetourStatus.Validé;

            _context.BonDeRetours.Update(bonderetour);
            await _context.SaveChangesAsync();

            var respose = bonderetour.Adapt<GetBonDeRetourDto>();
            return await Result<string>.SuccessAsync("modify successfully");
        }

        public async Task<Result<string>> ChoixDepot(GetBonDeRetourDto request)
        {
            var existingBonDeRetour = await _context.BonDeRetours.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (existingBonDeRetour == null)
            {
                return await Result<string>.SuccessAsync("the return slip does not exist.");
            }
            else
            {
                existingBonDeRetour.Depot = request.Depot;
                _context.BonDeRetours.Update(existingBonDeRetour);
                await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("the return slip {0} for Role {1} updated.");
            }
        }

    }
}
