using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class MembershipRepository : BaseRepository<Membership, FunBooksAndVideosDbContext>, IMembershipRepository
    {
        public MembershipRepository(Lazy<FunBooksAndVideosDbContext> context) : base(context)
        {
        }

        public async Task<List<Membership>> GetMemberships()
        {
            return await DbSet
                .ToListAsync();
        }

        public async Task<Membership?> GetMembershipById(int membershipId)
        {
            return await GetByIdAsync(membershipId);
        }

        public async Task AddMembership(Membership membership)
        {
           await InsertAsync(membership);
        }

        public void UpdateMembership(Membership membership)
        {
            Update(membership);
        }
    }
}
