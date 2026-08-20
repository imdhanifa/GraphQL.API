using GraphQL;
using GraphQL.Types;
public class BookMutation : ObjectGraphType
{
    public BookMutation(IRepository<Book> bookRepository)
    {
        Field<BookType>("addBook")
            .Description("Adds a new book.")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "authorId" }
            ))
            .Resolve(context =>
            {
                var title = context.GetArgument<string>("title");
                var authorId = context.GetArgument<int>("authorId");
                return bookRepository.Add(new Book(0, title, authorId));
            });

        Field<BooleanGraphType>("deleteBook")
            .Description("Deletes a book by its ID.")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                return bookRepository.Delete(id);
            });
    }
}
