using EHospital.Application.Abstraction;
using EHospital.Application.Services;
using EHospital.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EHospital.Infrastructure;

public static  class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IMailService, MailService>();        
    }   
}
