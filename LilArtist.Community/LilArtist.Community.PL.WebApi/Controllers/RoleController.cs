using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.PL.WebApi.Mappers;
using RolePL = LilArtist.Community.PL.WebApi.Models.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using DependensyResolver = LilArtist.Community.Dependencies.DependencyResolver;

namespace LilArtist.Community.PL.WebApi.Controllers
{
    [Route("communityApi/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService roleService = DependensyResolver.Instance.roleService;
        IMapper<RoleBLL, RolePL> roleMapper = new RoleMapper();
        [HttpGet]
        public async Task<ActionResult<RolePL>> Get()
        {
            return Ok();
        }
    }
}
