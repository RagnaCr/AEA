using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.ApiConnections.Dtos;
public class UpdateApiConnectionRequest
{
    [Required, MaxLength(100)]
    public string ConnectionName { get; set; }

    [Required]
    public string ApiKey { get; set; }

    public string? ApiSecret { get; set; }
}