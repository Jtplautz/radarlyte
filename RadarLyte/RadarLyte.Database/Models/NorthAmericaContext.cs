using Microsoft.EntityFrameworkCore;
using RadarLyte.Database.Models.ComponentRegistration;
using RadarLyte.Database.Models.Entities;

namespace RadarLyte.Database.Models;
public sealed class NorthAmericaContext : DbContext {
    public NorthAmericaContext(DbContextOptions<NorthAmericaContext> options)
        : base(options)
    {
    }

    #region DBSets
    public DbSet<Location>? Locations { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddLocationComponent();
        base.OnModelCreating(modelBuilder);
    }
}

