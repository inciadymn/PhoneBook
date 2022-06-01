using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
using System.Collections.Generic;

namespace PhoneBook.BLL.Abstract
{
    public interface IContactService : IBaseService<Contact>
    {
        ResultService<ContactCreateDto> Insert(ContactCreateDto contact, int id);

        ResultService<bool> Delete(int id);

        ResultService<List<ReportDto>> GetReport();
    }
}
