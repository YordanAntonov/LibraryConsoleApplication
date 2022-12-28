namespace BookLibrary.Models.Contracts
{

    public interface IAccountInterface : IStartMenu
    {
        string Username { get; }
        string Password { get; }
        string DeleteBook();

        string AddBook();
        string CreateBookDescription();
        string SearchBook();

        void ShowCollection();
    }
}
