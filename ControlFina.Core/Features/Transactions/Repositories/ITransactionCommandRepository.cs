using ControlFina.Core.Abstractions.Repositories;
using ControlFina.Core.Features.Transactions.Entities;

namespace ControlFina.Core.Features.Transactions.Repositories;

public interface ITransactionCommandRepository : ICommandRepository<Transaction>;
