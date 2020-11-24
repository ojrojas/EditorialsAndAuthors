using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITokenClaims 
    {
        Task<string> GetTokenAsync(string userName, string Password);
    }
}