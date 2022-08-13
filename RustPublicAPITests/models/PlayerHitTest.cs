
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class PlayerHitTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            PlayerHit temp = new PlayerHit();
            string json = JsonSerializer.Serialize(temp);
            PlayerHit output = JsonSerializer.Deserialize<PlayerHit>(json);
            Assert.Equal(temp, output);
        }
    }
}