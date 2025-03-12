public class BookRepository : IRepository<Book>
{
    private readonly List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>
        {
            new Book(1, "The Pragmatic Programmer", 1),
            new Book(2, "Clean Code", 2)
        };
    }

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public Book Add(Book book)
    {
        var nextId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
        var newBook = book with { Id = nextId };
        _books.Add(newBook);
        return newBook;
    }

    public bool Delete(int id) => _books.RemoveAll(b => b.Id == id) > 0;
}
