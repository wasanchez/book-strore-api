using System.Reflection;
using BookStore.Api.Models;
using BookStore.Api.Services;

namespace BookStore.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) 
    {
        return services
                .AddMappers()
                .AddServices(configuration);
    }

    private static IServiceCollection AddMappers(this IServiceCollection services) {
        return services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {

        return services
                .Configure<BookStoreDatabaseSettings>(configuration.GetSection("BookStoreDatabase"))
                .AddSingleton<BooksService>();
    }

}
