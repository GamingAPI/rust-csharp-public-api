
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerStoppedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerStopped temp = new ServerStopped();
            string json = JsonSerializer.Serialize(temp);
            ServerStopped output = JsonSerializer.Deserialize<ServerStopped>(json);
            Assert.Equal(temp, output);
        }
    }
}