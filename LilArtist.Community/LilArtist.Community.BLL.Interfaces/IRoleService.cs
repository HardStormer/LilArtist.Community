using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.BLL.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role>? GetAll();
        Role? Get(int id);
        Role? Get(string name);
    }
}
