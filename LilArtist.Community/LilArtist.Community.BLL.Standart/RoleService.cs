using Role = LilArtist.Community.BLL.Entities.Role;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.DAL.Interfaces;

namespace LilArtist.Community.BLL.Standart
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Role? Get(int id)
        {
            return _roleRepository.Get(id);
        }

        public Role? Get(string name)
        {
            return _roleRepository.Get(name);
        }

        public IEnumerable<Role>? GetAll()
        {
            return _roleRepository.GetAll();
        }
    }
}
