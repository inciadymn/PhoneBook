using PhoneBook.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Dto
{
    public class ContactDto
    {
        public int ID { get; set; }

        public string InfoType { get; set; }

        public string InfoContent { get; set; }
    }
}
