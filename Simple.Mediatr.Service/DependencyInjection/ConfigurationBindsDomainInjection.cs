using Microsoft.Extensions.DependencyInjection;
using Simple.Mediatr.Model.People;
using Simple.Mediatr.Repository.Interface.People;
using Simple.Mediatr.Repository.Repository.People;

namespace Simple.Mediatr.Service.DependencyInjection
{
    public class ConfigurationBindsDomainInjection
    {
        public static void RegisterBind(IServiceCollection services)
        {
            services.AddSingleton<IPeopleRepository<PeopleModel>, PeopleRepository>();            
        }
    }
}
