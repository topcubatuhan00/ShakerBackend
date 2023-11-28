using Shaker.Domain.Entities;

namespace Shaker.Application.Services.Utilities;

public interface IJwtService
{
    string CreateToken(User user);
}
