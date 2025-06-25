using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class BattleEventV2Tests
{
    [Theory]
    [InlineData(2000, 1000)]
    [InlineData(1000, 2000)]
    [InlineData(1000, 1000)]
    public void CreatureWithHigherPowerWinsAndLosersAreDestroyed(int attackingCreaturePower, int defendingCreaturePower)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.SetupGet(x => x.Power).Returns(attackingCreaturePower);
        var defendingCreature = new Mock<ICreature>();
        defendingCreature.SetupGet(x => x.Power).Returns(defendingCreaturePower);
        var battle = new BattleEventV2(player, attackingCreature.Object, defendingCreature.Object);
        var state = new Mock<IGameState>();
        state.Setup(x => x.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            It.IsAny<ICreature>(), It.IsAny<ICreature>())).Returns(true);
        var winners = new List<ICreature>();
        if (attackingCreaturePower > defendingCreaturePower)
        {
            winners.Add(attackingCreature.Object);
        }
        if (attackingCreaturePower < defendingCreaturePower)
        {
            winners.Add(defendingCreature.Object);
        }
        var losers = new List<ICreature>() { attackingCreature.Object, defendingCreature.Object }.Where(
            x => !winners.Contains(x));
        var expected = losers.Select(x => new PutIntoGraveyardEvent(x.OwnerV2, x));

        // Act
        var events = battle.Happen(state.Object);

        // Assert
        Assert.Equal(winners, battle.Winners);
        Assert.Equal(expected, events);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.Setup(x => x.Copy()).Returns(attackingCreature.Object);
        var defendingCreature = new Mock<ICreature>();
        defendingCreature.Setup(x => x.Copy()).Returns(defendingCreature.Object);
        var battle = new BattleEventV2(player.Object, attackingCreature.Object, defendingCreature.Object);

        // Act
        var copy = battle.Copy();

        // Assert
        Assert.Equal(battle, copy);
    }

    [Fact]
    public void SecondHappeningReturnsNoEvents()
    {
        // Arrange
        var battle = new BattleEventV2(Mock.Of<IPlayerV2>(), Mock.Of<ICreature>(), Mock.Of<ICreature>());
        var state = new Mock<IGameState>();
        state.Setup(x => x.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            It.IsAny<ICreature>(), It.IsAny<ICreature>())).Returns(true);
        _ = battle.Happen(state.Object);

        // Act
        var events = battle.Happen(state.Object);

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void EffectPreventsLoserFromBeingDestroyed()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var strongerCreature = new Mock<ICreature>();
        strongerCreature.SetupGet(x => x.Power).Returns(2000);
        var weakerCreature = new Mock<ICreature>();
        weakerCreature.SetupGet(x => x.Power).Returns(1000);
        var battle = new BattleEventV2(player, strongerCreature.Object, weakerCreature.Object);
        var state = new Mock<IGameState>();
        state.Setup(x => x.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            strongerCreature.Object, weakerCreature.Object)).Returns(false);
        _ = battle.Happen(state.Object);

        // Act
        var events = battle.Happen(state.Object);

        // Assert
        Assert.Single(battle.Winners);
        Assert.Contains(strongerCreature.Object, battle.Winners);
        Assert.Empty(events);
    }
}
