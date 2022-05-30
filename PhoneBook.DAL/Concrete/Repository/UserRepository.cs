using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DAL.Abstract;
using PhoneBook.DAL.Concrete.Context;
using PhoneBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Concrete.Repository
{
    class UserRepository : EFRepositoryBase<User,PhoneBookDbContext>, IUserRepository
    {
        public UserRepository(PhoneBookDbContext context) : base(context)
        {
        }
    }
}
