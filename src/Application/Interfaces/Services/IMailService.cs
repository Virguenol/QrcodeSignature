using System.Threading.Tasks;
using Grs.BioRestock.Transfer.Requests.Mail;

namespace Grs.BioRestock.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}