using AutoMapper;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class MapperProfile : Profile
    {
        public void UserProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
