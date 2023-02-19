using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Context.Models
{
    public class UserMembership
    {
        [ForeignKey("User")] public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Membership")] public int MembershipId { get; set; }

        public Membership Membership { get; set; }

        public bool IsActive { get; set; }

        public DateTime Started { get; set; }

        public DateTime Ended { get; set; }
    }
}
