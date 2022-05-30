using Microsoft.Extensions.DependencyInjection;
using PhoneBook.BLL.Abstract;
using PhoneBook.DAL.Concrete.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BLL.Concrete.Extensions
{
    public static class RegisterService
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
