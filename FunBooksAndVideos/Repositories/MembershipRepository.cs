using FunBooksAndVideos.Context;
using FunBooksAndVideos.Context.Models;
using FunBooksAndVideos.Repositories.Base;
using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Repositories
{
    public class MembershipRepository : BaseRepository<Membership, FunBooksAndVideosDbContext>, IMembershipRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public MembershipRepository(
            Lazy<FunBooksAndVideosDbContext> context, 
            ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Membership>> GetMemberships()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetMemberships)} - retrieving items from database");

            return await DbSet
                .ToListAsync();
        }

        public async Task<Membership?> GetMembershipById(int membershipId)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(GetMembershipById)} - retrieving item for id {membershipId} from database");

            return await GetByIdAsync(membershipId);
        }

        public async Task AddMembership(Membership membership)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(AddMembership)} - retrieving item for id {membership} from database");

            await InsertAsync(membership);
        }

        public void UpdateMembership(Membership membership)
        {
            _logger.LogInformation(new EventId(2), $"{nameof(UpdateMembership)} - retrieving item for id {membership} from database");

            Update(membership);
        }
    }
}
