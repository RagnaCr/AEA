using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Enums;
public enum AssetClass
{
    Stock,      // Акция
    Crypto,     // Криптовалюта
    Etf,        // Биржевой фонд
    Commodity,  // Товар (золото, нефть)
    Cash        // Денежные средства
}
