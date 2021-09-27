using Anvil.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Anvil.Database;
public class AnvilDatabaseContext : DbContext
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

    //public DbSet<ForgeVersions> ForgeVersions { get; set; }
    public DbSet<Packs> Packs { get; set; }
    public DbSet<PackVersions> PackVersions { get; set; }
    //public DbSet<PackDependencies> PackDependencies { get; set; }
}