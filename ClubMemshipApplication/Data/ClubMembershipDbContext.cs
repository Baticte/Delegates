using ClubMemshipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMemshipApplication.Data;

public class ClubMembershipDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<User> Users { get; set; }
}