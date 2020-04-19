using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUN4API
{
    public class Contact
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string phonenumber { get; set; }
        public Contact(int id, string name, string phonenumber)
        {
            this.id = id;
            Name = name;
            this.phonenumber = phonenumber;
        }
    }
}
