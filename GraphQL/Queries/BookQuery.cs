using GraphQL;
using GraphQL.Types;
public class BookQuery : ObjectGraphType
{
    public BookQuery(IRepository<Book> bookRepository)
    {
        Field<ListGraphType<BookType>>(
            "books",
            description: "Retrieves all books.",
            resolve: context => bookRepository.GetAll()
        );

        Field<BookType>(
            "book",
            description: "Retrieves a specific book by its ID.",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
            resolve: context => bookRepository.GetById(context.GetArgument<int>("id"))
        );
    }
}
