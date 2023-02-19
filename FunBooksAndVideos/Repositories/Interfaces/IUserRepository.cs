using FunBooksAndVideos.Context.Models;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
