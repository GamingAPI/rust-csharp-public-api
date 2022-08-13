
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerItemPickupTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerItemPickup temp = new ServerPlayerItemPickup();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerItemPickup output = JsonSerializer.Deserialize<ServerPlayerItemPickup>(json);
            Assert.Equal(temp, output);
        }
    }
}