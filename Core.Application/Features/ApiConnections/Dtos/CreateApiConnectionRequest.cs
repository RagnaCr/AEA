using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Dtos;
public class CreateApiConnectionRequest
{
    [Required, MaxLength(100)]
    public string ConnectionName { get; set; }

    [Required, MaxLength(50)]
    public string ExchangeName { get; set; } // e.g., "Bybit", "Questrade"

    [Required]
    public string ApiKey { get; set; } // Открытый ключ

    public string? ApiSecret { get; set; } // Секретный ключ (может быть необязательным)
}