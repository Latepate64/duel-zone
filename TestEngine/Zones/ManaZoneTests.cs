using System.Linq;
using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class ManaZoneTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new ManaZone();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CardIsTapped(bool isTapped)
    {
        // Arrange
        var zone = new ManaZone();
        var card = new Mock<ICard>();
        card.SetupGet(x => x.Tapped).Returns(isTapped);
        zone.Add(card.Object);

        // Act
        var tapped = zone.TappedCards;
        var untapped = zone.UntappedCards;

        // Assert
        Assert.Equal(isTapped ? 1 : 0, tapped.Count());
        Assert.Equal(isTapped ? 0 : 1, untapped.Count());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AreAllCivilizationCards(bool value)
    {
        // Arrange
        var zone = new ManaZone();
        var card = new Mock<ICard>();
        card.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>())).Returns(value);
        zone.Add(card.Object);

        // Act
        var actual = zone.AreAllCivilizationCards(Civilization.Light);

        // Assert
        Assert.Equal(value, actual);
    }

    [Theory]
    [InlineData(1, true, false)]
    [InlineData(1, false, false)]
    [InlineData(2, true, true)]
    [InlineData(2, false, false)]
    public void GetNonEvolutionCreaturesThatCostSameOrLessThan(
        int maximum, bool IsNonEvolutionCreature, bool returnsCreature)
    {
        // Arrange
        var zone = new ManaZone();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.IsNonEvolutionCreature).Returns(
            IsNonEvolutionCreature);
        creature.SetupGet(x => x.ManaCost).Returns(2);
        zone.Add(creature.Object);

        // Act
        var actual = zone.GetNonEvolutionCreaturesThatCostSameOrLessThan(
            maximum);

        // Assert
        if (returnsCreature)
        {
            Assert.Single(actual);
            Assert.Contains(creature.Object, actual);
        }
        else
        {
            Assert.Empty(actual);
        }
    }
}