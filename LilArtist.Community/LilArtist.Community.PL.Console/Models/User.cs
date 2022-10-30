using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilArtist.Community.PL.MyConsole.Models
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public User(string login, string password, ICollection<Role> roles)
        {
            Login = login;
            Password = password;
            Roles = roles;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role>? Roles { get; set; }
    }
}
