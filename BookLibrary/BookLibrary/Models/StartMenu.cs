namespace BookLibrary.Models
{
    using BookLibrary.ExceptionMessages;
    using BookLibrary.IO;
    using BookLibrary.IO.Contracts;
    using BookLibrary.Models.Contracts;
    using System.Text;

    public class StartMenu : IStartMenu
    {
        private const double programVersion = 0.1;
        private readonly List<IAccountInterface> accounts;
        private readonly AccountAuthenticator authenticator;

        private readonly IReader reader;
        private readonly IWriter writer;
        public StartMenu()
        {
            accounts = new List<IAccountInterface>();
            authenticator = new AccountAuthenticator(accounts);
        }
        public StartMenu(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void ChoseOption(int num)
        {
            Console.Clear();
            string option = num.ToString();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    IRegistrationForm register = new RegistrationForm(writer, reader, this);
                    IAccountInterface accont = register.RegisterForm();
                    accounts.Add(accont);
                    Console.Clear();
                    this.ChoseOption(2);
                    break;
                case "2":
                    Console.Clear();
                    this.LogIn();

                    break;
                case "3":
                    Console.Clear();
                    writer.WriteLine("Have a nice day! :)");
                    Thread.Sleep(1000);
                    this.Exit();
                    break;
                default:
                    Console.Clear();
                    writer.WriteLine("Invalid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    this.DisplayOptions();
                    break;
            }
        }

        public void DisplayOptions()
        {
            writer.WriteLine($"Welcome To Your Personal Library Application VERSION {programVersion}!!!");
            writer.WriteLine();
            writer.WriteLine("Write a number corresponding to the lines that are below, in order to access them!");
            writer.WriteLine();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Create new Library Account");
            sb.AppendLine("2. Log In Account");
            sb.AppendLine("3. Exit application");
            writer.WriteLine(sb.ToString());

            writer.Write("Enter number here: ");
            int enteredNum = int.Parse(reader.ReadLine());
            ChoseOption(enteredNum);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void LogIn()
        {
            writer.WriteLine("LOG IN FORM: ");
            writer.WriteLine("Welcome to the app :)");

            writer.WriteLine();
            writer.Write("Enter your username: ");
            string username = reader.ReadLine();
            writer.WriteLine();
            writer.Write("Enter your password: ");
            string password = reader.ReadLine();
            IAccountInterface account = authenticator.CheckAccount(username, password);
            if (account == null)
            {
                writer.WriteLine("********************************************************************************");
                writer.WriteLine(ExceptionMessages.InvalidLogIn);
                writer.WriteLine("********************************************************************************");
                writer.WriteLine("If you want to make an accout press [1].");
                writer.WriteLine("To try again press [2].");
                writer.WriteLine("To exit press [3].");
                string option = reader.ReadLine();

                if (option == "1")
                {
                    this.ChoseOption(1);
                }
                else if (option == "2")
                {
                    Console.Clear();
                    this.LogIn();
                }
                else
                {
                    Console.Clear();
                    this.DisplayOptions();
                }
            }
            else
            {
                Console.Clear();
                account.DisplayOptions();
            }
        }
    }
}
