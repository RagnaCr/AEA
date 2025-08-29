using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entity;
public class User : IdentityUser<Guid>
{
    public string? NickName { get; set; }

    // Связь с портфелями (EF Core найдет ее сам по UserId в Portfolio)
    public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
}

