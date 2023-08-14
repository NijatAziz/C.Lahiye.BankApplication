using BankApplication.Main;
using BankApplication.Repostroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Service
{
    internal class UserService
    {
        public IUserRepositroy userRepository;

        public UserService(Bank bank)
        {
            userRepository = new UserRepositroy(bank);
        }

        public bool Registration(string name, string surname, string email, string password, bool isAdmin)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("-->Bu email artiq istifade edilib...");
                    Thread.Sleep(3000);
                    return false;
                }
            }
            User user = new User(name, surname, email, password, isAdmin);
            userRepository.Registration(user);
            return true;
        }
    
        public void Logged(string email, string password)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email) && userList.Password.Equals(password))
                {
                    userRepository.Logged(userList);
                    MenuService.BankService();
                }
            }
            Console.WriteLine("--> Qeydiyyat tamamlanmadi...");
            Thread.Sleep(3000);
        }

        public void FindUser(string email)
        {
            foreach (User userList in userRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    userRepository.FindUser(userList);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Bitdi...");
            Thread.Sleep(1500);
        }
    }
}
