using BankApplication.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Service
{
    internal static class MenuService
    {
        readonly static BankService bankService;
        readonly static UserService userService;
        static Bank bank;

        static MenuService()
        {
            bank = new Bank();
            bankService = new BankService(bank);
            userService = new UserService(bank);
        }

        public static void Registration()
        {
            string name;
            string surname;
            string email;
            string password;
            bool isAdmin;

            do
            {
                Console.WriteLine("Adinizi daxil edin:");
                name = Console.ReadLine();
            } while (!CheckNameSurname(name));

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Soyadinizi daxil edin:");
                surname = Console.ReadLine();
            } while (!CheckNameSurname(surname));
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Emailinizi daxil edin:");
                email = Console.ReadLine();
            } while (!CheckEmail(email));

            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Sifre daxil edin:");
                password = Console.ReadLine();
            } while (!CheckPassword(password));

            string Admin = null;
            char yesNo;
        start:
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine(" Siz adminsiniz?: y(Beli) veya n(Xeyr)");
                isAdmin = char.TryParse(Console.ReadLine(), out yesNo);
            } while (!isAdmin);

            if (yesNo.ToString().ToLower() == 'y'.ToString())
            {
                userService.Registration(name, surname, email, password, true);
            }
            else if (yesNo.ToString().ToLower().Equals('n'.ToString()))
            {
                userService.Registration(name, surname, email, password, false);
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("--> Iki secimden birini edin'y' veya 'n'...");
                goto start;
            }

        }
       
        public static void Logged()
        {
            string email;
            string password;
            Console.WriteLine("Giris edin: \n");
            Console.WriteLine("Emaili daxil edin:");
            email = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Sifre daxil edin:");
            password = Console.ReadLine();

            if (IsBlockedOrNo(email).Equals(false))
            {
                userService.Logged(email, password);
            }
            Console.WriteLine("Siz bloklanmisiniz!");
            Thread.Sleep(1000);
        }

        public static void FindUser()
        {
            string email;
            Console.WriteLine("Qeyd etdiyiniz emaile uygun user:");
            email = Console.ReadLine();
            userService.FindUser(email);
        }
      
        public static void CheckBalance()
        {
            string email;
            Console.WriteLine("Email daxil edin: ");
            email = Console.ReadLine();
            string password;
            Console.WriteLine("Sifre daxil edin: ");
            password = Console.ReadLine();
            bankService.CheckBalance(password,email);
        }
      
        public static void UpdateBalance()
        {
            string email;
            string password;
            double newBalance;

            Console.WriteLine("Email daxil edin:");
            email = Console.ReadLine();
            Console.WriteLine("Sifre daxil edin:");
            password = Console.ReadLine();
            Console.WriteLine("Yeni balans daxil edin:");
            bool result = double.TryParse(Console.ReadLine(), out newBalance);

            if (result)
            {
                bankService.UpdateBalance(email,password, newBalance);
                Console.WriteLine("Yuklenme...");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("--> Reqem daxil edin!...");
                Thread.Sleep(1500);
            }
        }

        public static void ChangePassword()
        {
            string email;
            string currentPassword;
            string newPassword;
            do
            {
                Console.WriteLine("Email daxil edin:");
                email = Console.ReadLine();
                Console.WriteLine("Sifre daxil edin:");
                currentPassword = Console.ReadLine();
                Console.WriteLine("Yeni sifre daxil edin");
                newPassword = Console.ReadLine();
            } while (!bankService.ChangePassword(email, currentPassword, newPassword));
        }
        public static void UserList()
        {
            string email;

            Console.WriteLine("Userin emailini secin");
            email = Console.ReadLine();

            bankService.BankUserList(email);
        }

      
        public static void BlockUser()
        {
            string adminEmail;
            string password;
            Console.WriteLine("Admin emailini ve sifresini daxil edin:\n");
            Console.Write("Email: ");
            adminEmail = Console.ReadLine();
            Console.Write("Sifre: ");
            password = Console.ReadLine();
        
                bankService.BlockUser(adminEmail,password);
            
        }
        public static void UnBlockUser()
        {

            string adminEmail;
            string userEmail = string.Empty;
            string password;
            Console.WriteLine("Admin emailini ve sifresini daxil edin:\n");
            Console.Write("Email: ");
            adminEmail = Console.ReadLine();
            Console.Write("Sifre: ");
            password = Console.ReadLine();
            bankService.UnBlockUser(adminEmail,password);
        }

        public static void Logout()
        {
            MenuService.ProgramService();
        }

  
        public static bool CheckNameSurname(string nameOrSurname)
        {
            if (nameOrSurname.Length > 3)
            {
                return true;
            }
            Console.WriteLine("--> Ad veya Soyad uzunlugu minumum uc olmalidir.\n");
            return false;
        }
   
        public static bool CheckPassword(string password)
        {
            bool hasLower = false;
            bool hasUpper = false;
            bool result = false;

            if (password.Length < 8)
            {
                Console.WriteLine("->Sifre uzunlugu minumum sekkiz olmalidir.\n");
                Thread.Sleep(1500);
                return false;
            }

            foreach (char characters in password)
            {
           
                if (char.IsLower(characters))
                {
                    hasLower = true;
                }
                else if (char.IsUpper(characters))
                {
                    hasUpper = true;
                }

                result =  hasLower && hasUpper;
                if (result)
                {
                    return true;
                }
            }

            Console.WriteLine("->Sifrede minumum bir boyuk herf ve bir kicik herf olmalidir.\n");
            return false;
        }

        public static bool CheckEmail(string email)
        {
            if (email.Contains('@'))
            {
                return true;
            }
            Console.WriteLine("-> Emailde '@' isaresi olmalidir.\n");
            return false;
        }
        

        public static void BankService()
        {
            char BankServiceSelection;
            Console.WriteLine("Sizin Bank servisiniz\n");
            do
            {
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Update balance");
                Console.WriteLine("3. Change password");
                Console.WriteLine("4. Bank user list");
                Console.WriteLine("5. Block user");
                Console.WriteLine("6. UnBlock user");
                Console.WriteLine("7. Logout");
            selection1:
                BankServiceSelection = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (BankServiceSelection)
                {
                    case '1':
                        MenuService.CheckBalance();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.UpdateBalance();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.ChangePassword();
                        Console.Clear();
                        break;
                    case '4':
                        MenuService.UserList();
                        Console.Clear();
                        break;
                    case '5':
                        MenuService.BlockUser();
                        Console.Clear();
                        break;
                    case '6':
                        MenuService.UnBlockUser();
                        Console.Clear();
                        break;
                    case '7':
                        MenuService.Logout();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Zehmet olmasa duzgun reqem secin");
                        Console.Clear();
                        goto selection1;
                }
            } while (BankServiceSelection != '0');
        }
       
        public static void ProgramService()
        {

            char UserServiceSelection;
            Console.WriteLine("Bankimizda xos gelmisiniz\n");
            do
            {
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Find User");
                Console.WriteLine("0. Exit");
            selection:
                UserServiceSelection = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (UserServiceSelection)
                {
                    case '1':
                        MenuService.Registration();
                        Console.Clear();
                        break;
                    case '2':
                        MenuService.Logged();
                        Console.Clear();
                        break;
                    case '3':
                        MenuService.FindUser();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Zehmet olmasa duzgun reqem secin");
                        Console.Clear();
                        goto selection;
                }
            } while (UserServiceSelection != '0');
        }


        public static bool IsBlockedOrNo(string email)
        {
            foreach (User userList in bankService._bankRepository.bank.Users)
            {
                if (userList.Email.Equals(email))
                {
                    if (userList.IsBlocked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}


