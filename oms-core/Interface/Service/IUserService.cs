using oms_core.Views;

namespace oms_core.Interface.Service
{
    public interface IUserService
    {
        Task AddUser(SignupRequest req);

        Task DeleteUser(int id);

        Task UpdateUser(UpdateUserRequest user);

        PaginatedResponse<UserResponse> ListUsers(PaginatedRequest<UserListRequest> req);

        Task UpdatePassword(ChangePasswordRequest req);

        Task<string> Signin(SigninRequest req);
    }
}
