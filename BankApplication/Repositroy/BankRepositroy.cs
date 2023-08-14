using BankApplication.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repostroy
{
    internal class BankRepositroy : IBankRepositroy
    {
        Bank _bank;
        public Bank bank { get { return _bank; } }

        public BankRepositroy(Bank bank)
        {
            _bank = bank;
        }

        public void CheckBalance(User user)
        {
            Console.WriteLine("Sizin balansiniz:");
            Console.WriteLine(user.Balance);
            Thread.Sleep(2000);
        }

        public void UpdateBalance(User user)
        {
            Console.WriteLine("Sizin yeni balansiniz:");
            Console.WriteLine(user.Balance);
            Thread.Sleep(2000);
        }

        public void ChangePassword(User user)
        {
            Console.WriteLine("Sifre ugurla deyisdirildi");
            Thread.Sleep(2000);
        }
        public void UserList(User user)
        {
            foreach (User userList in _bank.Users)
            {
                Console.WriteLine($"Ad Soyad: {userList.Name} {userList.Surname}");
                Console.WriteLine($"Email: {userList.Email}");
                Console.WriteLine($"ID: {userList.Id}");
                Thread.Sleep(2000);
            }
        }

        public void BlockUser(User user)
        {
            Console.WriteLine($"User: {user.Name} {user.Surname} Blokdlandi!");
            Thread.Sleep(2000);
        }

        public void UnBlockUser(User user)
        {
            user.IsBlocked = false;
            Console.WriteLine($"User: {user.Name} {user.Surname} Blokdan cixarildi!");
            Thread.Sleep(2000);
        }

        public void Logout(Bank bank)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}
