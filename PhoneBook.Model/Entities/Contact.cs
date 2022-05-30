using PhoneBook.Core.Entity;
using PhoneBook.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Entities
{
    public class Contact : BaseEntity
    {
        public InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
