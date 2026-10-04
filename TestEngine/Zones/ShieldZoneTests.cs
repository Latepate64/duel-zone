using Engine.Zones;
using Xunit;

namespace TestEngine.Zones;

public sealed class ShieldZoneTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new ShieldZone();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}