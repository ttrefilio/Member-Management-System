using Microsoft.EntityFrameworkCore;
using Project.Data.Mappings;
using Project.Domain.Models;

namespace Project.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        
        public DbSet<Member> Members { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberMap());

            modelBuilder.ApplyConfiguration(new AccountMap());

            modelBuilder.ApplyConfiguration(new CompanyMap());

            modelBuilder.Entity<Company>(entity => entity.HasIndex(c => c.Name).IsUnique());

            base.OnModelCreating(modelBuilder);
        }

    }
}