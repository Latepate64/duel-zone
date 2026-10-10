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
    public void GetCreatureCountOfSpecificRace()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.Setup(x => x.HasRace(It.IsAny<Race>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var count = zone.GetCreatureCount(controller, It.IsAny<Race>());

        // Assert
        Assert.Equal(1, count);
    }

    [Theory]
    [InlineData(false, false, false)]
    [InlineData(false, true, true)]
    [InlineData(true, false, true)]
    [InlineData(true, true, true)]
    public void GetCreaturesThatHasAtLeastOneOfTheRaces(
        bool hasRace1, bool hasRace2, bool returnCreature)
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.Setup(x => x.HasRace(Race.AngelCommand)).Returns(hasRace1);
        creature.Setup(x => x.HasRace(Race.ArmoredDragon)).Returns(hasRace2);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetCreatures(controller, Race.AngelCommand,
            Race.ArmoredDragon);

        // Assert
        if (returnCreature)
        {
            Assert.Contains(creature.Object, creatures);
            Assert.Single(creatures);
        }
        else
        {
            Assert.Empty(creatures);
        }
    }

    [Fact]
    public void GetCreaturesOfCivilization()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetCreatures(controller, It.IsAny<Civilization>());

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetCreaturesOfAtLeastOneCivilization()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>(), It.IsAny<Civilization>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetCreatures(
            controller, It.IsAny<Civilization>(), It.IsAny<Civilization>());

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetOtherCreatureOfCivilizationCount()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creatureGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Id).Returns(creatureGuid);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.Owner.Id).Returns(controller);
        otherCreature.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        zone.Add(otherCreature.Object);

        // Act
        var count = zone.GetOtherCreatureCount(
            controller, creatureGuid, It.IsAny<Civilization>());

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void GetOtherTappedCreatures()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creatureGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Id).Returns(creatureGuid);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.Owner.Id).Returns(controller);
        otherCreature.SetupGet(x => x.Tapped).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        zone.Add(otherCreature.Object);

        // Act
        var creatures = zone.GetOtherTappedCreatures(controller, creatureGuid);

        // Assert
        Assert.Contains(otherCreature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetOtherUntappedCreatures()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creatureGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Id).Returns(creatureGuid);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.Owner.Id).Returns(controller);
        otherCreature.SetupGet(x => x.Tapped).Returns(false);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        zone.Add(otherCreature.Object);

        // Act
        var creatures = zone.GetOtherUntappedCreatures(
            controller, creatureGuid);

        // Assert
        Assert.Contains(otherCreature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetOtherCreaturesOfCivilization()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creatureGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Id).Returns(creatureGuid);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.Owner.Id).Returns(controller);
        otherCreature.Setup(x => x.HasCivilization(
            It.IsAny<Civilization>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        zone.Add(otherCreature.Object);

        // Act
        var creatures = zone.GetOtherCreatures(
            creatureGuid, It.IsAny<Civilization>());

        // Assert
        Assert.Contains(otherCreature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void GetOtherCreatureCountOfSpecificRace()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creatureGuid = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Id).Returns(creatureGuid);
        var otherCreature = new Mock<ICreature>();
        otherCreature.SetupGet(x => x.Owner.Id).Returns(controller);
        otherCreature.Setup(x => x.HasRace(It.IsAny<Race>())).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);
        zone.Add(otherCreature.Object);

        // Act
        var count = zone.GetOtherCreatureCount(controller, It.IsAny<Race>());

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public void GetTappedCreatures()
    {
        // Arrange
        var controller = Guid.NewGuid();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Owner.Id).Returns(controller);
        creature.SetupGet(x => x.Tapped).Returns(true);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.GetTappedCreatures(controller);

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
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

    [Fact]
    public void CreaturesThatHaveBlockerOwnedBy()
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.IsBlocker).Returns(true);
        creature.SetupGet(x => x.Owner).Returns(player);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.CreaturesThatHaveBlockerOwnedBy(player);

        // Assert
        Assert.Contains(creature.Object, creatures);
        Assert.Single(creatures);
    }

    [Fact]
    public void CreaturesThatDoNotHaveBlocker()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.IsBlocker).Returns(false);
        var zone = new BattleZone();
        zone.Add(creature.Object);

        // Act
        var creatures = zone.CreaturesThatDoNotHaveBlocker;

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
    [InlineData(0)]
    [InlineData(1)]
    public void GetOtherCivilizationCreaturesControllerByPlayer(int expected)
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
            otherCreature.Setup(x => x.HasCivilization(
                Civilization.Light)).Returns(true);
            zone.Add(otherCreature.Object);
        }

        // Act
        var actual = zone.GetOtherCivilizationCreaturesControllerByPlayer(
            excluded.Object, Civilization.Light);

        // Assert
        Assert.Equal(expected, actual.Count());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetCreaturesWithSilentSkillControllerByPlayer(int expected)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var zone = new BattleZone();
        for (var i = 0; i < expected; ++i)
        {
            var creature = new Mock<ICreature>();
            creature.SetupGet(x => x.OwnerV2).Returns(player);
            creature.Setup(
                x => x.HasAbility<ISilentSkillAbility>()).Returns(true);
            zone.Add(creature.Object);
        }

        // Act
        var actual = zone.GetCreaturesWithSilentSkillControllerByPlayer(player);

        // Assert
        Assert.Equal(expected, actual.Count());
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
        var actual = zone.GetNumberOfOtherCreaturesControllerByPlayer(
            excluded.Object, filter.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}