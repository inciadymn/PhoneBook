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
        public InfoType InfoType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "max 50 character", MinimumLength = 2)]
        public string InfoContent { get; set; }

        public int UserID { get; set; }
    }
}
