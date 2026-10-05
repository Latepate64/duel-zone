using System.Linq;
using Engine;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class PlayerV2Tests
{
    [Fact]
    public void HashCodesAreEqualForEqualPlayers()
    {
        // Arrange
        var first = new PlayerV2();
        var second = first.Copy();
        var expected = second.GetHashCode();

        // Act
        var actual = first.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfDifferentType()
    {
        // Arrange
        var e = new PlayerV2();
        var other = new object();

        // Act
        var equal = e.Equals(other);
        
        // Assert
        Assert.False(equal);
    }

    [Theory]
    [InlineData(ZoneType.Deck)]
    [InlineData(ZoneType.ShieldZone)]
    [InlineData(ZoneType.Hand)]
    [InlineData(ZoneType.ManaZone)]
    [InlineData(ZoneType.Graveyard)]
    public void DoesNotEqualPlayerWithDifferentZone(ZoneType zoneType)
    {
        // Arrange
        var first = new PlayerV2();
        var second = first.Copy();
        IZone zone = zoneType switch
        {
            ZoneType.Deck => second.Deck,
            ZoneType.ShieldZone => second.ShieldZone,
            ZoneType.Hand => second.Hand,
            ZoneType.ManaZone => second.ManaZone,
            ZoneType.Graveyard => second.Graveyard,
            _ => null
        };
        zone.Add(Mock.Of<ICard>());

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.False(equal);
    }

    [Fact]
    public void EqualsAnotherPlayer()
    {
        // Arrange
        var first = new PlayerV2();
        var second = new PlayerV2();

        // Act
        var equal = first.Equals(second);
        
        // Assert
        Assert.True(equal);
    }

    [Fact]
    public void SetOwnerForCards()
    {
        // Arrange
        var player = new PlayerV2();
        player.Deck.Add(Mock.Of<ICard>());
        player.ShieldZone.Add(Mock.Of<ICard>());
        player.Hand.Add(Mock.Of<ICard>());
        player.ManaZone.Add(Mock.Of<ICard>());
        player.Graveyard.Add(Mock.Of<ICard>());

        // Act
        player.SetOwnerForCards();
        
        // Assert
        Assert.True(player.Deck.Cards.All(x => x.OwnerV2.Equals(player)));
        Assert.True(player.ShieldZone.Cards.All(x => x.OwnerV2.Equals(player)));
        Assert.True(player.Hand.Cards.All(x => x.OwnerV2.Equals(player)));
        Assert.True(player.ManaZone.Cards.All(x => x.OwnerV2.Equals(player)));
        Assert.True(player.Graveyard.Cards.All(x => x.OwnerV2.Equals(player)));
    }
}