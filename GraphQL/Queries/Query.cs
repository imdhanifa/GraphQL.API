using GraphQL.Types;
public class Query : ObjectGraphType
{
    public Query(BookQuery bookQuery, AuthorQuery authorQuery)
    {
        Field<BookQuery>("book")
            .Description("Book related queries.")
            .Resolve(context => bookQuery);

        Field<AuthorQuery>("author")
            .Description("Author related queries.")
            .Resolve(context => authorQuery);
    }
}
