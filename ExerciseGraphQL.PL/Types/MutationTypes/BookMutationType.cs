using ExerciseGraphQL.PL.Mutations;

namespace ExerciseGraphQL.PL.Types.MutationTypes
{
    public class BookMutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(m => m.AddBook(default, default))
                .Argument("title", arg => arg.Type<NonNullType<StringType>>())
                .Argument("author", arg => arg.Type<NonNullType<IntType>>())
                .Type<NonNullType<BookType>>();

            descriptor.Field(m => m.UpdateBook(default, default, default))
                .Argument("id", arg => arg.Type<NonNullType<IntType>>())
                .Argument("title", arg => arg.Type<NonNullType<StringType>>())
                .Argument("author", arg => arg.Type<NonNullType<IntType>>())
                .Type<NonNullType<BookType>>();

            descriptor.Field(m => m.DeleteBook(default))
                .Argument("id", arg => arg.Type<NonNullType<IntType>>())
                .Type<NonNullType<BooleanType>>();
        }
    }
}
