namespace BookLibrary.Models.Contracts
{
    public interface IStartMenu
    {
        void ChoseOption(int num);

        void DisplayOptions();

        void LogIn();

        void Exit();
    }
}
