using BookLibrary.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class AccountAuthenticator : IAccountAuthenticator
    {
        private List<IAccountInterface> accounts;

        public AccountAuthenticator(List<IAccountInterface> accounts)
        {
            this.accounts = accounts;
        }

        public IAccountInterface CheckAccount(string username, string password)
        {
            return accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}
