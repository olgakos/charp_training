using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class AccountData  //BN! АД публичный класс, чтобы видели другие 2_1

    {
        private string username;
        private string password;

        //КОНСТРУКТОР - блок ниже
    public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }


        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        //public string Home { get; set; }
    }
}