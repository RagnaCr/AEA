using Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Assets.Commands.CreateCustomAsset;
public class CreateCustomAssetCommand : IRequest<Guid> // Возвращаем ID созданного ассета
{
    public Guid UserId { get; set; }
    public string Ticker { get; set; }
    public string Name { get; set; }
    public AssetClass AssetClass { get; set; }
    public string? Sector { get; set; }
    public string? Industry { get; set; }
    public string? CountryCode { get; set; }
}