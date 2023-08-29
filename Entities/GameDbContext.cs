using Microsoft.EntityFrameworkCore;
using servartur.Models;

namespace servartur.Entities;

public class GameDbContext : DbContext
{
    private string _connectionString =
        "Server=(localdb)";

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Squad> Squads { get; set; }
    public DbSet<Member> Members { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .Property(r => r.HostUserId)
            .IsRequired();

        modelBuilder.Entity<Player>()
            .Property(p => p.Nick)
            .IsRequired()
            .HasMaxLength(20);

        //TODO dodac wiecej ogrniczen
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}

