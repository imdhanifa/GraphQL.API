using GraphQL;
using GraphQL.Types;
public class AuthorQuery : ObjectGraphType
{
    public AuthorQuery(IRepository<Author> authorRepository)
    {
        Field<ListGraphType<AuthorType>>("authors")
            .Description("Retrieves all authors.")
            .Resolve(context => authorRepository.GetAll());

        Field<AuthorType>("author")
            .Description("Retrieves a specific author by his ID.")
            .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
            .Resolve(context => authorRepository.GetById(context.GetArgument<int>("id")));
    }
}
