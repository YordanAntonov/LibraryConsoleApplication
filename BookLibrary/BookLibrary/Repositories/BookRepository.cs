namespace BookLibrary.Repositories
{
    using BookLibrary.Models.Contracts;
    using BookLibrary.Repositories.Contracts;

    public class BookRepository : IBookRepository
    {
        List<IBook> models;

        public BookRepository()
        {
            models = new List<IBook>();
        }
        public IReadOnlyCollection<IBook> Models => models.AsReadOnly();

        public void Add(IBook book)
        {
            models.Add(book);
        }

        public bool RemoveBook(IBook book)
        {
            return models.Remove(book);
        }

        public IBook SearchByName(string name)
        {
            return models.FirstOrDefault(b => b.BookTitle == name);
        }
    }
}
