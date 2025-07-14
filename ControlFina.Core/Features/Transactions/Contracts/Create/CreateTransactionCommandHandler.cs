using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Repositories;
using ControlFina.Core.Features.Transactions.Entities;
using ControlFina.Core.Features.Transactions.Mappings;
using ControlFina.Core.Features.Transactions.Repositories;

namespace ControlFina.Core.Features.Transactions.Contracts.Create;

public sealed class CreateTransactionCommandHandler : ICreateTransactionCommandHandler
{
    private readonly ITransactionCommandRepository _command;
    private readonly ICategoryQueryRepository _categoryQuery;

    public CreateTransactionCommandHandler(ITransactionCommandRepository command, ICategoryQueryRepository categoryQuery)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _categoryQuery = categoryQuery ?? throw new ArgumentNullException(nameof(categoryQuery));
    }

    public async Task<Result<TransactionResponse>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        var category = await _categoryQuery.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category is null)
            return Result.Failure<TransactionResponse>(Error.NotFound($"Category with id [{command.CategoryId}] not found"));
        
        Transaction transaction = new(command.TransacationDate, command.CategoryId, command.Value, command.Observation, command.IsDebit);

        _command.Create(transaction);

        await _command.Commit();

        var response = TransactionMap.ToResponse(transaction);

        return Result.SuccessCreated(response);
    }
}
