using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Testing.DataAccess;
using Testing.DataAccess.Repos;
using Testing.DataModels;

namespace Testing.Services.Helpers
{
    public static class DiModule
    {

        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {


            services.AddDbContext<SystemDbContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Subject>, SubjectRepository>();


            return services;

        }

    }
}
