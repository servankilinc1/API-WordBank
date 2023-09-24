using AutoMapper;
using DataAccess.DTO;
using DataAccess.Entity;

namespace WebApplication1.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Word, WordRequest>().ReverseMap();
            CreateMap<Word, WordUpdateRequest>().ReverseMap();


            CreateMap<Category, CategoryResponse>().ReverseMap();

            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
        }
    }
}
