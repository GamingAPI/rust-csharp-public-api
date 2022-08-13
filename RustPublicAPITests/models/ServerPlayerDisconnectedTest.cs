
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerDisconnectedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerDisconnected temp = new ServerPlayerDisconnected();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerDisconnected output = JsonSerializer.Deserialize<ServerPlayerDisconnected>(json);
            Assert.Equal(temp, output);
        }
    }
}