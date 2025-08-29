using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Assets.Commands.CreateCustomAsset;

public class CreateCustomAssetRequest
{
    [Required, MaxLength(20)]
    public string Ticker { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public AssetClass AssetClass { get; set; }

    [MaxLength(100)]
    public string? Sector { get; set; }
    [MaxLength(100)]
    public string? Industry { get; set; }
    [MaxLength(2)] // Коды стран обычно состоят из 2 букв (ISO 3166-1 alpha-2)
    public string? CountryCode { get; set; }
}