using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Model.Entities;
using PhoneBook.Model.Enums;
using System.Collections.Generic;

namespace PhoneBook.DAL.Concrete.Context.EntityTypeConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Company)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Company = "Test1",
                Contacts = new List<Contact>()
                {
                    new Contact()
                    {
                       ID=1,
                       InfoType=InfoType.Location,
                       InfoContent="Istanbul"
                    },

                    new Contact()
                    {
                       ID=2,
                       InfoType=InfoType.Location,
                       InfoContent="Izmir"
                    },

                    new Contact()
                    {
                       ID=3,
                       InfoType=InfoType.EmailAddress,
                       InfoContent="test@test.com"
                    },

                    new Contact()
                    {
                       ID=1,
                       InfoType=InfoType.PhoneNumber,
                       InfoContent="11111111111"
                    }
                }
            });
        }
    }
}
