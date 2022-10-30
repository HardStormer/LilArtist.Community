using AutoMapper;
using UserBLL = LilArtist.Community.BLL.Entities.User;
using UserPL = LilArtist.Community.PL.MyConsole.Models.User;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using RolePL = LilArtist.Community.PL.MyConsole.Models.Role;

namespace LilArtist.Community.PL.MyConsole.Mappers
{
    public class UserMapper : IMapper<UserBLL, UserPL>
    {
        IMapper<RoleBLL, RolePL> roleMapper = new RoleMapper();
        public UserBLL Map(UserPL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserPL, UserBLL>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Login, x => x.MapFrom(y => y.Login))
            .ForMember(x => x.Password, x => x.MapFrom(y => y.Password))
            .ForMember(x => x.Roles, x => x.MapFrom(y => roleMapper.Map(y.Roles)))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<UserPL, UserBLL>(model);
            return newModel;
        }

        public UserPL Map(UserBLL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserBLL, UserPL>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Login, x => x.MapFrom(y => y.Login))
            .ForMember(x => x.Password, x => x.MapFrom(y => y.Password))
            .ForMember(x => x.Roles, x => x.MapFrom(y => roleMapper.Map(y.Roles)))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<UserBLL, UserPL>(model);
            return newModel;
        }

        public IEnumerable<UserBLL> Map(IEnumerable<UserPL> model)
        {
            if (model != null)
            {
                List<UserBLL> models = new List<UserBLL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserPL, UserBLL>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Login, x => x.MapFrom(y => y.Login))
                .ForMember(x => x.Password, x => x.MapFrom(y => y.Password))
                .ForMember(x => x.Roles, x => x.MapFrom(y => roleMapper.Map(y.Roles)))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<UserPL, UserBLL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }

        public IEnumerable<UserPL> Map(IEnumerable<UserBLL> model)
        {
            if (model != null)
            {
                List<UserPL> models = new List<UserPL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserBLL, UserPL>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Login, x => x.MapFrom(y => y.Login))
                .ForMember(x => x.Password, x => x.MapFrom(y => y.Password))
                .ForMember(x => x.Roles, x => x.MapFrom(y => roleMapper.Map(y.Roles)))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<UserBLL, UserPL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }
    }
}
