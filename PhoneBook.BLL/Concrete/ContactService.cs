using PhoneBook.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concrete
{
    public class ContactService : IContactService
    {
        IContactDAL contactRepository;
        public ContactService(IContactDAL contactRepository)
        {
            this.contactRepository = contactRepository;
        }
    }
}
