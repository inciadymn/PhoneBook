using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DAL.Abstract;
using PhoneBook.DAL.Concrete.Context;
using PhoneBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Concrete.Repository
{
    class ContactRepository : EFRepositoryBase<Contact, PhoneBookDbContext>, IContactRepository
    {
        public ContactRepository(PhoneBookDbContext context) : base(context)
        {
        }
    }
}
