using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ID=1,
                FirstName="Test1",
                LastName="Test2",
                Company="Rise Technology"
            });
        }
    }
}
