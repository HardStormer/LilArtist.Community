using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.PL.WebApi.Mappers;
using UserPL = LilArtist.Community.PL.WebApi.Models.User;
using UserBLL = LilArtist.Community.BLL.Entities.User;
using UserResultPL = LilArtist.Community.PL.WebApi.Models.UserResult;
using UserResultBLL = LilArtist.Community.BLL.Entities.UserResult;
using RolePL = LilArtist.Community.PL.WebApi.Models.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using DependensyResolver = LilArtist.Community.Dependencies.DependencyResolver;

namespace LilArtist.Community.PL.WebApi.Controllers
{
    [Route("communityApi/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService = DependensyResolver.Instance.userService;
        IMapper<UserBLL, UserPL> userMapper = new UserMapper();
        IMapper<UserResultBLL, UserResultPL> userResultMapper = new UserResultMapper();
        IRoleService roleService = DependensyResolver.Instance.roleService;
        IMapper<RoleBLL, RolePL> roleMapper = new RoleMapper();
        public async Task<ActionResult<UserPL>> Get()
        {
            return Ok();
        }

    }
}
