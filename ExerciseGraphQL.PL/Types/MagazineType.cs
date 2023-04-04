using ExerciseGraphQL.BLL.Models;

namespace ExerciseGraphQL.PL.Types
{
    public class MagazineType : ObjectType<MagazineModel>
    {
        protected override void Configure(IObjectTypeDescriptor<MagazineModel> descriptor)
        {
            descriptor.Field(a => a.Id).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.Title).Type<NonNullType<StringType>>();
            descriptor.Field(a => a.YearPublished).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.AuthorId).Type<NonNullType<IntType>>();
        }
    }
}
