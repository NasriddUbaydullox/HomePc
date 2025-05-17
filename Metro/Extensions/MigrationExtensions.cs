using Metro.Database;
using Microsoft.EntityFrameworkCore;

namespace Metro.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using Context context = scope.ServiceProvider.GetRequiredService<Context>();

        context.Database.Migrate();
    }
}
