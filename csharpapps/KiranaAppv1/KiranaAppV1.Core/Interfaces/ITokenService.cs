using Microsoft.AspNetCore.Identity;

namespace KiranaAppV1.Core.Interfaces;

public interface ITokenService
{
    string GenerateToken(IdentityUser user, IList<string> roles);
}