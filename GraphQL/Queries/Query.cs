using GraphQL.Types;
public class Query : ObjectGraphType
{
    public Query(BookQuery bookQuery, AuthorQuery authorQuery)
    {
        Field<BookQuery>(
            "book",
            description: "Book related queries.",
            resolve: context => bookQuery
        );

        Field<AuthorQuery>(
            "author",
            description: "Author related queries.",
            resolve: context => authorQuery
        );
    }
}
