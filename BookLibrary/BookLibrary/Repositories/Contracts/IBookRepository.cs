namespace BookLibrary.Repositories.Contracts
{
    using BookLibrary.Models.Contracts;

    public interface IBookRepository
    {
        IReadOnlyCollection<IBook> Models { get; }

        void Add(IBook book);

        IBook SearchByName(string name);

        bool RemoveBook(IBook name);
    }
}
