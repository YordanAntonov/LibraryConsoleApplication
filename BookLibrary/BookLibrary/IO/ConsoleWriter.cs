using BookLibrary.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj.ToString());
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
