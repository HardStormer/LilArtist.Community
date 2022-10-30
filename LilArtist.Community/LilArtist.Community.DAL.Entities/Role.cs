using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LilArtist.Community.DAL.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
