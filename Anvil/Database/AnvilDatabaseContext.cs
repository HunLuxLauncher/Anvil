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
    public DbSet<Pack> Packs { get; set; }
    public DbSet<Mod> Mods { get; set; }
    public DbSet<ModVersion> ModVersions { get; set; }
    public DbSet<PackNewsItem> PackNews { get; set; }
    public DbSet<PackVersion> PackVersions { get; set; }
    public DbSet<PackDependency> PackDependencies { get; set; }
}