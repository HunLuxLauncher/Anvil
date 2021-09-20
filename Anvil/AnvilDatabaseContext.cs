using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

internal class AnvilDatabaseContext : DbContext
{
    public AnvilDatabaseContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //use this to configure the contex
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //use this to configure the model
    }

    public DbSet<ForgeVersions> ForgeVersions { get; set; }
    public DbSet<Mods> Mods { get; set; }
    public DbSet<ModVersions> ModVersions { get; set; }
    public DbSet<ModDependencies> ModDependencies { get; set; }
}