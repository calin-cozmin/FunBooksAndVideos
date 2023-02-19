using System.ComponentModel.DataAnnotations;
using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Context.Models
{
    public class Membership
    {
        public Membership()
        {
            UserMemberships = new List<UserMembership>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required] public bool IsActive { get; set; }

        public ICollection<UserMembership> UserMemberships { get; set; }
    }
}
