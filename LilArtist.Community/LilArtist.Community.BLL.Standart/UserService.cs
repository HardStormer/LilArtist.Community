using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.DAL.Interfaces;
using LilArtist.Community.BLL.Entities;

namespace LilArtist.Community.BLL.Standart
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserResult Add(User user)
        {
            var users = _userRepository.GetAll();
            if (users != null)
            {
                bool hasSameLogin = users.Any(x => x.Login == user.Login);
                if (!hasSameLogin)
                {
                    var result = _userRepository.Add(user);
                    return new UserResult
                    {
                        User = user,
                        Status = true,
                        ResultMsg = "Authorized"
                    };
                }
                else
                {
                    return new UserResult
                    {
                        User = user,
                        Status = false,
                        ResultMsg = "Found login with same params"
                    };
                }
            }
            else
            {
                var result = _userRepository.Add(user);
                return new UserResult
                {
                    User = result,
                    Status = true,
                    ResultMsg = "Authorized"
                };
            }
        }

        public UserResult Auth(string login, string password)
        {
            var user = _userRepository.Get(login);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    return new UserResult
                    {
                        User = user,
                        Status = true,
                        ResultMsg = "Authorized"
                    };
                }
                else
                {
                    return new UserResult
                    {
                        User = null,
                        Status = false,
                        ResultMsg = "Password error"
                    };
                }
            }
            else
            {
                return new UserResult
                {
                    User = null,
                    Status = false,
                    ResultMsg = "Login error"
                };
            }
        }

        public void Edit(User user)
        {
            _userRepository.Edit(user);
        }

        public User? Get(int id)
        {
            return _userRepository.Get(id);
        }

        public User? Get(string login)
        {
            return _userRepository.Get(login);
        }

        public IEnumerable<User>? GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Remove(int id)
        {
            if (Get(id) != null)
            {
                _userRepository.Remove(id);
            }
        }

        public void Remove(string login)
        {
            if (Get(login) != null)
            {
                _userRepository.Remove(login);
            }
        }

        public void SetRole(User user, Role role)
        {
            _userRepository.SetRole(user, role);
        }
    }
}
