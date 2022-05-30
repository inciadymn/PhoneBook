using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DAL.Abstract;
using PhoneBook.DAL.Concrete.Context;
using PhoneBook.DAL.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Concrete.Extensions
{
    public static class RegisterRepository
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddDbContext<PhoneBookDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>(); 
        }
    }
}
