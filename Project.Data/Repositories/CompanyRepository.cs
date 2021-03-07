using Microsoft.EntityFrameworkCore;
using Project.Data.Context;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SqlContext context) : base(context)
        {            
        }

        public bool Exists(string companyName)
        {
            return dbSet.AsNoTracking().Any(c => c.Name.ToLower().Equals(companyName.ToLower()));
        }

        public Company GetByName(string name)
        {           
            return dbSet.FirstOrDefault(c => c.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
