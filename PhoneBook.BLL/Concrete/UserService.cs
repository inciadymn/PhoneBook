using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ResultService<UserDto> Insert(UserDto user)
        {
            ResultService<UserDto> userResult = new ResultService<UserDto>();

            try
            {
                User addedUser = userRepository.Add(
                    new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Company = user.Company
                    });

                if (addedUser == null)
                {
                    userResult.AddError("Insert Error", "Add not successful");
                    return userResult;
                }

                userResult.Data = user;
            }
            catch (Exception ex)
            {
                userResult.AddError("Exception", ex.Message);
            }

            return userResult;
        }

        public ResultService<bool> Update(UserDto user, int id)
        {
            ResultService<bool> result = new ResultService<bool>();

            try
            {
                User userResult = userRepository.Get(a => a.ID == id);
                if (userResult == null)
                {
                    result.AddError("Null Error", "No such user found");
                    return result;
                }

                User updateUser = userRepository.Update(
                    new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Company = user.Company
                    });

                if (updateUser == null)
                {
                    result.AddError("Update Error", "Update not successful");
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

        public ResultService<bool> Delete(int id)
        {
            ResultService<bool> result = new ResultService<bool>();

            try
            {
                User user = userRepository.Get(a => a.ID == id);
                if (user == null)
                {
                    result.AddError("Null Error", "No such user found");
                    return result;
                }

                int deleteUserResult = userRepository.Remove(user);

                if (deleteUserResult == 0)
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

        public ResultService<List<GetAllUserDto>> GetAllUsers()
        {
            ResultService<List<GetAllUserDto>> result = new ResultService<List<GetAllUserDto>>();

            try
            {
                List<GetAllUserDto> users = userRepository.GetAll().Select(user => new GetAllUserDto
                {
                    ID = user.ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Company = user.Company
                }).ToList();

                if (users == null)
                {
                    result.AddError("Null Error", "Operation failed");
                    return result;
                }

                result.Data = users;
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("Exception", ex.Message);
                return result;
            }
        }

        public ResultService<GetUserContactsDto> GetUserContacts(int id)
        {
            ResultService<GetUserContactsDto> result = new ResultService<GetUserContactsDto>();

            try
            {
                User user = userRepository.GetAll(a => a.ID == id, a => a.Contacts).SingleOrDefault();

                if (user == null)
                {
                    result.AddError("Null Error", "No such user found");
                    return result;
                }

                GetUserContactsDto userContact = new GetUserContactsDto()
                {
                    ID = user.ID,
                    Company = user.Company,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                if (user.Contacts.Count > 0)
                {
                    userContact.Contacts = new List<ContactDto>();

                    userContact.Contacts.AddRange(user.Contacts.Select(a => new ContactDto()
                    {
                        InfoContent = a.InfoContent,
                        InfoType = a.InfoType.ToString(),
                        UserID = a.UserID
                    }).ToList()); 
                }

                result.Data = userContact;
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
