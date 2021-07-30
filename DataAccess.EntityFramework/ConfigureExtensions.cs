using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public static class ConfigureExtensions
    {
        public static void AddTestCoreTaskDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestCoreTaskContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDbContext>(sp => sp.GetRequiredService<TestCoreTaskContext>());
        }
    }
}
