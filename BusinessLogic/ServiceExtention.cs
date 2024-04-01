using Core.Interfaces;
using Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieService, MoviesService>();
            serviceCollection.AddScoped<IAccountService, AccountService>();

        }
        public static void AddValidators(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddFluentValidationAutoValidation();
            serviceCollection.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
