using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //неделя4

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";


        //КОНСТРУКТОР обязательного поля name - блок ниже
        public GroupData(string name)
        {
            this.name = name;
        }





        //л4_м1 начало
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        //l4_m3 
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        //l4_m3 
        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        //л4_м1 конец



        //КОНСТРУКТОР name + Необязательынзх доп полей - блок ниже
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }



        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }


        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
        

    }

}

