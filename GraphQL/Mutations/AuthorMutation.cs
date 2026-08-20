using GraphQL;
using GraphQL.Types;
public class AuthorMutation : ObjectGraphType
{
    public AuthorMutation(IRepository<Author> authorRepository)
    {
        Field<AuthorType>("addAuthor")
            .Description("Adds a new author.")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }
            ))
            .Resolve(context =>
            {
                var name = context.GetArgument<string>("name");
                return authorRepository.Add(new Author(0, name));
            });

        Field<BooleanGraphType>("deleteAuthor")
            .Description("Deletes an author by his ID.")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                return authorRepository.Delete(id);
            });
    }
}
