using AutoMapper;
using BaProTest.Models;
using BaProTest.Models.DTO;

namespace BaProTest
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Class,TodoModel>().ReverseMap();
        }
    }
}
