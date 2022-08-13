
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            Player temp = new Player();
            string json = JsonSerializer.Serialize(temp);
            Player output = JsonSerializer.Deserialize<Player>(json);
            Assert.Equal(temp, output);
        }
    }
}