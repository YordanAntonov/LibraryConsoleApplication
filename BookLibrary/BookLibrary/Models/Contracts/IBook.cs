using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models.Contracts
{
    public interface IBook
    {
        string BookTitle { get; }

        string Author { get; }

        string Description { get; }

        int PagesCount { get; }

        bool IsBookRead { get; }

        void ReadTheBook();
        string ToString();
    }
}
