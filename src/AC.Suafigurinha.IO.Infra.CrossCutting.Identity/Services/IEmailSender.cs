using System.Threading.Tasks;

namespace AC.Suafigurinha.IO.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
