namespace RisingWaveDotnetMaterializedView.DbHelpers;

using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to RisingWave with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("RisingWaveStreamingDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AverageSpeedView>().HasNoKey().ToView("mv_avg_speed");
    }

    public DbSet<AverageSpeedView> AverageSpeedViews { get; set; }
}