using Engine.Zones;
using Xunit;

namespace TestEngine.Zones;

public sealed class HandTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new Hand();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}