CREATE MATERIALIZED VIEW mv_avg_speed
    AS
        SELECT COUNT(trip_id) as no_of_trips,
        SUM(distance) as total_distance,
        SUM(duration) as total_duration,
        SUM(distance) / SUM(duration) as avg_speed
        FROM taxi_trips;