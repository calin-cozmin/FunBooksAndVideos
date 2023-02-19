using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetUsers();

        Task<User?> GetUserById(int userId);

        Task AddUser(User user);

        void UpdateUser(User user);
    }
}
