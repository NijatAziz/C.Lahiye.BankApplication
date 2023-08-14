using BankApplication.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repostroy
{
    internal interface IBankRepositroy
    {
        public Bank bank { get; }

        public void CheckBalance(User user);
        public void UpdateBalance(User user);
        public void ChangePassword(User user);
        public void UserList(User user);
        public void BlockUser(User user);
        public void UnBlockUser(User user);

        public void Logout(Bank bank);

    }
}
