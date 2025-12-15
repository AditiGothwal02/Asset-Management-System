using AssetManagementWebApi.Models;
using AssetManagementWebApi.DTO;

namespace AssetManagementWebApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
        Task LogoutAsync(int userId);
    }

}
