using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;

namespace PhoneBook.BLL.Abstract
{
    public interface IContactService : IBaseService<Contact>
    {
        ResultService<ContactDto> Insert(ContactDto contact, int id);
    }
}
