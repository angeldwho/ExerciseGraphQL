using ExerciseGraphQL.BLL.Models;

namespace ExerciseGraphQL.PL.Types
{
    public class AuthorType : ObjectType<AuthorModel>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthorModel> descriptor)
        {
            descriptor.Field(a => a.ID).Type<NonNullType<IntType>>();
            descriptor.Field(a => a.Name).Type<NonNullType<StringType>>();

        }
    }
}
