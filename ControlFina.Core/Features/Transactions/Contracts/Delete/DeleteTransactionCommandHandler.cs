using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Mappings;
using ControlFina.Core.Features.Transactions.Repositories;

namespace ControlFina.Core.Features.Transactions.Contracts.Delete;

public sealed class DeleteTransactionCommandHandler : IDeleteTransactionCommandHandler
{
    private readonly ITransactionCommandRepository _commandRepository;
    private readonly ITransactionQueryRepository _queryRepository;

    public DeleteTransactionCommandHandler(ITransactionCommandRepository commandRepository, ITransactionQueryRepository queryRepository)
    {
        _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        _queryRepository = queryRepository ?? throw new ArgumentNullException(nameof(queryRepository));
    }

    public async Task<Result<TransactionResponse>> Handle(DeleteTransactionCommand command, CancellationToken cancellationToken)
    {
        var transaction = await _queryRepository.GetByIdAsync(command.Id, cancellationToken);

        if (transaction is null)
            return Result.Failure<TransactionResponse>(Error.NotFound($"Transaction with id [{command.Id}] not found"));

        _commandRepository.Delete(transaction);

        await _commandRepository.Commit();

        var response = TransactionMap.ToResponse(transaction);

        return Result.Success(response);
    }
}
