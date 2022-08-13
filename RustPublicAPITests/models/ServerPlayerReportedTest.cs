
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerPlayerReportedTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerPlayerReported temp = new ServerPlayerReported();
            string json = JsonSerializer.Serialize(temp);
            ServerPlayerReported output = JsonSerializer.Deserialize<ServerPlayerReported>(json);
            Assert.Equal(temp, output);
        }
    }
}