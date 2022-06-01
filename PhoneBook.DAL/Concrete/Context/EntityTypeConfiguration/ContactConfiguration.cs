using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Model.Entities;
using PhoneBook.Model.Enums;
using System.Collections.Generic;

namespace PhoneBook.DAL.Concrete.Context.EntityTypeConfiguration
{
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.InfoContent)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.InfoType)
               .HasMaxLength(150)
               .IsRequired();

            builder.HasData(new List<Contact>()
            {
                new Contact()
                {
                   ID=1,
                   InfoType=InfoType.Location.ToString(),
                   InfoContent="Istanbul",
                   UserID=1
                },

                new Contact()
                {
                   ID=2,
                   InfoType=InfoType.Location.ToString(),
                   InfoContent="Izmir",
                   UserID=1
                },

                new Contact()
                {
                   ID=3,
                   InfoType=InfoType.EmailAddress.ToString(),
                   InfoContent="test@test.com",
                   UserID=1
                },

                new Contact()
                {
                   ID=4,
                   InfoType=InfoType.PhoneNumber.ToString(),
                   InfoContent="11111111111",
                   UserID=1
                }
            }) ;
        }
    }
}
