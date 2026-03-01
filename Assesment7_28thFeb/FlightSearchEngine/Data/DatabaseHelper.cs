using System.Data;
using System.Data.SqlClient;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<string>> GetSourcesAsync()
        {
            var sources = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetSources", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            sources.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return sources;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            var destinations = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetDestinations", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            destinations.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return destinations;
        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            var flights = new List<FlightResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_SearchFlights", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Persons", persons);

                    await connection.OpenAsync();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            flights.Add(new FlightResult
                            {
                                FlightId = reader.GetInt32(0),
                                FlightName = reader.GetString(1),
                                FlightType = reader.GetString(2),
                                Source = reader.GetString(3),
                                Destination = reader.GetString(4),
                                TotalCost = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }

            return flights;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            var packages = new List<FlightHotelResult>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_SearchFlightsWithHotels", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@Persons", persons);

                    await connection.OpenAsync();
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            packages.Add(new FlightHotelResult
                            {
                                FlightId = reader.GetInt32(0),
                                FlightName = reader.GetString(1),
                                Source = reader.GetString(2),
                                Destination = reader.GetString(3),
                                HotelName = reader.GetString(4),
                                TotalCost = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }

            return packages;
        }
    }
}
