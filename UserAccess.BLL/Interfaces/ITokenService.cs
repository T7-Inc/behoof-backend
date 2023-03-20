using UserAccess.DAL.Entities;

namespace UserAccess.BLL.Interfaces;

public interface ITokenService
{
    public string CreateToken(User user);
}