using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();

        Task<UserModel> GetUserById(int userId);
    }
}
