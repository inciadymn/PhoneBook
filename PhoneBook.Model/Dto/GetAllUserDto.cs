using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Dto
{
    public class GetAllUserDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "max 50 character", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "max 50 character", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 2)]
        public string Company { get; set; }
    }
}
