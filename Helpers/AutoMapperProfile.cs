using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Games;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //User
            CreateMap<User, UserModel>();
            CreateMap<UserRegisterModel, User>();
            CreateMap<UserUpdateModel, User>();

            //Game
            CreateMap<Game, GameModel>();
            CreateMap<GameInsertModel, Game>();
            CreateMap<GameUpdateModel, Game>();
        }
    }
}