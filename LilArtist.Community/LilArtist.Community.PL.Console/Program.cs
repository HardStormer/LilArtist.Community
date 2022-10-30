using System;
using System.Collections.Generic;
using LilArtist.Community.PL.MyConsole.Models;
using LilArtist.Community.PL.MyConsole.Mappers;
using DependencyResolver = LilArtist.Community.Dependencies.DependencyResolver;



namespace LilArtist.Community.PL.MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var userBLL = DependencyResolver.Instance.userService;
            var roleBLL = DependencyResolver.Instance.roleService;

            IMapper<BLL.Entities.User, PL.MyConsole.Models.User> userMapper = new UserMapper();
            IMapper<BLL.Entities.Role, PL.MyConsole.Models.Role> roleMapper = new RoleMapper();
            IMapper<BLL.Entities.UserResult, PL.MyConsole.Models.UserResult> userResultMapper = new UserResultMapper();


            UserResult currentUser = new UserResult
            {
                User = null,
                Status = false,
                ResultMsg = "No actions"
            };

            while (currentUser.Status == false)
            {
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Registration");
                Console.WriteLine("3 - Users");

                string authChoise = Console.ReadLine();

                switch (authChoise)
                {
                    case "1":
                        Console.WriteLine("Введите логин");

                        var login = Console.ReadLine();

                        Console.WriteLine("Введите пароль");

                        var password = Console.ReadLine();

                        currentUser = userResultMapper.Map(userBLL.Auth(login, password));
                        break;
                    case "2":
                        Console.WriteLine("Введите логин");

                        var newLogin = Console.ReadLine();

                        Console.WriteLine("Введите пароль");

                        var newPassword = Console.ReadLine();

                        currentUser =
                            userResultMapper.Map(
                                userBLL.Add(
                                userMapper.Map(
                                new User(newLogin, newPassword)
                                )));
                        break;
                    case "3":
                        var users = userMapper.Map(userBLL.GetAll());
                        foreach (var user in users)
                        {
                            WriteUser(user);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"Status - {currentUser.Status}, {currentUser.ResultMsg}");
            }
        }

        public static void WriteUser(User user)
        {
            if (user != null)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"User id: {user.Id}");
                Console.WriteLine($"Login: {user.Login}");
                Console.WriteLine("Roles:");
                if (user.Roles != null)
                    foreach (var role in user.Roles)
                    {
                        Console.WriteLine($"{role.Name}");
                    }
                else
                    Console.WriteLine("No roles");
                Console.WriteLine("-------------------------");
            }
            else
            {
                Console.WriteLine("Theres no such author");
            }
        }
    }

}

