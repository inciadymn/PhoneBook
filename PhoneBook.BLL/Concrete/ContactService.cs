using PhoneBook.BLL.Abstract;
using PhoneBook.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concrete
{
    public class ContactService : IContactService
    {
        IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
    }
}
