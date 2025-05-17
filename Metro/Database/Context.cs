using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Metro.Database;

public class Context : IdentityDbContext<User>
{
    public Context(DbContextOptions<Context> options) : base(options) 
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().Property(r=>r.Initials).HasMaxLength(5);

        builder.HasDefaultSchema("Identity");
    }
}
