using Project.Data.Context;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models;
using System.Linq;

namespace Project.Data.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(SqlContext context) : base(context)
        {

        }       

        public override IQueryable<Member> GetAll()
        {
            IQueryable<Member> members = dbSet;

            foreach (var member in members)
            {
                context.Entry(member).Collection(m => m.Accounts).Load();

                foreach (var account in member.Accounts)
                {
                    context.Entry(account).Reference(a => a.Company).Load();
                }
            }           

            return members;
        }    
       
    }
}
