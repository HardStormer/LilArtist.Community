using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.DAL.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role>? GetAll();
        Role? Get(int id);
        Role? Get(string name);
    }
}
