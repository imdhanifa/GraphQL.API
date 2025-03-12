using GraphQL;
using GraphQL.Types;
public class BookMutation : ObjectGraphType
{
    public BookMutation(IRepository<Book> bookRepository)
    {
        Field<BookType>(
            "addBook",
            description: "Adds a new book.",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "title" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "authorId" }
            ),
            resolve: context =>
            {
                var title = context.GetArgument<string>("title");
                var authorId = context.GetArgument<int>("authorId");
                return bookRepository.Add(new Book(0, title, authorId));
            }
        );

        Field<BooleanGraphType>(
            "deleteBook",
            description: "Deletes a book by its ID.",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return bookRepository.Delete(id);
            }
        );
    }
}
