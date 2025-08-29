using Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Features.Operations.Dtos;
public class TransactionLegRequest
{
    [Required]
    public string AssetTicker { get; set; } // Пользователь будет вводить тикер, а мы найдем AssetId

    public bool IsCustomAsset { get; set; } = false; // Флаг, указывающий, что это кастомный ассет пользователя

    [Required]
    public TransactionType Type { get; set; } = TransactionType.Trade; // Тип ноги (тело сделки, комиссия)

    [Required]
    [Range(0.00000001, (double)decimal.MaxValue)]
    public decimal Quantity { get; set; } // Количество всегда положительное

    [Required]
    [Range(-1, 1, ErrorMessage = "Direction must be 1 (in) or -1 (out).")]
    public int Direction { get; set; } // Направление: +1 (приход) или -1 (расход)

    public decimal? PricePerUnit { get; set; } // Цена за единицу

    public string? PriceCurrencyTicker { get; set; } // Тикер валюты, в которой указана цена
}

