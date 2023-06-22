using API.Models.Dto.Account;
using System.Threading.Tasks;

namespace API.Services.IServices
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailSendDto emailSend);
    }
}