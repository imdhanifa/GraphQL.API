using GraphQL.Types;
public class Mutation : ObjectGraphType
{
    public Mutation(BookMutation bookMutation, AuthorMutation authorMutation)
    {
        Field<BookMutation>("book")
            .Description("Book related mutations.")
            .Resolve(context => bookMutation);

        Field<AuthorMutation>("author")
            .Description("Author related mutations.")
            .Resolve(context => authorMutation);
    }
}
