using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Simple.Mediatr.Model.People.Handlers;

namespace Simple.Mediatr.Service.MediatorInjection
{
    public class ConfigurationBindMediatorInjector
    {
        public static void RegisterBindMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePeopleHandler));            
        }
    }
}
