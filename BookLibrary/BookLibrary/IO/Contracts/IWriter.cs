using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.IO.Contracts
{
    public interface IWriter
    {
        void Write(object obj);

        void WriteLine();
        void WriteLine(object obj);
    }
}
