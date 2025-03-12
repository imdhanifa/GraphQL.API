using GraphQL.Types;
public class AuthorSchema : Schema
{
    public AuthorSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<AuthorQuery>();
        Mutation = provider.GetRequiredService<AuthorMutation>();
    }
}
