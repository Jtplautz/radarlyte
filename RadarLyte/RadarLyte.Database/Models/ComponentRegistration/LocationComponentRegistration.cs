using Microsoft.EntityFrameworkCore;
using RadarLyte.Database.Models.Entities;

namespace RadarLyte.Database.Models.ComponentRegistration;
public static partial class ComponentRegistration {
    public static void AddLocationComponent(this ModelBuilder builder)
    {
        builder.Entity<Location>().Map();
    }
}
