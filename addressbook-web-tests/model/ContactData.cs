﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string middlename;

        //КОНСТРУКТОР обязательного поля name, НЕ НАДО ставить ";"
        public ContactData (string firstname)
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


        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }



    }
}
