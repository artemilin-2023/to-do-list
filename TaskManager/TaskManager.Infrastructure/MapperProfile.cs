using AutoMapper;
using TaskManager.Domain;
using TaskManager.Infrastructure.Entities;

namespace TaskManager.Infrastructure
{
    public class MapperProfile : Profile
    {
        public void UserProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
