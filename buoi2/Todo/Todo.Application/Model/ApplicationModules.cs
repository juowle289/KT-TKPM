using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Service;
using Todo.Infrastructure;

namespace Todo.Application
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModels(this IServiceCollection services)
        {
            services.AddInfrastructureModels();

            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}