using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Acme.Hosting;

public static class DbContextExtensions
{
    public static async Task EnsureSchema(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        var databaseCreator = context.GetService<IRelationalDatabaseCreator>();
        if (await databaseCreator.ExistsAsync())
        {
            try
            {
                await databaseCreator.CreateTablesAsync();
            }
            catch (System.Data.Common.DbException)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Swallowing exception. This probably means the tables are already there."
                );
            }

            return;
        }

        var success = await context.Database.EnsureCreatedAsync();

        if (!success)
        {
            throw new Exception("Unable to make tables");
        }
    }
}
