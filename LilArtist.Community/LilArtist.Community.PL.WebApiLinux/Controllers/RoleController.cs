using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LilArtist.Community.BLL.Interfaces;
using LilArtist.Community.PL.WebApiLinux.Mappers;
using RolePL = LilArtist.Community.PL.WebApiLinux.Models.Role;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using DependensyResolver = LilArtist.Community.Dependencies.DependencyResolver;

namespace LilArtist.Community.PL.WebApiLinux.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService roleService = DependensyResolver.Instance.roleService;
        IMapper<RoleBLL, RolePL> roleMapper = new RoleMapper();

        [HttpGet]
        [Route("/[controller]/[action]/{id:int}")]
        public async Task<ActionResult<RolePL>> Get(int id)
        {
            var role = roleMapper.Map(roleService.Get(id));

            if (role != null)
                return Ok(role);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("/[controller]/[action]/{login}")]
        public async Task<ActionResult<RolePL>> Get(string name)
        {
            var role = roleMapper.Map(roleService.Get(name));

            if (role != null)
                return Ok(role);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<RolePL>>> GetAll()
        {
            var roles = roleMapper.Map(roleService.GetAll());

            if (roles != null)
                return Ok(roles);
            else
                return NotFound();
        }
    }
}
