using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "Please enter a minimum of 2 characters and a maximum of 50 characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "Please enter a minimum of 2 characters and a maximum of 50 characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "Please enter a minimum of 2 characters and a maximum of 50 characters", MinimumLength = 2)]
        public string Company { get; set; }
    }
}
