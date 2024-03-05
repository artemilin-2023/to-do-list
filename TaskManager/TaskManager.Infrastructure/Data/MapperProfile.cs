using AutoMapper;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
