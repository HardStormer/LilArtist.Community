using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.DAL.Interfaces;
using LilArtist.Community.DAL.SQL;
using LilArtist.Community.BLL.Standart;

namespace LilArtist.Community.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance = null;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();

                return _instance;
            }
        }

        #endregion

        public IUserRepository userRepository => new UserRepository();
        public IRoleRepository roleRepository => new RoleRepository();

        public IUserService userService => new UserService(userRepository);
        public IRoleService roleService => new RoleService(roleRepository);
    }
}
