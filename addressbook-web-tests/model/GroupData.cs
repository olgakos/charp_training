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
        public GroupData(string name) //4_5
        { Name = name; }


        //л4_м1 начало
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }

            if (Object.ReferenceEquals(this, other))
            { return true;  }

            return Name == other.Name;
        }

        //l4_m3 
        public override int GetHashCode()
        { return Name.GetHashCode(); }

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


        /* убрано в 4-5
        //КОНСТРУКТОР name + Необязательынзх доп полей - блок ниже
        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }
        */

        public string Name { get; set; }
        public string Header { get; set; } 
        public string Footer { get; set; } 
        public string Id { get; set; }



    }

}

