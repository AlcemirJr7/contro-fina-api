using ControlFina.Core.Features.Categories.Repositories;
using ControlFina.Core.Features.Transactions.Repositories;
using ControlFina.Infrastructure.Features.Categories.Repositories;
using ControlFina.Infrastructure.Features.Transactions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ControlFina.Infrastructure.DependencyInjection;

public static class RepositoryContainer
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddCategory()
                .AddTransaction();

        return services;
    }

    private static IServiceCollection AddCategory(this IServiceCollection services)
    {
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

        return services;
    }

    private static IServiceCollection AddTransaction(this IServiceCollection services)
    {
        services.AddScoped<ITransactionCommandRepository, TransactionCommandRepository>();
        services.AddScoped<ITransactionQueryRepository, TransactionQueryRepository>();

        return services;
    }
}
