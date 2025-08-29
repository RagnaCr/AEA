using Core.Application.Common.Interfaces.Exchanges;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Operations.Commands.ProcessExchangeTransactions;

public class ProcessExchangeTransactionsCommand : IRequest
{
    // нужно знать, к какому портфелю(-ям) привязано это подключение
    public Guid ApiConnectionId { get; }
    public IEnumerable<ExchangeTransaction> Transactions { get; }
    public Guid UserId { get; } // Для поиска кастомных ассетов

    public ProcessExchangeTransactionsCommand(Guid apiConnectionId, Guid userId, IEnumerable<ExchangeTransaction> transactions)
    {
        ApiConnectionId = apiConnectionId;
        UserId = userId;
        Transactions = transactions;
    }
}