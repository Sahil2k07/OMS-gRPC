using oms_core.Entity;
using oms_core.Views;

namespace oms_core.Interface.Repository
{
    public interface IUserRepository
    {
        Task<bool> ValidateEmail(string email);

        Task<User?> GetUser(string email);

        Task<User?> GetUserFromID(int id);

        Task DeleteUser(int id);

        Task UpdateUser(User user);

        (int, List<UserResponse>) ListUsers(PaginatedRequest<UserListRequest> req);

        Task<User> AddUser(User user);

        Task<Profile> AddProfile(Profile profile);
    }
}
