using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
using PhoneBook.Model.Enums;
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
                if (!Enum.IsDefined(typeof(InfoType),contact.InfoType))
                {
                    contactResult.AddError("Insert Error", "InfoType is not valid");
                    return contactResult;
                }

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

        public ResultService<bool> Delete(int id)
        {
            ResultService<bool> result = new ResultService<bool>();

            try
            {
                Contact contact = contactRepository.Get(a => a.ID == id);
                if (contact == null)
                {
                    result.AddError("Null Error", "Contact information not found");
                    return result;
                }

                int deleteContact = contactRepository.Remove(contact);

                if (deleteContact == 0)
                {
                    result.AddError("Deletion Error", "Deletion failed");
                    return result;
                }

                result.Data = true;
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("Exception", ex.Message);
                return result;
            }
        }
    }
}
