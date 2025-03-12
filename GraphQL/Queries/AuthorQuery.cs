using GraphQL;
using GraphQL.Types;
public class AuthorQuery : ObjectGraphType
{
    public AuthorQuery(IRepository<Author> authorRepository)
    {
        Field<ListGraphType<AuthorType>>(
            "authors",
            description: "Retrieves all authors.",
            resolve: context => authorRepository.GetAll()
        );

        Field<AuthorType>(
            "author",
            description: "Retrieves a specific author by his ID.",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
            resolve: context => authorRepository.GetById(context.GetArgument<int>("id"))
        );
    }
}
