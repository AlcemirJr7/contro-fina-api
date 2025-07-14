using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Mappings;
using ControlFina.Core.Features.Transactions.Repositories;

namespace ControlFina.Core.Features.Transactions.Contracts.Update;

public sealed class UpdateTransactionCommandHandler : IUpdateTransactionCommandHandler
{
    private readonly ITransactionCommandRepository _commandRepository;
    private readonly ITransactionQueryRepository _queryRepository;

    public UpdateTransactionCommandHandler(ITransactionCommandRepository commandRepository, ITransactionQueryRepository queryRepository)
    {
        _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        _queryRepository = queryRepository ?? throw new ArgumentNullException(nameof(queryRepository));
    }

    public async Task<Result<TransactionResponse>> Handle(UpdateTransactionRequest command, CancellationToken cancellationToken)
    {
        var transaction = await _queryRepository.GetByIdAsync(command.Id, cancellationToken);

        if (transaction is null)
            return Result.Failure<TransactionResponse>(Error.NotFound($"Transaction with id [{command.Id}] not found."));

        transaction.Update(command.TransacationDate, command.CategoryId, command.Value, command.Observation, command.IsDebit);

        _commandRepository.Update(transaction);

        await _commandRepository.Commit();

        var response = TransactionMap.ToResponse(transaction);

        return Result.Success(response);
    }
}
