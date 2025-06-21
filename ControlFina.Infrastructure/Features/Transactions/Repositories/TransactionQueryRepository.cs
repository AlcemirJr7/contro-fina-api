using ControlFina.Core.Features.Transactions.Entities;
using ControlFina.Core.Features.Transactions.Repositories;
using ControlFina.Infrastructure.Abstractions;
using ControlFina.Infrastructure.Database;

namespace ControlFina.Infrastructure.Features.Transactions.Repositories;

public class TransactionQueryRepository : QueryRepository<Transaction>, ITransactionQueryRepository
{
    public TransactionQueryRepository(AppDbContext dbContext) : base(dbContext) { }
}
