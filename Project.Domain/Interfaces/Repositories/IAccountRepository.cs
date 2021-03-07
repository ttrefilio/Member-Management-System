using Project.Domain.Models;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        bool Exists(Account account);
    }
}
