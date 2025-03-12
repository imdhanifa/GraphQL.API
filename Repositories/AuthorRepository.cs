public class AuthorRepository : IRepository<Author>
{
    private readonly List<Author> _authors;

    public AuthorRepository()
    {
        _authors = new List<Author>
        {
            new Author(1, "Andrew Hunt"),
            new Author(2, "Robert C. Martin")
        };
    }

    public IEnumerable<Author> GetAll() => _authors;

    public Author? GetById(int id) => _authors.FirstOrDefault(a => a.Id == id);

    public Author Add(Author author)
    {
        var nextId = _authors.Any() ? _authors.Max(a => a.Id) + 1 : 1;
        var newAuthor = author with { Id = nextId };
        _authors.Add(newAuthor);
        return newAuthor;
    }

    public bool Delete(int id) => _authors.RemoveAll(a => a.Id == id) > 0;
}
