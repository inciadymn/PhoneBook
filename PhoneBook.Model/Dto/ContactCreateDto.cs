using PhoneBook.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Dto
{
    public class ContactCreateDto
    {
        public string InfoType { get; set; }

        public string InfoContent { get; set; }
    }
}
