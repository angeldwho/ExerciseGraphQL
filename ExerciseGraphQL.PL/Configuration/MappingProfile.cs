using AutoMapper;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;
using ExerciseGraphQL.PL.ViewModel;

namespace ExerciseGraphQL.PL.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<AuthorModel, AuthorViewModel>().ReverseMap();

            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<BookModel, BookViewModel>().ReverseMap();

            CreateMap<Magazine, MagazineModel>().ReverseMap();
        }
    }
}
