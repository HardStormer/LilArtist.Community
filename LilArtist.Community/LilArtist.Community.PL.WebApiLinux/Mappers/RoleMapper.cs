using AutoMapper;
using RoleBLL = LilArtist.Community.BLL.Entities.Role;
using RolePL = LilArtist.Community.PL.WebApiLinux.Models.Role;

namespace LilArtist.Community.PL.WebApiLinux.Mappers
{
    public class RoleMapper : IMapper<RoleBLL, RolePL>
    {
        public RoleBLL Map(RolePL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RolePL, RoleBLL>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<RolePL, RoleBLL>(model);
            return newModel;
        }

        public RolePL Map(RoleBLL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleBLL, RolePL>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<RoleBLL, RolePL>(model);
            return newModel;
        }

        public IEnumerable<RoleBLL> Map(IEnumerable<RolePL> model)
        {
            if (model != null)
            {
                List<RoleBLL> models = new List<RoleBLL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<RolePL, RoleBLL>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<RolePL, RoleBLL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }

        public IEnumerable<RolePL> Map(IEnumerable<RoleBLL> model)
        {
            if (model != null)
            {
                List<RolePL> models = new List<RolePL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleBLL, RolePL>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<RoleBLL, RolePL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }
    }
}
