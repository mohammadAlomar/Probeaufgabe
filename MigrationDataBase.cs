using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe
{
    public static class MigrationDataBase
    {
        public static IHost Migrate<T>(this IHost webHost) where T : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetService<T>();
                    db.Database.Migrate();
                }
                catch (Exception es)
                {
                    Console.WriteLine(es);
                }
            }
            return webHost;
        }
    }
}
