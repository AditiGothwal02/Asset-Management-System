using AssetManagementWebApi.Models;

namespace AssetManagementWebApi.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }

}
