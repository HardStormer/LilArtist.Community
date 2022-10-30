using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LilArtist.Community.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Role>? Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }

    }
}
