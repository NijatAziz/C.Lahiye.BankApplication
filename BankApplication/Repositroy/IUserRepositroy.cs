using BankApplication.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repostroy
{
    internal interface IUserRepositroy

    {
        public Bank bank { get; }
        void Registration(User user);
        void Logged(User user);
        void FindUser(User user);

       
    }
}
