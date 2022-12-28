namespace BookLibrary.Models
{
    using BookLibrary.ExceptionMessages;
    using BookLibrary.Models.Contracts;
    using System;
    using System.Text;

    public class Book : IBook
    {
        private string bookTitle;
        private string author;
        private int pagesCount;
        private bool isBookRead;

        public Book(string bookTitle, string author, int pagesCount, string shortDescription)
        {
            this.BookTitle = bookTitle;
            this.Author = author;
            this.PagesCount = pagesCount;
            this.Description = shortDescription;
        }
        public string BookTitle
        {
            get { return bookTitle; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_BOOK_TITLE);
                }

                bookTitle = value;
            }
        }

        public string Author
        {
            get { return author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_AUTHOR_NAME);
                }
                author = value;
            }
        }

        public string Description { get; private set; }

        public int PagesCount
        {
            get { return pagesCount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.Invalid_Pages_Count);
                }
                pagesCount = value;
            }
        }

        public bool IsBookRead => isBookRead;

        public void ReadTheBook()
        {
            isBookRead = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book title: [{this.BookTitle}]");
            sb.AppendLine($"Author: [{this.Author}]");
            sb.AppendLine($"Description: ");
            sb.AppendLine($"-- {this.Description} ");
            sb.AppendLine($"Page count: [{this.PagesCount}] ");
            sb.AppendLine($"{(IsBookRead == true ? "You have read this book!" : "This book is not read yet.")}");

            return sb.ToString().TrimEnd();
        }
    }
    
}
