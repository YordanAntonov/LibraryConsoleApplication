using BookLibrary.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.IO
{
    public class ConsoleReader : IReader
    {
        public void ReadKey() => Console.ReadKey();
        

        public string ReadLine() => Console.ReadLine();
        
    }
}
