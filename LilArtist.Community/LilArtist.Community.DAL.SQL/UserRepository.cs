using UserDAL = LilArtist.Community.DAL.Entities.User;
using UserBLL = LilArtist.Community.BLL.Entities.User;
using RoleDAL = LilArtist.Community.DAL.Entities.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using LilArtist.Community.DAL.Interfaces;
using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.DAL.SQL
{
    public class UserRepository : IUserRepository
    {
        public UserBLL Add(UserBLL user)
        {
            using (var context = new CommunityDbContext())
            {
                context.users.Add(
                    new UserDAL
                    {
                        Login = user.Login,
                        Password = user.Password,
                        Roles = user.Roles.Select(role =>
                        new RoleDAL
                        {
                            Id = role.Id,
                            Name = role.Name
                        }) as ICollection<RoleDAL>
                    });
                context.SaveChanges();
                return Get(user.Login);
            }
        }

        public void Edit(UserBLL user)
        {
            using (var context = new CommunityDbContext())
            {
                var oldUser = context.users.Find(user.Id);
                
                oldUser = new UserDAL
                {
                    Login = user.Login,
                    Password = user.Password,
                    Roles = user.Roles.Select(role =>
                    new RoleDAL
                    {
                        Id = role.Id,
                        Name = role.Name
                    }) as ICollection<RoleDAL>
                };

                context.SaveChanges();
            }
        }

        public UserBLL? Get(int id)
        {
            using (var context = new CommunityDbContext())
            {
                var user = context.users.Where(x => x.Id == id)
                    .Select(user => new UserBLL
                    {
                        Login = user.Login,
                        Password = user.Password,
                        Roles = user.Roles.Select(role =>
                        new RoleBLL
                        {
                            Id = role.Id,
                            Name = role.Name
                        })
                    }).FirstOrDefault();
                return user;
            }
        }

        public UserBLL? Get(string login)
        {
            using (var context = new CommunityDbContext())
            {
                var user = context.users.Where(x => x.Login == login)
                    .Select(user => new UserBLL
                    {
                        Login = user.Login,
                        Password = user.Password,
                        Roles = user.Roles.Select(role =>
                        new RoleBLL
                        {
                            Id = role.Id,
                            Name = role.Name
                        })
                    }).FirstOrDefault();
                return user;
            }
        }

        public IEnumerable<UserBLL>? GetAll()
        {
            using (var context = new CommunityDbContext())
            {
                var users = context.users.Select(user => new UserBLL
                {
                    Login = user.Login,
                    Password = user.Password,
                    Roles = user.Roles.Select(role =>
                    new RoleBLL
                    {
                        Id = role.Id,
                        Name = role.Name
                    })
                }).ToList();
                return users;
            }
        }

        public void Remove(int id)
        {
            using (var context = new CommunityDbContext())
            {
                var removableUser = context.users
                    .FirstOrDefault(x => x.Id == id);

                if (removableUser != null)
                    context.users.Remove(removableUser);

                context.SaveChanges();
            }
        }

        public void Remove(string login)
        {
            using (var context = new CommunityDbContext())
            {
                var removableUser = context.users
                    .FirstOrDefault(x => x.Login == login);

                if (removableUser != null)
                    context.users.Remove(removableUser);

                context.SaveChanges();
            }
        }

        public void SetRole(UserBLL user, RoleBLL role)
        {
            using (var context = new CommunityDbContext())
            {
                var oldUser = context.users.Find(user.Id);

                oldUser.Roles.Add(
                    new RoleDAL
                    {
                        Id = role.Id,
                        Name = role.Name
                    }
                        );

                context.SaveChanges();
            }
        }
    }
}
