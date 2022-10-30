using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.BLL.Interfaces
{
    public interface IUserService
    {
        UserResult Add(User user);
        IEnumerable<User>? GetAll();
        void Edit(User user);
        void Remove(int id);
        void Remove(string login);
        User? Get(int id);
        User? Get(string login);
        UserResult Auth(string login, string password);
        void SetRole(User user, Role role);
    }
}
