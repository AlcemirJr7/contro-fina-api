using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Entities;
using ControlFina.Core.Features.Transactions.Repositories;
using ControlFina.Core.Models;
using ControlFina.Infrastructure.Abstractions;
using ControlFina.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ControlFina.Infrastructure.Features.Transactions.Repositories;

public class TransactionQueryRepository : QueryRepository<Transaction>, ITransactionQueryRepository
{
    private readonly AppDbContext _dbContext;
    public TransactionQueryRepository(AppDbContext dbContext) : base(dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Transaction>> GetAllWithCategoryAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Transactions
                         .Include(t => t.Category)
                         .AsNoTracking()
                         .OrderByDescending(t => t.TransacationDate)
                         .Take(100)
                         .ToListAsync(cancellationToken);
    }

    public async Task<PaginationResult<Transaction>> GetAllWithCategoryPaginedAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        var totalTransactions = await _dbContext.Transactions
                                            .AsNoTracking()
                                            .CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling((double)totalTransactions/pagination.PageSize);

        var resultQuery = await _dbContext.Transactions
            .Include(t => t.Category)
            .AsNoTracking()
            .OrderByDescending(t => t.TransacationDate)
            .Skip((pagination.CurrentPage - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginationResult<Transaction>
        {
            Items = resultQuery,
            TotalItems = totalTransactions,
            TotalPages = totalPages,
            CurrentPage = pagination.CurrentPage,
            PageSize = pagination.PageSize
        };

    }
}
