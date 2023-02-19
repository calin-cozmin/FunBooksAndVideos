using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FunBooksAndVideos.Repositories
{
    public class UserRepository : BaseRepository<User, FunBooksAndVideosDbContext>,  IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<User>> GetUsers()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetUsers)} - retrieving items from database");

            return await DbSet
                .Include(u => u.UserMemberships)
                .ThenInclude(um => um.Membership)
                .ToListAsync();
        }

        public async Task<User?> GetUserById(int userId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetUserById)} - retrieving item for id {userId} from database");

            return await GetByIdAsync(userId);
        }

        public async Task AddUser(User user)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(AddUser)} - add item {JsonSerializer.Serialize(user)} to database");

            await InsertAsync(user);
        }

        public void UpdateUser(User user)
        {
            _logger.LogInformation(new EventId(4), $"{nameof(UpdateUser)} - update item {JsonSerializer.Serialize(user)} to database");

            Update(user);
        }
    }
}
