using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class ContactsEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<ContactsEntity> entity)
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("CONTACTS");

            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.Phone).HasMaxLength(50);
        }
    }
}
