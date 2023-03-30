using ExerciseGraphQL.BLL.Models;

namespace ExerciseGraphQL.PL.Types
{
    public class BookType : ObjectType<BookModel>
    {
        protected override void Configure(IObjectTypeDescriptor<BookModel> descriptor)
        {
            descriptor.Field(a => a.ID).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.Title).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.AuthorId).Type<NonNullType<IntType>>();
        }
    }
}
