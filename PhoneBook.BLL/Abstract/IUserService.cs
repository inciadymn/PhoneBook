using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Entities;
using System.Collections.Generic;

namespace PhoneBook.BLL.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        ResultService<UserDto> Insert(UserDto user);
        ResultService<bool> Update(UserDto user, int id);
        public ResultService<bool> Delete(int id);
        ResultService<List<GetAllUserDto>> GetAllUsers();
    }
}
