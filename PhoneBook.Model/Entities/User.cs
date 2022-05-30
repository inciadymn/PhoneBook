using PhoneBook.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
