using GraphQL.Types;
public class AuthorType : ObjectGraphType<Author>
{
    public AuthorType()
    {
        Name = "Author";
        Field(a => a.Id).Description("The unique identifier of the author.");
        Field(a => a.Name).Description("The name of the author.");
    }
}
