using AutoMapper;
using UserResultBLL = LilArtist.Community.BLL.Entities.UserResult;
using UserResultPL = LilArtist.Community.PL.WebApi.Models.UserResult;
using UserBLL = LilArtist.Community.BLL.Entities.User;
using UserPL = LilArtist.Community.PL.WebApi.Models.User;

namespace LilArtist.Community.PL.WebApi.Mappers
{
    public class UserResultMapper : IMapper<UserResultBLL, UserResultPL>
    {
        IMapper<UserBLL, UserPL> userMapper = new UserMapper();
        public UserResultBLL Map(UserResultPL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserResultPL, UserResultBLL>()
            .ForMember(x => x.User, x => x.MapFrom(y => userMapper.Map(y.User)))
            .ForMember(x => x.Status, x => x.MapFrom(y => y.Status))
            .ForMember(x => x.ResultMsg, x => x.MapFrom(y => y.ResultMsg))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<UserResultPL, UserResultBLL>(model);
            return newModel;
        }

        public UserResultPL Map(UserResultBLL model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserResultBLL, UserResultPL>()
            .ForMember(x => x.User, x => x.MapFrom(y => userMapper.Map(y.User)))
            .ForMember(x => x.Status, x => x.MapFrom(y => y.Status))
            .ForMember(x => x.ResultMsg, x => x.MapFrom(y => y.ResultMsg))
            );
            var mapper = config.CreateMapper();
            var newModel = mapper.Map<UserResultBLL, UserResultPL>(model);
            return newModel;
        }

        public IEnumerable<UserResultBLL> Map(IEnumerable<UserResultPL> model)
        {
            if (model != null)
            {
                List<UserResultBLL> models = new List<UserResultBLL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserResultPL, UserResultBLL>()
                .ForMember(x => x.User, x => x.MapFrom(y => userMapper.Map(y.User)))
                .ForMember(x => x.Status, x => x.MapFrom(y => y.Status))
                .ForMember(x => x.ResultMsg, x => x.MapFrom(y => y.ResultMsg))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<UserResultPL, UserResultBLL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }

        public IEnumerable<UserResultPL> Map(IEnumerable<UserResultBLL> model)
        {
            if (model != null)
            {
                List<UserResultPL> models = new List<UserResultPL>();
                foreach (var role in model)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserResultBLL, UserResultPL>()
                .ForMember(x => x.User, x => x.MapFrom(y => userMapper.Map(y.User)))
                .ForMember(x => x.Status, x => x.MapFrom(y => y.Status))
                .ForMember(x => x.ResultMsg, x => x.MapFrom(y => y.ResultMsg))
                );
                    var mapper = config.CreateMapper();
                    var newModel = mapper.Map<UserResultBLL, UserResultPL>(role);
                    models.Add(newModel);
                }

                return models;
            }
            else return null;
        }
    }
}
