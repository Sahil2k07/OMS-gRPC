using oms_core.Entity;
using oms_core.Enum;

namespace oms_core.Interface.Service
{
    public interface IAuthService
    {
        string GenerateHash(string plainPassword);

        bool VerifyPassword(string plainPassword, string hashedPassword);

        string GenerateToken(User user);

        bool HasRole(Roles role);

        int GetUserID();

        Task<User> GetUser();

        HashSet<Roles> GetRoles();
    }
}
