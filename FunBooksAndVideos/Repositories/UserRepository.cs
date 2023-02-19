using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FunBooksAndVideosDbContext _context;

        public UserRepository(FunBooksAndVideosDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users
                .ToListAsync();
        }
    }
}
