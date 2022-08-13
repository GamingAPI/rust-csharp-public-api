
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerConnectedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerConnected temp = new ServerPlayerConnected();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerConnected output = JsonSerializer.Deserialize<ServerPlayerConnected>(json);
            Assert.Equal(temp, output);
        }
    }
}