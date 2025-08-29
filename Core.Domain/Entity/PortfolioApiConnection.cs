using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entity;
/// <summary>
/// Связующая таблица между Portfolio и ApiConnection, для более удобного доступа к ним.
/// </summary>
public class PortfolioApiConnection
{
    // Составной первичный ключ
    public Guid PortfolioId { get; private set; }
    public Guid ApiConnectionId { get; private set; }

    // Навигационные свойства для EF Core
    public Portfolio Portfolio { get; private set; }
    public ApiConnection ApiConnection { get; private set; }

    private PortfolioApiConnection() { }

    public PortfolioApiConnection(Guid portfolioId, Guid apiConnectionId)
    {
        PortfolioId = portfolioId;
        ApiConnectionId = apiConnectionId;
    }
}
