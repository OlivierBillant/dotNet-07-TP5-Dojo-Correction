namespace TpDojo.Dal;

using Microsoft.EntityFrameworkCore;
using TpDojo.Dal.Entities;

internal class TpDojoContext : DbContext
{
    public TpDojoContext(DbContextOptions<TpDojoContext> options)
        : base(options)
    {
    }

    public DbSet<Arme> Arme => this.Set<Arme>();

    public DbSet<Samourai> Samourai => this.Set<Samourai>();
}
