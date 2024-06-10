using Microsoft.AspNetCore.Identity;

namespace DuAnWeb_QLNX.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
