using PhoneBook.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserDAL userRepository;
        public UserService(IUserDAL userRepository)
        {
            this.userRepository = userRepository;
        }
    }
}
