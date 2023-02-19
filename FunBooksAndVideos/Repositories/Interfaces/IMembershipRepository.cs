using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;

namespace FunBooksAndVideos.Repositories.Interfaces
{
    public interface IMembershipRepository : IBaseRepository<Membership>
    {
        Task<List<Membership>> GetMemberships();

        Task<Membership?> GetMembershipById(int userId);

        Task AddMembership(Membership user);

        void UpdateMembership(Membership user);
    }
}
