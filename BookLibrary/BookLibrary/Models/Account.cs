namespace BookLibrary.Models
{
    using BookLibrary.ExceptionMessages;
    using BookLibrary.IO;
    using BookLibrary.IO.Contracts;
    using BookLibrary.Models.Contracts;
    using BookLibrary.Repositories;
    using BookLibrary.Repositories.Contracts;
    using System.Text;
    public class Account : IAccountInterface
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IBookRepository books;

        private string username;
        private string password;
        private IStartMenu start;
        public Account()
        {
            books = new BookRepository();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public Account(IReader reader, IWriter writer, string username, string password, IStartMenu start) :  this()
        {
            this.writer = writer;
            this.reader = reader;
            this.Username = username;
            this.Password = password;
            this.start = start;
        }

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 6) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidUsername);
                }
                username = value;
            }
        }
        public string Password
        {
            get { return password; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidPassword);
                }
                password = value;
            }
        }


        public void DisplayOptions()
        {
            writer.WriteLine("Personal Library");
            writer.WriteLine("Select one of the following options:");
            writer.WriteLine();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Add new book");
            sb.AppendLine("2. Delete book from library");
            sb.AppendLine("3. Search for book");
            sb.AppendLine("4. Show Library");
            sb.AppendLine("5. Log off");
            writer.WriteLine(sb.ToString());

            writer.Write("Enter number here: ");
            int enteredNum = int.Parse(reader.ReadLine());
            ChoseOption(enteredNum);
        }
        public string AddBook()
        {
            writer.Write("Enter the name of the book: ");
            string bookTitle = reader.ReadLine();
            writer.Write("Enter the Author of the book: ");
            string author = reader.ReadLine();
            writer.WriteLine();
            string description = this.CreateBookDescription();
            writer.Write("Number of pages in the book: ");
            int numOfPages = int.Parse(reader.ReadLine());

            IBook book = new Book(bookTitle, author, numOfPages, description);

            books.Add(book);

            return $"Succesfully added {book.BookTitle} written by {book.Author} to your Library! {Environment.NewLine}Enjoy Reading!!!";
        }

        public void ChoseOption(int num)
        {
            Console.Clear();
            string comand = num.ToString();

            switch (comand)
            {
                case "1":
                    writer.WriteLine(this.AddBook());
                    this.GettingBackToMain();
                    break;
                case "2":
                    writer.WriteLine(this.DeleteBook());
                    this.GettingBackToMain();
                    break;
                case "3":
                    writer.WriteLine(this.SearchBook());
                    this.GettingBackToMain();
                    break;
                case "4":
                    this.ShowCollection();
                    this.GettingBackToMain();
                    break;
                case "5":
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

        private void GettingBackToMain()
        {
            writer.WriteLine("Press any button to go back to Library menu!");
            reader.ReadKey();
            Console.Clear();
            this.DisplayOptions();
        }

        public string CreateBookDescription()
        {
            writer.WriteLine("Book description must be maximum 200 characters (including spaces)!");
            writer.Write("Description: ");
            string des = reader.ReadLine();

            if (des.Length > 200)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.Invalid_Count_Of_Characters, des.Length));
            }
            string description = des;

            return description;
        }

        public string DeleteBook()
        {
            writer.WriteLine($"Delete menu:");
            writer.WriteLine();
            writer.Write("Enter the name of the book you want to be deleted: ");
            string bookName = reader.ReadLine();
            writer.WriteLine("Loading...");
            Thread.Sleep(4000);
            IBook curBook = books.Models.FirstOrDefault(b => b.BookTitle == bookName);
            if (curBook == null)
            {
                return $"You dont have \"{bookName}\" in your Library";
            }

            books.RemoveBook(curBook);
            return $"Succesfully removed \"{bookName}\" from your library!";
        }


        public void Exit()
        {
            
            start.DisplayOptions();
        }

        public string SearchBook()
        {
            writer.Write("Enter the name of the book to be searched: ");
            string bookName = reader.ReadLine();
            IBook currBook = books.Models.FirstOrDefault(b => b.BookTitle == bookName);
            if (currBook == null)
            {
                return $"You dont have book with title \"{bookName}\" in your Library!";
            }
            writer.Write("Do you want to read the book [Yes/No]: ");
            string answer = reader.ReadLine().ToLower();
            if (answer == "yes")
            {
                currBook.ReadTheBook();
            }

           
            StringBuilder sb = new();
            sb.AppendLine("The book you searched for is:");
            sb.AppendLine(currBook.ToString());

            return sb.ToString().Trim();
        }

        public void ShowCollection()
        {

            int booksCount = books.Models.Count;
            string startText = booksCount == 0 ? "You dont have any books in your Library yet." : $"Congratulations you have {booksCount} in your Library!!!";
            if (booksCount == 0)
            {
                writer.WriteLine(startText);
            }
            else
            {

                writer.WriteLine(startText);
                writer.WriteLine("Choose an option:");
                writer.WriteLine("1. All book that are read.");
                writer.WriteLine("2. All books that are still not read.");
                writer.WriteLine("3. All books.");
                writer.Write("Enter option: ");
                string option = reader.ReadLine();
                ICollection<IBook> selectedBooks = new List<IBook>();
                switch (option)
                {
                    case "1":
                        selectedBooks = books.Models.Where(b => b.IsBookRead).ToList();
                        if (selectedBooks.Count == 0) writer.WriteLine("Empty");
                        break;
                    case "2":
                        selectedBooks = books.Models.Where(b => !b.IsBookRead).ToList();
                        if (selectedBooks.Count == 0) writer.WriteLine("Empty");
                        break;
                    case "3":
                        selectedBooks = books.Models.ToList();
                        break;
                    default:
                        writer.WriteLine("Invalid option!");
                        Console.Clear();
                        this.DisplayOptions();
                        break;
                }
                foreach (var book in selectedBooks)
                {
                    writer.WriteLine(book.ToString());
                    writer.WriteLine();
                }
            }
        }

        public void LogIn()
        {
            throw new NotImplementedException();
        }
    }
}
