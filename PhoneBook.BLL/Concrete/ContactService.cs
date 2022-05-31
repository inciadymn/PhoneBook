using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
using System;

namespace PhoneBook.BLL.Concrete
{
    public class ContactService : IContactService
    {
        IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public ResultService<ContactCreateDto> Insert(ContactCreateDto contact, int id)
        {
            ResultService<ContactCreateDto> contactResult = new ResultService<ContactCreateDto>();

            try
            {
                Contact addedContact = contactRepository.Add(
                    new Contact
                    {
                        InfoContent = contact.InfoContent,
                        InfoType = contact.InfoType,
                        UserID = id
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
