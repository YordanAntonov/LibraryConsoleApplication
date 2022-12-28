namespace BookLibrary
{
    using BookLibrary.Core;
    using BookLibrary.Core.Contracts;
    using BookLibrary.IO;
    using BookLibrary.IO.Contracts;
    using BookLibrary.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
