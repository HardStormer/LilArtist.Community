using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleDAL = LilArtist.Community.DAL.Entities.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using LilArtist.Community.DAL.Interfaces;

namespace LilArtist.Community.DAL.SQL
{
    public class RoleRepository : IRoleRepository
    {
        public RoleBLL? Get(int id)
        {
            using (var context = new CommunityDbContext())
            {
                var role = context.roles.Where(x => x.Id == id)
                    .Select(role => new RoleBLL
                    {
                        Id = role.Id,
                        Name = role.Name
                    }).FirstOrDefault();
                return role;
            }
        }

        public RoleBLL? Get(string name)
        {
            using (var context = new CommunityDbContext())
            {
                var role = context.roles.Where(x => x.Name == name)
                    .Select(role => new RoleBLL
                    {
                        Id = role.Id,
                        Name = role.Name
                    }).FirstOrDefault();
                return role;
            }
        }

        public IEnumerable<RoleBLL>? GetAll()
        {
            using (var context = new CommunityDbContext())
            {
                var roles = context.roles.Select(role => new RoleBLL
                {
                    Id = role.Id,
                    Name = role.Name
                }).ToList();
                return roles;
            }
        }
    }
}
