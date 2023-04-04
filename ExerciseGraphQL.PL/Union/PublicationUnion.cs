using ExerciseGraphQL.DAL.Interfaces;
using ExerciseGraphQL.PL.Types;

namespace ExerciseGraphQL.PL.Union
{
    public class PublicationUnion : UnionType<IPublication>
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("Publication");
            descriptor.Type<BookType>();
            descriptor.Type<MagazineType>();
        }
    }
}
