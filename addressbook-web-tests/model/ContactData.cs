﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData> //hw9
    
    {

        private string allPhones;
        private string allEmail;


        //private string firstname; //week5
        //private string lastname; //week5
        private string middlename = "";
        private string nickname = ""; 
        private string title = ""; 
        private string company = ""; 
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = ""; 
        private string email = ""; 
        private string email2 = ""; 
        private string email3 = ""; 
        private string homepage = ""; 
        private string address2 = "";
        private string home2 = "";
        private string notes = "";
        //private string AddressbookDate birthday = new AddressbookDate("", "", "");
        //private string AddressbookDate anniversary = new AddressbookDate("", "", "");

        //КОНСТРУКТОР обязательного поля name, НЕ НАДО ставить ";"
        public ContactData (string firstname, string lastname)
        {
            //this.firstname = firstname;
            //this.lastname = lastname;

            Firstname = firstname;
            Lastname = lastname;

        }


               
        




        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; } = "";

        public string Nickname { get; set; } = "";

        //public string Title { get; set; } = "";

        //public string Company { get; set; } = "";

        public string Address { get; set; } = "";

        public string HomePhone { get; set; } = "";

        public string MobilePhone { get; set; } = "";

        public string WorkPhone { get; set; } = "";

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set { allPhones = value; }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "") //!! стр 40 + дебаг стр 42
            {
                return "";
            }

            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        //public string Fax { get; set; } = "";

        public string Email { get; set; } = "";

        public string Email2 { get; set; } = "";

        public string Email3 { get; set; } = "";

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }

            set { allEmail = value; }

        }

        //public string Homepage { get; set; } = "";

        //public string Address2 { get; set; } = "";

        //public string Home2 { get; set; } = "";

        //public string Notes { get; set; } = "";







        //week5 было до 
        /*
            public string Firstname
            {
                get { return firstname;}
                set {firstname = value;}
            }

                
               public string Lastname
           {
               get { return lastname; }
               set {lastname = value; }
           }


            public string Middlename
            {
                get { return middlename; }
                set { middlename = value; }
            }


            public string Nickname
            {
                get { return nickname; }
                set { nickname = value; }
            }
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            public string Company
            {
                get { return company; }
                set { company = value; }
            }
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            public string Home
            {
                get { return home; }
                set { home = value; }
            }
            public string Mobile
            {
                get { return mobile; }
                set { mobile = value; }
            }
            public string Work
            {
                get { return work; }
                set { work = value; }
            }
            public string Fax
            {
                get { return fax; }
                set { fax = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Email2
            {
                get { return email2; }
                set { email2 = value; }
            }
            public string Email3
            {
                get { return email3; }
                set { email3 = value; }
            }
            public string Homepage
            {
                get { return homepage; }
                set { homepage = value; }
            }
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }
            public string Home2
            {
                get { return home2; }
                set { home2 = value; }
            }
            public string Notes
            {
                get { return notes; }
                set { notes = value; }
            }

        */


        /*
            public AddressbookDate Birthday
            {
                get { return birthday; }
                set { birthday = value; }
            }
            public AddressbookDate Anniversary
            {
                get { return anniversary; }
                set { anniversary = value; }
            }

        */






        //hw9 start

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }




        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + " " + "lastname=" + Lastname;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            //return (Firstname + Lastname).CompareTo(other.Firstname + other.Lastname); (до 4.5)

            if (Lastname.CompareTo(other.Lastname) != 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            return Firstname.CompareTo(other.Firstname);

        }

        //hw9 end



    }
}
