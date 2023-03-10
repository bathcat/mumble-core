using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Acme.Hosting;

public static class ServiceProviderExtensions
{
    public static async Task PopulateDataAsync(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();

        await scope.PopulateBusinessData();
        await scope.PopulateIdentityData();
    }

    public static void PopulateData(this IServiceProvider provider) =>
        provider.PopulateDataAsync().Wait();
}
