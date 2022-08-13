
using System.Text.Json;
using Asyncapi.Nats.Client.Models;
using Xunit;

namespace Asyncapi.Nats.Client.Tests
{
    public class ActiveItemTest
    {
        [Fact]
        public void ShouldSerializeAndDeserializeAccurately()
        {
            ActiveItem temp = new ActiveItem();
            string json = JsonSerializer.Serialize(temp);
            ActiveItem output = JsonSerializer.Deserialize<ActiveItem>(json);
            Assert.Equal(temp, output);
        }
    }
}