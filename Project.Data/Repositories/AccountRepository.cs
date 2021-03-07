using Project.Data.Context;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models;
using System.Linq;

namespace Project.Data.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(SqlContext context) : base(context)
        {
                
        }

        public override IQueryable<Account> GetAll()
        {
            IQueryable<Account> accounts = dbSet;

            foreach(var account in accounts)
            {
                context.Entry(account).Reference(a => a.Company).Load();
            }

            return accounts;
        }

        public bool Exists(Account account)
        {
            return dbSet.Where(a => a.MemberId == account.MemberId && a.CompanyId == account.CompanyId).Any();
        }
    }
}
