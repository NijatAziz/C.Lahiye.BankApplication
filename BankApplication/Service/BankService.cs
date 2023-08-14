using BankApplication.Main;
using BankApplication.Repostroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Service
{
    internal class BankService
    {
        public IBankRepositroy _bankRepository;

        public BankService(Bank bank)
        {
            _bankRepository = new BankRepositroy(bank);
        }

        public bool CheckBalance(string password,string email)
        {
            foreach (User user in _bankRepository.bank.Users)
            {
                if (user.Password.Equals(password) && user.Email.Equals(email))
                {
                    _bankRepository.CheckBalance(user);
                    return true;
                }
            }
            return true;
        }

        public void UpdateBalance(string email,string password, double newBalance)
        {
            foreach (User user in _bankRepository.bank.Users)
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                {
                    user.Balance += newBalance;
                    _bankRepository.UpdateBalance(user);
                }
                else
                {
                    Console.WriteLine("--> Email veya parol sehvdir...");
                    Thread.Sleep(3000);
                }
            }
        }

        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Email == email && userList.Password == currentPassword)
                {

                    if ((MenuService.CheckPassword(newPassword)))
                    {
                        userList.Password = newPassword;
                        _bankRepository.ChangePassword(userList);
                    }

                    return true;
                }

                Console.WriteLine("Sehv sifre");
                Thread.Sleep(2000);
            }
            return false;
        }

        public bool BankUserList(string email)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {
                if (userList.Email == email)
                {
                    if (userList.IsAdmin == true)
                    {
                        _bankRepository.UserList(userList);
                        return true;
                    }
                }
            }
            return false;
        }

        public void BlockUser(string adminemail,string password)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {

                if (userList.Email.Equals(adminemail) && userList.Password.Equals(password))
                {
                    if (userList.IsAdmin == true)
                    {
                        foreach (User user in _bankRepository.bank.Users)
                        {
                            _bankRepository.UserList(user);
                            break;
                        }

                        Console.WriteLine("Bloklamaq istediyiniz user-in emaili daxil edin:");
                        string userEmail = Console.ReadLine();

                        foreach (User users in _bankRepository.bank.Users)
                        {

                            if (users.Email.Equals(userEmail))
                            {
                                users.IsBlocked = true;
                                _bankRepository.BlockUser(users);
                            }
                        }
                    }
                }
            }
       
        }
        public void UnBlockUser(string adminemail, string password)
        {
            foreach (User userList in _bankRepository.bank.Users)
            {

                if (userList.Email.Equals(adminemail) && userList.Password.Equals(password))
                {
                    if (userList.IsAdmin == true)
                    {
                        foreach (User user in _bankRepository.bank.Users)
                        {
                            _bankRepository.UserList(user);
                        }

                        Console.WriteLine("Blokdan cixarmaq istediyiniz user-in emaili daxil edin:");
                        string userEmail = Console.ReadLine();

                        foreach (User users in _bankRepository.bank.Users)
                        {

                            if (users.Email.Equals(userEmail))
                            {
                                users.IsBlocked = false;
                                _bankRepository.BlockUser(users);
                            }
                        }
                    }
                }
            }

        }

        public void Logout()
        {
        }
    }
}
