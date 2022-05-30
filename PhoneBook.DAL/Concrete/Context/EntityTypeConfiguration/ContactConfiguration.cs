using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Model.Entities;
using PhoneBook.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasOne(a => a.User)
                   .WithMany(a => a.Contacts)
                   .HasForeignKey(a => a.UserID);

            builder.HasData(new Contact
            {
                ID = 1,
                InfoType = InfoType.Location,
                InfoContent = "Istanbul"
            });
        }
    }
}
