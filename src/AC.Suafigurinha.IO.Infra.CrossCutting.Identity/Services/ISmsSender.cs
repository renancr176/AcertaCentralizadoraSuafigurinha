using System.Threading.Tasks;

namespace AC.Suafigurinha.IO.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
