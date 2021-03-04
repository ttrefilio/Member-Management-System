using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;

namespace Project.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Status)
                .HasConversion<int>();

            builder.HasOne(a => a.Member)
                .WithMany(m => m.Accounts)
                .HasForeignKey(a => a.MemberId);

            builder.HasOne(a => a.Company)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CompanyId);
        }
    }
}
