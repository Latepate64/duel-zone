using System;
using System.Linq;
using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class ZoneTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.Copy()).Returns(card.Object);
        zone.Add(card.Object);
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var zone = new Hand();

        // Act
        var actual = zone.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualZoneWithDifferentCards()
    {
        // Arrange
        var zone = new Hand();
        var another = new Hand();
        zone.Add(Mock.Of<ICard>());

        // Act
        var actual = zone.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualZoneWithDifferentType()
    {
        // Arrange
        var zone = new Hand();
        var another = new ManaZone();

        // Act
        var actual = zone.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void EqualsAnotherZone()
    {
        // Arrange
        var zone = new Hand();
        var another = new Hand();

        // Act
        var actual = zone.Equals(another);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void RemoveCard()
    {
        // Arrange
        var zone = new Hand();
        var card = Mock.Of<ICard>();
        zone.Add(card);

        // Act
        var actual = zone.Remove(card);

        // Assert
        Assert.Equal([card], actual);
        Assert.False(zone.HasCards);
    }

    [Fact]
    public void RemoveNothing()
    {
        // Arrange
        var zone = new Hand();
        var card = Mock.Of<ICard>();

        // Act
        var actual = zone.Remove(card);

        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public void Dispose()
    {
        // Arrange
        var zone = new Hand();

        // Act + Assert
        zone.Dispose();
    }

    [Fact]
    public void GetCreatureCount()
    {
        // Arrange
        var owner = new Guid();
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(owner);
        zone.Add(creature.Object);

        // Act
        var count = zone.GetCreatureCount(owner);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void GetCreaturesOfRace()
    {
        // Arrange
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Races).Returns([Race.AngelCommand]);
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetCreatures(It.IsAny<Race>());

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetCardsOfCivilizationCount()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.HasCivilization(It.IsAny<Civilization>())).Returns(
            true);
        zone.Add(card.Object);

        // Act
        var count = zone.GetCardCount(It.IsAny<Civilization>());

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void GetCreaturesOfCivilizationCount()
    {
        // Arrange
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>())).Returns(true);
        zone.Add(creature.Object);

        // Act
        var count = zone.GetCreatureCount(It.IsAny<Civilization>());

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void GetOtherCreatures()
    {
        // Arrange
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.Id).Returns(Guid.NewGuid());
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetOtherCreatures(Guid.NewGuid());

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetCreaturesWithMaxPower()
    {
        // Arrange
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.Power).Returns(2000);
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetCreaturesWithMaxPower(2000);

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void Contains()
    {
        // Arrange
        var zone = new Hand();
        var creature = Mock.Of<ICreature>();
        zone.Add(creature);

        // Act
        var contains = zone.Contains(creature);

        // Assert
        Assert.True(contains);
    }

    [Fact]
    public void Shuffle()
    {
        // Arrange
        var zone = new Hand();
        var random = new Mock<IRandomizer>();

        // Act
        zone.Shuffle(random.Object);

        // Assert
        random.Verify(x => x.Shuffle(zone.Cards.ToList()));
    }

    [Fact]
    public void Dragons()
    {
        // Arrange
        var zone = new Hand();
        var creature = new Mock<ICreature>();
        creature.Setup(x => x.IsDragon).Returns(true);
        zone.Add(creature.Object);

        // Act
        var creatures = zone.Dragons;

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void CardsWithName()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.Name).Returns("Emeral");
        zone.Add(card.Object);

        // Act
        var cards = zone.CardsWithName("Emeral");

        // Assert
        Assert.Contains(card.Object, cards);
        Assert.Single(cards);
    }

    [Fact]
    public void NonCivilizationCards()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.HasCivilization(Civilization.Light)).Returns(true);
        zone.Add(card.Object);

        // Act
        var cards = zone.NonCivilizationCards(Civilization.Nature);

        // Assert
        Assert.Contains(card.Object, cards);
        Assert.Single(cards);
    }

    [Fact]
    public void CardsWithManaCost()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        card.Setup(x => x.ManaCost).Returns(1);
        zone.Add(card.Object);

        // Act
        var cards = zone.CardsWithManaCost(1);

        // Assert
        Assert.Contains(card.Object, cards);
        Assert.Single(cards);
    }

    [Fact]
    public void SetOwner()
    {
        // Arrange
        var zone = new Hand();
        var card = new Mock<ICard>();
        zone.Add(card.Object);
        var player = Mock.Of<IPlayerV2>();

        // Act
        zone.SetOwner(player);

        // Assert
        card.VerifySet(x => x.OwnerV2 = player);
    }

    [Fact]
    public void Spells()
    {
        // Arrange
        var zone = new Hand();
        var spell = Mock.Of<ISpell>();
        zone.Add(spell);

        // Act
        var spells = zone.Spells;

        // Assert
        Assert.Contains(spell, spells);
        Assert.Single(spells);
    }
}