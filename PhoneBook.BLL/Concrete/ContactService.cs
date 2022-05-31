using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
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

        public ResultService<ContactDto> Insert(ContactDto contact, int id)
        {
            ResultService<ContactDto> contactResult = new ResultService<ContactDto>();

            try
            {
                Contact addedContact = contactRepository.Add(
                    new Contact
                    {
                        InfoContent=contact.InfoContent,
                        InfoType=contact.InfoType,
                        UserID=id
                    });

                if (addedContact == null)
                {
                    contactResult.AddError("Insert Error", "Add not successful");
                    return contactResult;
                }

                contactResult.Data = contact;
            }
            catch (Exception ex)
            {
                contactResult.AddError("Exception", ex.Message);
            }

            return contactResult;
        }
    }
}
