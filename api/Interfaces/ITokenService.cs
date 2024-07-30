using WebApplication1.api.Models;

namespace WebApplication1.api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
