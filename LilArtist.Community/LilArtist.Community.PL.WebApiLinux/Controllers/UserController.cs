using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.PL.WebApiLinux.Mappers;
using UserPL = LilArtist.Community.PL.WebApiLinux.Models.User;
using UserBLL = LilArtist.Community.BLL.Entities.User;
using UserResultPL = LilArtist.Community.PL.WebApiLinux.Models.UserResult;
using UserResultBLL = LilArtist.Community.BLL.Entities.UserResult;
using RolePL = LilArtist.Community.PL.WebApiLinux.Models.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using DependensyResolver = LilArtist.Community.Dependencies.DependencyResolver;

namespace LilArtist.Community.PL.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService = DependensyResolver.Instance.userService;
        IMapper<UserBLL, UserPL> userMapper = new UserMapper();
        IMapper<UserResultBLL, UserResultPL> userResultMapper = new UserResultMapper();
        IRoleService roleService = DependensyResolver.Instance.roleService;
        IMapper<RoleBLL, RolePL> roleMapper = new RoleMapper();

        [HttpPost]
        [Route("/[controller]/[action]/{user:User}")]
        public async Task<ActionResult<UserPL>> Add(UserPL user)
        {
            var userResult = userService.Add(userMapper.Map(user));

            if (userResult.Status == true)
                return Ok(userResult.User);
            else
                return BadRequest(userResult.ResultMsg);

            return Ok(userResult);
        }


        [HttpPost]
        [Route("/[controller]/[action]/{login}/{password}")]
        public async Task<ActionResult<UserPL>> Auth(string login, string password)
        {
            var authResult = userResultMapper.Map(userService.Auth(login, password));
            if (authResult.Status == true)
            {
                return Ok(authResult.User);
            }
            else
            {
                return BadRequest(authResult.ResultMsg);
            }
        }

        [HttpPost]
        [Route("/[controller]/[action]/{user:User}")]
        public async Task<ActionResult<UserPL>> Edit(UserPL user)
        {
            userService.Edit(userMapper.Map(user));
            return Ok(user);
        }

        [HttpGet]
        [Route("/[controller]/[action]/{id:int}")]
        public async Task<ActionResult<UserPL>> Get(int id)
        {
            var user = userMapper.Map(userService.Get(id));

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("/[controller]/[action]/{login}")]
        public async Task<ActionResult<UserPL>> Get(string login)
        {
            var user = userMapper.Map(userService.Get(login));

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<UserPL>>> GetAll()
        {
            var users = userMapper.Map(userService.GetAll());

            if (users != null)
                return Ok(users);
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("/[controller]/[action]/{id:int}")]
        public async Task<ActionResult<UserPL>> Delete(int id)
        {
            userService.Remove(id);
            return Ok();
        }

        [HttpDelete]
        [Route("/[controller]/[action]/{login}")]
        public async Task<ActionResult<UserPL>> Delete(string login)
        {
            userService.Remove(login);
            return Ok();
        }

        [HttpPost]
        [Route("/[controller]/[action]/{user:User}/{role:Role}")]
        public async Task<ActionResult<UserPL>> SetRole(UserPL user, [FromQuery] RolePL role)
        {
            userService.SetRole(userMapper.Map(user), roleMapper.Map(role));
            return Ok();
        }

    }
}
