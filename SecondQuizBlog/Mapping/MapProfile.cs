using AutoMapper;
using SecondQuizBlog.Entities;
using SecondQuizBlog.Models;

namespace SecondQuizBlog.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Post, ListPostViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreatePostViewModel, Post>();
        }
    }
}
