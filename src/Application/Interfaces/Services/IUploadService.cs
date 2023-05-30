using Grs.BioRestock.Transfer.Requests;

namespace Grs.BioRestock.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}