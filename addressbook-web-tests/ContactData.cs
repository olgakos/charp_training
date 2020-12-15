using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        //добавляем не обязательное поле с дефолтным занчением "пустое"
        //private string lastname = "";

        //КОНСТРУКТОР обязательного поля name - блок ниже, НЕ НАДО ;
        public ContactData(string firstname)
        {
            this.firstname = firstname;
            //this.lastname = lastname;
        }


            public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        /* public string Lastname { get; internal set; }


               public string Lastname
           {
               get
               {
                   return lastname;
               }
               set
               {
                   lastname = value;
               }
           }

       */

    }
}
