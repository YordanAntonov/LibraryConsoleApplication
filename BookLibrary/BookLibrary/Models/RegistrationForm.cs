using BookLibrary.IO.Contracts;
using BookLibrary.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class RegistrationForm : IRegistrationForm
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private const int usernamMin = 6;
        private const int passwordMin = 7;
        IStartMenu start;

        public RegistrationForm(IWriter writer, IReader reader, IStartMenu start)
        {
            this.writer = writer;
            this.reader = reader;
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.start = start;
        }

        public void ChoseOption(int num)
        {
            Console.Clear();
            string comand = num.ToString();

            switch (comand)
            {
                case "1":
                    this.RegisterForm();
                    Console.Clear();
                    start.DisplayOptions();
                    break;
                case "2":
                    Console.Clear();
                    start.DisplayOptions();
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
        public void DisplayOptions()
        {
            writer.WriteLine("1. Register");
            writer.WriteLine("2. Go back");

            writer.Write("Enter number here: ");
            int enteredNum = int.Parse(reader.ReadLine());
            ChoseOption(enteredNum);
        }

        public void Exit()
        {
            start.DisplayOptions();
        }

        public void LogIn()
        {
            throw new NotImplementedException();
        }

        public IAccountInterface RegisterForm()
        {
            writer.WriteLine("REGISTRATION FORM:");
            writer.WriteLine("Welcome to Library App, we are happy to have you!!!");
            writer.WriteLine($"NOTE: The username must have more then {usernamMin} characters! And the password must have more then {passwordMin} characters!");
            writer.WriteLine();

            writer.Write("Enter new username: ");
            string username = reader.ReadLine();
            writer.WriteLine();
            writer.Write("Enter new password: ");
            string password = reader.ReadLine();

            IAccountInterface acc = this.ReturnAccount(username, password);

            writer.WriteLine("Thank you for your time! ENJOY");
            Thread.Sleep(2000);
            return acc;
        }

        public IAccountInterface ReturnAccount(string usename, string password)
        {
            IAccountInterface acc = new Account(reader, writer, usename, password, start);
            return acc;
        }
    }
}
