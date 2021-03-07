using Microsoft.Extensions.DependencyInjection;
using Project.Data.Repositories;
using Project.Domain.Interfaces.Repositories;

namespace Project.API.Configurations
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Infrastructure
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            #endregion
        }
    }
}
