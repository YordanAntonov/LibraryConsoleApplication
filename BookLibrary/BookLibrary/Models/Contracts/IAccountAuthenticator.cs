using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models.Contracts
{
    public interface IAccountAuthenticator
    {
        IAccountInterface CheckAccount(string username, string password);
    }
}
