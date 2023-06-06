using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RisingWaveDotnetMaterializedView.Migrations
{
    /// <inheritdoc />
    public partial class CreateAverageSpeedMaterializedView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE MATERIALIZED VIEW mv_avg_speed
                    AS
                        SELECT COUNT(trip_id) as no_of_trips,
                        SUM(distance) as total_distance,
                        SUM(duration) as total_duration,
                        SUM(distance) / SUM(duration) as avg_speed
                        FROM taxi_trips;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP MATERIALIZED VIEW IF EXISTS mv_avg_speed;");
        }
    }
}
