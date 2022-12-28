using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models.Contracts
{
    public interface IRegistrationForm : IStartMenu
    {
        IAccountInterface RegisterForm();

        IAccountInterface ReturnAccount(string username, string password);
    }
}
