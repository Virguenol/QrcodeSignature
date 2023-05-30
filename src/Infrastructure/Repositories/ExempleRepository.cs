//using System.Linq;
//using System.Threading.Tasks;
//using Grs.BioRestock.Application.Interfaces.Repositories;
//using Grs.BioRestock.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Grs.BioRestock.Infrastructure.Repositories
//{
//    public class DocumentRepository : IDocumentRepository
//    {
//        private readonly IRepositoryAsync<Document, int> _repository;

//        public DocumentRepository(IRepositoryAsync<Document, int> repository)
//        {
//            _repository = repository;
//        }

//        public async Task<bool> IsDocumentTypeUsed(int documentTypeId)
//        {
//            return await _repository.Entities.AnyAsync(b => b.DocumentTypeId == documentTypeId);
//        }

//        public async Task<bool> IsDocumentExtendedAttributeUsed(int documentExtendedAttributeId)
//        {
//            await Task.Delay(1);
//            return false;// await _repository.Entities.AnyAsync(b => b.ExtendedAttributes.Any(x => x.Id == documentExtendedAttributeId));
//        }
//    }
//}