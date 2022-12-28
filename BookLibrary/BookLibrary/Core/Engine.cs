using BookLibrary.Core.Contracts;
using BookLibrary.IO.Contracts;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            StartMenu startMenu = new StartMenu(reader, writer);
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                try
                {
                    startMenu.DisplayOptions();
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

        }
    }
}
