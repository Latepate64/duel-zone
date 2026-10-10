using System;
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
    public void GetChoosableEvolutionCreaturesControlledByPlayer()
    {
        // Arrange
        var owner = Guid.NewGuid();
        var opponent = Mock.Of<IPlayer>();
        var opponentGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(owner);
        creature.SetupGet(x => x.IsEvolutionCreature).Returns(true);
        var game = new Mock<IGame>();
        game.Setup(x => x.GetOpponent(owner)).Returns(opponentGuid);
        game.Setup(x => x.GetPlayer(opponentGuid)).Returns(opponent);
        game.Setup(x => x.ContinuousEffects.CanPlayerChooseCreature(
            opponent, creature.Object)).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var actual = zone.GetChoosableEvolutionCreaturesControlledByPlayer(
            game.Object, owner);

        // Assert
        Assert.Contains(creature.Object, actual);
    }

    [Fact]
    public void GetChoosableUntappedCreaturesControlledByPlayer()
    {
        // Arrange
        var owner = Guid.NewGuid();
        var opponent = Mock.Of<IPlayer>();
        var opponentGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(owner);
        creature.SetupGet(x => x.Tapped).Returns(false);
        var game = new Mock<IGame>();
        game.Setup(x => x.GetOpponent(owner)).Returns(opponentGuid);
        game.Setup(x => x.GetPlayer(opponentGuid)).Returns(opponent);
        game.Setup(x => x.ContinuousEffects.CanPlayerChooseCreature(
            opponent, creature.Object)).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var actual = zone.GetChoosableUntappedCreaturesControlledByPlayer(
            game.Object, owner);

        // Assert
        Assert.Contains(creature.Object, actual);
    }

    [Fact]
    public void GetChoosableCreaturesControlledByAnyone()
    {
        // Arrange
        var owner = Guid.NewGuid();
        var opponent = Mock.Of<IPlayer>();
        var opponentGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(owner);
        var game = new Mock<IGame>();
        game.Setup(x => x.GetOpponent(owner)).Returns(opponentGuid);
        game.Setup(x => x.GetPlayer(opponentGuid)).Returns(opponent);
        game.Setup(x => x.ContinuousEffects.CanPlayerChooseCreature(
            opponent, creature.Object)).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var actual = zone.GetChoosableCreaturesControlledByAnyone(
            game.Object, owner);

        // Assert
        Assert.Contains(creature.Object, actual);
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
    public void GetCreaturesControllerByPlayerWithFilter(
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
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void GetExpectedNumberOfOtherCreatures(
        bool filterMatches, int expected)
    {
        // Arrange
        var excluded = Mock.Of<ICreature>();
        var otherCreature = Mock.Of<ICreature>();
        var zone = new BattleZone();
        zone.Add(excluded);
        zone.Add(otherCreature);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(otherCreature)).Returns(filterMatches);

        // Act
        var amount = zone.GetNumberOfOtherCreatures(
            excluded, filter.Object);

        // Assert
        Assert.Equal(expected, amount);
    }
}