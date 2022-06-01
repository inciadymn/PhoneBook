using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Model.Dto
{
    public class ReportDto
    {
        public string Location { get; set; }
        public int LocationCount { get; set; }
        public int UserCount { get; set; }
        public int NumberCount { get; set; }
    }
}
