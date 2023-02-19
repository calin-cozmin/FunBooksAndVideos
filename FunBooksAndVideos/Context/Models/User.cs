using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Context.Models
{
    public class User
    {
        public User()
        {
            UserMemberships = new List<UserMembership>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public ICollection<UserMembership> UserMemberships { get; set; }
    }
}
