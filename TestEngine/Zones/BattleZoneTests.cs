using System;
using System.Linq;
using Engine.Zones;
using Interfaces;
using Moq;
using Xunit;

namespace TestEngine.Zones;

public sealed class BattleZoneTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var zone = new BattleZone();
        var another = zone.Copy();

        // Act
        var first = zone.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }

    [Fact]
    public void GetChoosableCreaturesControlledByPlayer()
    {
        Assert.Throws<NotImplementedException>(
            () => new BattleZone().GetChoosableCreaturesControlledByPlayer(
                Mock.Of<IGame>(), Guid.NewGuid()));
    }

    [Fact]
    public void GetUntappedCreatures()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(false);
        creature.SetupGet(x => x.OwnerV2).Returns(player);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetUntappedCreatures(player);

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetNumberOfOtherCreaturesControllerByPlayer(int expected)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var excluded = new Mock<ICreature>();
        excluded.SetupGet(x => x.OwnerV2).Returns(player);
        var zone = new BattleZone();
        zone.Add(excluded.Object);
        for (var i = 0; i < expected; ++i)
        {
            var otherCreature = new Mock<ICreature>();
            otherCreature.SetupGet(x => x.OwnerV2).Returns(player);
            zone.Add(otherCreature.Object);
        }

        // Act
        var actual = zone.GetNumberOfOtherCreaturesControllerByPlayer(
            excluded.Object);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetNumberOfOtherCreaturesControllerByPlayerWithFilter(
        bool filterMatches, int expected)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var excluded = new Mock<ICreature>();
        excluded.SetupGet(x => x.OwnerV2).Returns(player);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.OwnerV2).Returns(player);
        var zone = new BattleZone();
        zone.Add(excluded.Object);
        zone.Add(otherCreature.Object);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(otherCreature.Object)).Returns(filterMatches);

        // Act
        var amount = zone.GetNumberOfOtherCreaturesControllerByPlayer(
            excluded.Object, filter.Object);
        var hasCards = zone.HasOtherCreaturesControllerByPlayer(
            excluded.Object, filter.Object);

        // Assert
        Assert.Equal(expected, amount);
        Assert.Equal(filterMatches, hasCards);
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetCreaturesControllerByPlayer(
        bool filterMatches, int expected)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(player);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(creature.Object)).Returns(filterMatches);

        // Act
        var amount = zone.GetNumberOfCreaturesControllerByPlayer(
            player, filter.Object);
        var hasCards = zone.HasCreaturesControllerByPlayer(
            player, filter.Object);

        // Assert
        Assert.Equal(expected, amount);
        Assert.Equal(filterMatches, hasCards);
    }

    [Theory]
    [InlineData(false, false, 0)]
    [InlineData(true, false, 0)]
    [InlineData(false, true, 0)]
    [InlineData(true, true, 1)]
    public void GetExpectedNumberOfOtherCreatures(
        bool filterMatches, bool canBeChosen, int expectedCount)
    {
        // Arrange
        var opponent = Mock.Of<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(opponent);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(creature.Object)).Returns(filterMatches);
        var game = new Mock<IGame>();
        game.Setup(x => x.ContinuousEffects.CanPlayerChooseCreature(
            player.Object, creature.Object)).Returns(canBeChosen);

        // Act
        var creatures = zone.GetOpponentsChoosableCreatures(
            player.Object, filter.Object, game.Object);

        // Assert
        Assert.Equal(expectedCount, creatures.Count());
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetCreatures(bool filterMatches, int expectedCount)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var zone = new BattleZone();
        zone.Add(creature);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(creature)).Returns(filterMatches);

        // Act
        var creatures = zone.GetCreatures(filter.Object);

        // Assert
        Assert.Equal(expectedCount, creatures.Count());
    }

    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetNumberOfOtherCreatures(bool filterMatches, int expected)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var excluded = Mock.Of<ICreature>();
        var zone = new BattleZone();
        zone.Add(creature);
        zone.Add(excluded);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(creature)).Returns(filterMatches);

        // Act
        var creatures = zone.GetNumberOfOtherCreatures(excluded, filter.Object);

        // Assert
        Assert.Equal(expected, creatures);
    }

    [Theory]
    [InlineData(false, false, SelectionRange.AllCreatures, 0)]
    [InlineData(true, false, SelectionRange.AllCreatures, 1)]
    [InlineData(false, true, SelectionRange.AllCreatures, 1)]
    [InlineData(true, true, SelectionRange.AllCreatures, 2)]
    [InlineData(false, false, SelectionRange.OpponentsCreatures, 0)]
    [InlineData(true, false, SelectionRange.OpponentsCreatures, 0)]
    [InlineData(false, true, SelectionRange.OpponentsCreatures, 1)]
    [InlineData(true, true, SelectionRange.OpponentsCreatures, 1)]
    [InlineData(false, false, SelectionRange.OwnCreatures, 0)]
    [InlineData(true, false, SelectionRange.OwnCreatures, 1)]
    [InlineData(false, true, SelectionRange.OwnCreatures, 0)]
    [InlineData(true, true, SelectionRange.OwnCreatures, 1)]
    public void GetChoosableCreatures(
        bool filterMatchesOwnCreature,
        bool canBeChosen,
        SelectionRange selectionRange,
        int expectedCount)
    {
        // Arrange
        var opponent = Mock.Of<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent);
        var ownCreature = new Mock<ICreature>();
        ownCreature.SetupGet(x => x.OwnerV2).Returns(player.Object);
        var opponentsCreature = new Mock<ICreature>();
        opponentsCreature.SetupGet(x => x.OwnerV2).Returns(opponent);
        var zone = new BattleZone();
        zone.Add(ownCreature.Object);
        zone.Add(opponentsCreature.Object);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(ownCreature.Object)).Returns(
            filterMatchesOwnCreature);
        filter.Setup(x => x.Match(opponentsCreature.Object)).Returns(true);
        var game = new Mock<IGame>();
        game.Setup(x => x.ContinuousEffects.CanPlayerChooseCreature(
            player.Object, opponentsCreature.Object)).Returns(canBeChosen);

        // Act
        var creatures = zone.GetChoosableCreatures(
            player.Object, filter.Object, game.Object, selectionRange);

        // Assert
        Assert.Equal(expectedCount, creatures.Count());
    }
}