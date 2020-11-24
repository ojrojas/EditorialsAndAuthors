using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(ApplicationUser user);
    }
}