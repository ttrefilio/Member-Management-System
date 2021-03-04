using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;

namespace Project.Data.Mappings
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Address)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
