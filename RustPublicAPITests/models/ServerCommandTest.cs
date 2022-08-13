
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ServerCommandTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ServerCommand temp = new ServerCommand();
            string json = JsonSerializer.Serialize(temp);
            ServerCommand output = JsonSerializer.Deserialize<ServerCommand>(json);
            Assert.Equal(temp, output);
        }
    }
}