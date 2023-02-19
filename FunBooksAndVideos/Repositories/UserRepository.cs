using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class UserRepository : BaseRepository<User, FunBooksAndVideosDbContext>,  IUserRepository
    {
        public UserRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            return await DbSet
                .Include(u => u.UserMemberships)
                .ThenInclude(um => um.Membership)
                .ToListAsync();
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await GetByIdAsync(userId);
        }

        public async Task AddUser(User user)
        {
           await InsertAsync(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
