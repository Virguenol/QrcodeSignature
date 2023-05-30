using Grs.BioRestock.Server.Services.DemandeSignatureService;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Demandesignature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grs.BioRestock.Server.Controllers.DemandeSignature
{
    public class DemandeSignatureController : BaseApiController<DemandeSignatureController>
    {
        private readonly IDemandeSignatureService _demandeSigature;

        /// <summary>
        /// The ctor
        /// </summary>
        /// <param name="demandeSigature"></param>
        public DemandeSignatureController(IDemandeSignatureService demandeSigature)
        {
            _demandeSigature = demandeSigature;
        }

        #region methods

        [HttpGet(nameof(GetAll))]
        public async Task<Result<List<DemandeSingatureDto>>> GetAll()
        {
            return await _demandeSigature.GetDemandeSignature();
        }

        [HttpPost(nameof(AddEditAsync))]
        public async Task<Result<string>> AddEditAsync(DemandeSingatureDto request)
        {
            return await _demandeSigature.AddDemandeSignature(request);  
        }

        [HttpDelete(nameof(DeleteAsync) + "/{id}")]
        public async Task<Result<string>> DeleteAsync(int id)
        {
            return await _demandeSigature.DeleteDemandeSignature(id);
        }

        [HttpGet($"{nameof(GetByIdAsync)}/{{id}}")]
        public async Task<Result<DemandeSingatureDto>> GetByIdAsync(int id)
        {
            return await _demandeSigature.GetByIdDemandeSingature(id);
        }
        #endregion
    }
}
