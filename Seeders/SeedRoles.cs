using Microsoft.EntityFrameworkCore;

public class RoleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = Guid.NewGuid(), Name = "Admin", Description = "Full access to the system." },
            new Role { Id = Guid.NewGuid(), Name = "Editor", Description = "Can edit and manage content." },
            new Role { Id = Guid.NewGuid(), Name = "Viewer", Description = "Read-only access." }
        );
    }
}

