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

            builder.HasMany(a => a.Contacts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserID);

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Company = "Test1",
            }); 
        }
    }
}
