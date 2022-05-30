using PhoneBook.Core.DataAccess;
using PhoneBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Abstract
{
    public interface IContactRepository : IRepository<Contact>
    {
    }
}
