
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerRespawnedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerRespawned temp = new ServerPlayerRespawned();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerRespawned output = JsonSerializer.Deserialize<ServerPlayerRespawned>(json);
            Assert.Equal(temp, output);
        }
    }
}