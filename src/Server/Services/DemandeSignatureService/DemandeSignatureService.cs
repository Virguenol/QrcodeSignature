using Grs.BioRestock.Application.Interfaces.Services;
using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Infrastructure.Contexts;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Demandesignature;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Services.DemandeSignatureService
{
    public interface IDemandeSignatureService
    {
        Task<Result<List<DemandeSingatureDto>>> GetDemandeSignature();
        Task<Result<DemandeSingatureDto>> GetByIdDemandeSingature(int id);
        Task<Result<string>> AddDemandeSignature(DemandeSingatureDto demandeSignature);
        Task<Result<string>> DeleteDemandeSignature(int id);
        Task<Result<string>> SignerDemande(int id);
    }
    public class DemandeSignatureService : IDemandeSignatureService
    {
        private readonly UniContext  _context;

        /// <summary>
        /// The ctor
        /// </summary>
        /// <param name="context"></param>
        public DemandeSignatureService(UniContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> AddDemandeSignature(DemandeSingatureDto demandeSignature)
        {
            if(demandeSignature.Id == 0)
            {
                var demande = demandeSignature.Adapt<DemandeSignature>();
                await _context.DemandeSignatures.AddAsync(demande);
                await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("Demade Ajouter");
            }
            else
            {
                var demande = await _context.DemandeSignatures.SingleOrDefaultAsync(x => x.Id == demandeSignature.Id);
                if(demande == null)
                {
                    return await Result<string>.SuccessAsync("la demande n'existe pas");
                }
                demande.Designation = demandeSignature.Designation;
                demande.NomClient = demandeSignature.NomClient;
                    _context.DemandeSignatures.Update(demande);
                await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("la demande a été modifier");
            }
        }

        public async Task<Result<string>> DeleteDemandeSignature(int id)
        {
            var demande = await _context.DemandeSignatures.SingleOrDefaultAsync(x=>x.Id == id);
            if(demande != null)
            {
                 _context.DemandeSignatures.Remove(demande);
                await _context.SaveChangesAsync();
                return await Result<string>.SuccessAsync("La demander a été suprimer");
            }
            else
            {
                return await Result<string>.FailAsync("la demande n'existe pas");
            }
        }

        public async Task<Result<DemandeSingatureDto>> GetByIdDemandeSingature(int id)
        {
            var demande = await _context.DemandeSignatures.SingleOrDefaultAsync(x => x.Id == id);
            var reponse = demande.Adapt<DemandeSingatureDto>();
            return await Result<DemandeSingatureDto>.SuccessAsync(reponse);
        }

        public async Task<Result<List<DemandeSingatureDto>>> GetDemandeSignature()
        {
            var demande = await _context.DemandeSignatures.OrderByDescending(d => d.Id).ToListAsync();
            var response = demande.Adapt<List<DemandeSingatureDto>>();
            return await Result<List<DemandeSingatureDto>>.SuccessAsync(response);
        }

        public Task<Result<string>> SignerDemande(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
