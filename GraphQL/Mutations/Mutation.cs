using GraphQL.Types;
public class Mutation : ObjectGraphType
{
    public Mutation(BookMutation bookMutation, AuthorMutation authorMutation)
    {
        Field<BookMutation>(
            "book",
            description: "Book related mutations.",
            resolve: context => bookMutation
        );

        Field<AuthorMutation>(
            "author",
            description: "Author related mutations.",
            resolve: context => authorMutation
        );
    }
}
