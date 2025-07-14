using ControlFina.Core.Features.Categories.Contracts.Create;
using ControlFina.Core.Features.Categories.Contracts.Delete;
using ControlFina.Core.Features.Categories.Contracts.GetAll;
using ControlFina.Core.Features.Categories.Contracts.GetById;
using ControlFina.Core.Features.Categories.Contracts.Update;
using ControlFina.Core.Features.Transactions.Contracts.Create;
using ControlFina.Core.Features.Transactions.Contracts.Delete;
using ControlFina.Core.Features.Transactions.Contracts.GetAll;
using ControlFina.Core.Features.Transactions.Contracts.GetById;
using ControlFina.Core.Features.Transactions.Contracts.GetPaginated;
using ControlFina.Core.Features.Transactions.Contracts.Update;
using Microsoft.Extensions.DependencyInjection;

namespace ControlFina.Infrastructure.DependencyInjection;

public static class HandlerContainer
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddCategory()
                .AddTransaction();

        return services;
    }

    private static IServiceCollection AddCategory(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<ICreateCategoryCommandHandler, CreateCategoryCommandHandler>();
        services.AddScoped<IDeleteCategoryCommandHandler, DeleteCategoryCommandHandler>();
        services.AddScoped<IUpdateCategoryCommandHandler, UpdateCategoryCommandHandler>();

        // Queries
        services.AddScoped<IGetAllCategoryQueryHandler, GetAllCategoryQueryHandler>();
        services.AddScoped<IGetByIdCategoryQueryHandler, GetByIdCategoryQueryHandler>();

        return services;
    }

    private static IServiceCollection AddTransaction(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<ICreateTransactionCommandHandler, CreateTransactionCommandHandler>();
        services.AddScoped<IDeleteTransactionCommandHandler, DeleteTransactionCommandHandler>();
        services.AddScoped<IUpdateTransactionCommandHandler, UpdateTransactionCommandHandler>();

        // Queries
        services.AddScoped<IGetAllTransactionQueryHandler, GetAllTransactionQueryHandler>();
        services.AddScoped<IGetByIdTransactionQueryHandler, GetByIdTransactionQueryHandler>();
        services.AddScoped<IGetPaginatedTransactionQueryHandler, GetPaginatedTransactionQueryHandler>();

        return services;
    }
}
