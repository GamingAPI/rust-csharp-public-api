
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerResourceGatheredTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerResourceGathered temp = new ServerPlayerResourceGathered();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerResourceGathered output = JsonSerializer.Deserialize<ServerPlayerResourceGathered>(json);
            Assert.Equal(temp, output);
        }
    }
}