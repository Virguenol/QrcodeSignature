using GroupDocs.Signature.Domain;
using GroupDocs.Signature.Options;
using Grs.BioRestock.Domain.Entities;
using Grs.BioRestock.Infrastructure.Contexts;
using Grs.BioRestock.Shared.Wrapper;
using Grs.BioRestock.Transfer.DataModels.Demandesignature;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroupDocs.Signature;
using System;
using Grs.BioRestock.Shared.Enums.DemandeSignature;
using Grs.BioRestock.Transfer.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Grs.BioRestock.Application.Interfaces.Services;

namespace Grs.BioRestock.Server.Services.DemandeSignatureService
{
    public interface IDemandeSignatureService
    {
        Task<Result<List<DemandeSingatureDto>>> GetDemandeSignature();
        Task<Result<DemandeSingatureDto>> GetByIdDemandeSingature(int id);
        Task<Result<string>> AddDemandeSignature(DemandeSingatureDto demandeSignature);
        Task<Result<string>> DeleteDemandeSignature(int id);
        Task<Result<string>> AnnuleDemande(int id);
        Task<Result<string>> SignerDemande(DemandeSingatureDto demandeSignature);
    }
    public class DemandeSignatureService : IDemandeSignatureService
    {
        private readonly UniContext  _context;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IUploadService _uploadService;


        /// <summary>
        /// The ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public DemandeSignatureService(UniContext context, IUploadService uploadService, IWebHostEnvironment env,
            IConfiguration configuration)
        {
            _context = context;
            _env = env;
            _configuration = configuration;
            _uploadService = uploadService;

        }

        public async Task<Result<string>> AddDemandeSignature(DemandeSingatureDto demandeSignature)
        {
            //var folderName = "files";
            //var fileStorage = _configuration.GetValue<string>("FileStorage");
            //demandeSignature.FileUrl = Path.Combine(folderName, demandeSignature.FileName);

            //var streamData = new MemoryStream(demandeSignature.FileData);
            //if (streamData.Length > 0)
            //{
            //    var pathToSave = Path.Combine(fileStorage, folderName);
            //    bool exists = Directory.Exists(pathToSave);
            //    if (!exists)
            //        System.IO.Directory.CreateDirectory(pathToSave);
            //    var fullPath = Path.Combine(pathToSave, demandeSignature.FileName);

            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        streamData.CopyTo(stream);
            //    }
            //}
            var uploadRequest = demandeSignature.UploadRequest;
            if (uploadRequest != null)
            {
                demandeSignature.FileName = uploadRequest.FileName = $"D-{Guid.NewGuid()}{uploadRequest.Extension}";
            }

            if (demandeSignature.Id == 0)
            {
                var demande = demandeSignature.Adapt<DemandeSignature>();
                if(uploadRequest != null)
                {
                     demandeSignature.FileUrl = _uploadService.UploadAsync(uploadRequest);

                }
                demande.FileUrl = demandeSignature.FileUrl;
                demande.FileName = demandeSignature?.FileName;
                demande.CreatedOn = DateTime.Now;
                demande.DateEtablissement = DateTime.Now;
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
            if(demande != null && demande.demandeStatut != DemandeStatut.Signé)
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

        public async Task<Result<string>> SignerDemande(DemandeSingatureDto demandeSignature)
        {
           var folderName = "files";
            var fileStorage = _configuration.GetValue<string>("FileStorage");
            var rawDocument = Path.Combine(fileStorage, demandeSignature.FileName);

            var code_url = Guid.NewGuid().ToString();
            using (Signature signature = new(rawDocument))
            {
                var signed = $"C:/Users/hp/Desktop/Signature/DemandeSignature/src/Client/wwwroot/files/{code_url}";

                QrCodeSignOptions options = new(signed)
                {
                    EncodeType = QrCodeTypes.QR,
                    Left = 0,
                    Top = 95,
                    Width = 35,
                    Height = 35,
                    LocationMeasureType = MeasureType.Percents,
                    ReturnContentType = FileType.TXT
                    
                };
                var signedFileUrl = Path.Combine(folderName, $"{code_url}.pdf");
                signature.Sign(Path.Combine(fileStorage, signedFileUrl), options);

                var demande = await _context.DemandeSignatures.SingleOrDefaultAsync(x => x.Id == demandeSignature.Id);
                demande.FileUrlsSigne = signedFileUrl;
                demande.DateSignature = DateTime.Now;
                demande.demandeStatut = DemandeStatut.Signé;
                demande.CodeSignature = code_url;
                _context.DemandeSignatures.Update(demande);
                await _context.SaveChangesAsync();
            }
            return await Result<string>.SuccessAsync("le documement a été signer");
        }

        public async Task<Result<string>> AnnuleDemande(int id)
        {
            var demande = await _context.DemandeSignatures.SingleOrDefaultAsync(x => x.Id == id);
            if (demande == null)
            {
                return await Result<string>.SuccessAsync("la demande n'existe pas");
            }
            demande.demandeStatut = DemandeStatut.Annulé;
            demande.DateAnnulation = DateTime.Now;
            _context.DemandeSignatures.Update(demande);
            await _context.SaveChangesAsync();
            return await Result<string>.SuccessAsync("Demande Annulé");
        }
    }
}
