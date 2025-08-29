using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Interfaces.Exchanges;
public interface IExchangeApiClientFactory
{
    IExchangeApiClient GetClient(string exchangeName);
}