using GraphQL;
using GraphQL.Types;
public class AuthorMutation : ObjectGraphType
{
    public AuthorMutation(IRepository<Author> authorRepository)
    {
        Field<AuthorType>(
            "addAuthor",
            description: "Adds a new author.",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }
            ),
            resolve: context =>
            {
                var name = context.GetArgument<string>("name");
                return authorRepository.Add(new Author(0, name));
            }
        );

        Field<BooleanGraphType>(
            "deleteAuthor",
            description: "Deletes an author by his ID.",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return authorRepository.Delete(id);
            }
        );
    }
}
