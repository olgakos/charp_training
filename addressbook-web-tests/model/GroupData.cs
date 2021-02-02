using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //неделя4
using LinqToDB.Mapping; //нед 7

namespace WebAddressbookTests


{
    [Table(Name = "group_list")]

    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {


        public GroupData() // 6_3
        {
        }

        public GroupData(string name) //4_5
        { Name = name; }


        //л4_м1 начало
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            { return false; }

            if (Object.ReferenceEquals(this, other))
            { return true; }

            return Name == other.Name;
        }

        //l4_m3 
        public override int GetHashCode()
        { return Name.GetHashCode(); }

        //l4_m3 
        public override string ToString()
        {
            //return "name=" + Name; //before HW13
            return "name=" + Name + "\nheader= " + Header + "\nfooter= " + Footer;

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


        [Column(Name = "group_name")]  //7_1
        public string Name { get; set; }
        [Column(Name = "group_header")] //7_1
        public string Header { get; set; }
        [Column(Name = "group_footer")] //7_1
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity] //7_1
        public string Id { get; set; }


        //7_1
        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }



        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id)
                        select c).Distinct().ToList();
            }
        }




    }

}

