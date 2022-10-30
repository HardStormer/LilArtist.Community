using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.DAL.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        IEnumerable<User>? GetAll();
        void Edit(User user);
        void Remove(int id);
        void Remove(string login);
        User? Get(int id);
        User? Get(string login);
        void SetRole(User user, Role role);
    }
}
