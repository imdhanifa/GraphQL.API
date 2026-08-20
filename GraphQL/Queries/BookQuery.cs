using GraphQL;
using GraphQL.Types;
public class BookQuery : ObjectGraphType
{
    public BookQuery(IRepository<Book> bookRepository)
    {
        Field<ListGraphType<BookType>>("books")
            .Description("Retrieves all books.")
            .Resolve(context => bookRepository.GetAll());

        Field<BookType>("book")
            .Description("Retrieves a specific book by its ID.")
            .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
            .Resolve(context => bookRepository.GetById(context.GetArgument<int>("id")));
    }
}
