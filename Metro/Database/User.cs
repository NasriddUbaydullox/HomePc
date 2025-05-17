using Microsoft.AspNetCore.Identity;

namespace Metro.Database;

public class User : IdentityUser
{
    public string? Initials { get; set; }
}
