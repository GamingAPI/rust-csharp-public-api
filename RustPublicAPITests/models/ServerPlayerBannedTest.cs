
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerBannedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerBanned temp = new ServerPlayerBanned();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerBanned output = JsonSerializer.Deserialize<ServerPlayerBanned>(json);
            Assert.Equal(temp, output);
        }
    }
}