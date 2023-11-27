using Shaker.Domain.Entities;

namespace Shaker.Application.Utilities;

public interface IJwtService
{
    string CreateToken(User user);
}
