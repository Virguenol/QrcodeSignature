using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Grs.BioRestock.Domain.Contracts;
using Grs.BioRestock.Shared.Wrapper;

namespace Grs.BioRestock.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

 
    }
}