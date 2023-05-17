using Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Reflection.Emit;

namespace Capstone.Data;

public class CapstoneContext : IdentityDbContext<CapstoneUser>
{
    public DbSet<Classroom> Classrooms { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Division> Divisions { get; set; } = null!;
    public DbSet<Incident> Incidents { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;

    public CapstoneContext(DbContextOptions<CapstoneContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<StudentClassrooms>()
       

        base.OnModelCreating(builder);
        builder.Entity<StudentClassrooms>()
            .HasOne(sc => sc.Classroom)
            .WithMany(c => c.Students)
            .HasForeignKey(sc => sc.ClassroomId)
            .OnDelete(DeleteBehavior.NoAction);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
