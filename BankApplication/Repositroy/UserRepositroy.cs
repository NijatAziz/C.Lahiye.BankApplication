using BankApplication.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repostroy
{
    internal class UserRepositroy : IUserRepositroy
    {
        readonly Bank _bank;
        public Bank bank { get { return _bank; } }

        public UserRepositroy(Bank bank)
        {
            _bank = bank;
        }

        public void Registration(User user)
        {
            Array.Resize(ref bank.Users, bank.Users.Length + 1);
            bank.Users[bank.Users.Length - 1] = user;
            Console.WriteLine(" ");
            Console.WriteLine("Qeydiyyat ugurla tamamlandi");
            Thread.Sleep(1500);
        }


        public void Logged(User user)
        {
            if(user.IsBlocked==false)
            {
                user.IsLogged = true;
                Console.WriteLine("Ugurla login oldunuz\n");
                Console.WriteLine($"User: {user.Name} {user.Surname}");
                Console.WriteLine($"IsAdmin status: {user.IsAdmin}");
                Console.WriteLine($"ID: {user.Id}");
            }
            else
            {
                Console.WriteLine("Siz bloklanmisiniz");
            }
     
        }

        public void FindUser(User user)
        {
            Console.WriteLine($"User: {user.Name} {user.Surname}");
            if (user.IsAdmin)
            {
                Console.WriteLine("Admin");
            }
            Thread.Sleep(3000);
        }
    }
}
