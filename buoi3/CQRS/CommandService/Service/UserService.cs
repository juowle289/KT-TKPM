using CommandService.Models;
using Confluent.Kafka;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Internal;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommandService.Service
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly IProducer<Null, string> _producer;
        public UserService(IConfiguration cfg)
        {
            _connectionString = cfg.GetConnectionString("cnnStr")!;
            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = cfg["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }
        public async Task CreateUserAsync(User user)
        {
            var @event = new
            {
                EventId = Guid.NewGuid(),
                EventType = "UserCreated",
                AggregateId = user.Id,
                Data = user,
                CreatedAt = DateTime.UtcNow,

            };
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Events(EventId, EventType, AggregateId, Data, CreatedAt) VALUES (@EventId, @EventType, @AggregateId, @Data, @CreatedAt)";

            await connection.ExecuteAsync(sql, new
            {
                @event.EventId,
                @event.EventType,
                @event.AggregateId,
                Data = JsonSerializer.Serialize(@event.Data),
                @event.CreatedAt,
            });
            var json = JsonSerializer.Serialize(@event.Data);
            await _producer.ProduceAsync("users-events", new Message<Null, string> { Value = json });
        }
    }
}
