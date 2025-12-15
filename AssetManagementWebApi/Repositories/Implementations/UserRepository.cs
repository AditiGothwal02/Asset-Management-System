using AssetManagementWebApi.Models;
using AssetManagementWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssetManagementWebApi.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AssetManagementContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

}
