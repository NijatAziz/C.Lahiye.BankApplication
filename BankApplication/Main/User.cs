using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Main
{
    internal class User
    {
        string _name;
        public string Name
        { get { return _name; } set { _name = value; } }

        string _surname;
        public string Surname
        { get { return _surname; } set { _surname = value; } }

        string _email;
        public string Email
        { get { return _email; } set { _email = value; } }

        string _password;
        public string Password { get { return _password; } set { _password = value; } }
        static int count;
        int _id;
        public int Id { get { return _id; } set { _id = value; } }
        public double Balance;
        public bool IsAdmin, IsBlocked, IsLogged;

        public User(string name, string surname, string email, string password, bool isAdmin)
        {
            Name = name;
            Surname = surname;
            IsAdmin = isAdmin;
            Email = email;
            Password = password;
            Balance = default;
            count = 10;
            Id = ++count;
            IsBlocked = false;
            IsLogged = false;
        }
        static User()
        {
            count = 0;  
        }
    }
}
