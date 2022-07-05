
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerStartedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerStarted temp = new ServerStarted();
            string json = JsonSerializer.Serialize(temp);
            ServerStarted output = JsonSerializer.Deserialize<ServerStarted>(json);
            Assert.Equal(temp, output);
        }
    }
}