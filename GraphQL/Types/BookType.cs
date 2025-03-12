using GraphQL.Types;
public class BookType : ObjectGraphType<Book>
{
    public BookType()
    {
        Name = "Book";
        Field(b => b.Id).Description("The unique identifier of the book.");
        Field(b => b.Title).Description("The title of the book.");
        Field(b => b.AuthorId).Description("The author of the book.");
    }
}
