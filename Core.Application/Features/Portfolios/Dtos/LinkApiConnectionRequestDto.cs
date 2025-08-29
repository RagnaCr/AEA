using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Portfolios.Dtos;
public class LinkApiConnectionRequestDto
{
    [Required]
    public Guid ConnectionId { get; set; }
}