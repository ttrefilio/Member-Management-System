using Project.Domain.Models;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        bool Exists(string companyName);
        Company GetByName(string Name);
    }
}
