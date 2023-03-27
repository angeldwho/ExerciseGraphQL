using ExerciseGraphQL.PL.Mutations;

namespace ExerciseGraphQL.PL.Types.MutationTypes
{
    public class AuthorMutationType : ObjectType<AuthorMutation>
    {
        protected override void Configure(IObjectTypeDescriptor<AuthorMutation> descriptor)
        {
            descriptor.Field(m => m.AddAuthor(default))
                .Argument("input", arg => arg.Type<NonNullType<StringType>>())
                .Type<NonNullType<AuthorType>>();

            descriptor.Field(m => m.UpdateAuthor(default, default))
                .Argument("id", arg => arg.Type<NonNullType<IntType>>())
                .Argument("input", arg => arg.Type<NonNullType<StringType>>())
                .Type<NonNullType<AuthorType>>();

            descriptor.Field(m => m.DeleteAuthor(default))
                .Argument("id", arg => arg.Type<NonNullType<IntType>>())
                .Type<NonNullType<BooleanType>>();
        }
    }
}
