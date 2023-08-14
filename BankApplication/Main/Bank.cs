using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Main
{
    internal class Bank
    {
        int Id;
        public User[] Users=new User[0];
        static int count = 0;


        static Bank()
        {
            count = 0;
        }
        public Bank()
        {
            Id = ++count;
        }
    }
}
