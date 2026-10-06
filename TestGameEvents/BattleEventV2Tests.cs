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
    public void CreaturesWithLowerPowerAreDestroyed(
        int attackingCreaturePower, int defendingCreaturePower)
    {
        // Arrange
        var attackingPlayer = Mock.Of<IPlayerV2>();
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.SetupGet(x => x.Power).Returns(
            attackingCreaturePower);
        attackingCreature.SetupGet(x => x.OwnerV2).Returns(attackingPlayer);
        var defendingPlayer = Mock.Of<IPlayerV2>();
        var defendingCreature = new Mock<ICreature>();
        defendingCreature.SetupGet(x => x.Power).Returns(
            defendingCreaturePower);
        defendingCreature.SetupGet(x => x.OwnerV2).Returns(defendingPlayer);
        var battle = new BattleEventV2(attackingCreature.Object,
            defendingCreature.Object);
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
        var losers = new List<ICreature> { 
            defendingCreature.Object, attackingCreature.Object }.Where(
            x => !winners.Contains(x));
        var expected = losers.Select(x => new PutIntoGraveyardEvent(
            x.OwnerV2, x));

        // Act
        var events = battle.Happen(state.Object);

        // Assert
        Assert.Equal(expected, events);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.Setup(x => x.Copy()).Returns(
            attackingCreature.Object);
        var defendingCreature = new Mock<ICreature>();
        defendingCreature.Setup(x => x.Copy()).Returns(
            defendingCreature.Object);
        var battle = new BattleEventV2(attackingCreature.Object,
            defendingCreature.Object);

        // Act
        var copy = battle.Copy();

        // Assert
        Assert.Equal(battle, copy);
    }

    [Fact]
    public void SecondHappeningReturnsNoEvents()
    {
        // Arrange
        var battle = new BattleEventV2(Mock.Of<ICreature>(),
            Mock.Of<ICreature>());
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
        var strongerCreature = new Mock<ICreature>();
        strongerCreature.SetupGet(x => x.Power).Returns(2000);
        var weakerCreature = new Mock<ICreature>();
        weakerCreature.SetupGet(x => x.Power).Returns(1000);
        var battle = new BattleEventV2(strongerCreature.Object,
            weakerCreature.Object);
        var state = new Mock<IGameState>();
        state.Setup(x => x.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            strongerCreature.Object, weakerCreature.Object)).Returns(false);
        _ = battle.Happen(state.Object);

        // Act
        var events = battle.Happen(state.Object);

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void DoesNotEqualNull()
    {
        // Arrange
        var battle = new BattleEventV2(Mock.Of<ICreature>(),
            Mock.Of<ICreature>());

        // Act
        var actual = battle.Equals(null);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualEventOfAnotherType()
    {
        // Arrange
        var battle = new BattleEventV2(Mock.Of<ICreature>(),
            Mock.Of<ICreature>());
        var attack = new AttackEvent(Mock.Of<IPlayerV2>());

        // Act
        var actual = battle.Equals(attack);

        // Assert
        Assert.False(actual);
    }

    public enum Different
    {
        AttackingCreature,
        DefendingCreature,
    }

    [Theory]
    [InlineData(Different.AttackingCreature)]
    [InlineData(Different.DefendingCreature)]
    public void DoesNotEqualBattleWithDifferentDefender(Different different)
    {
        // Arrange
        var attackingCreature = Mock.Of<ICreature>();
        var attackingCreature2 = different == Different.AttackingCreature
            ? Mock.Of<ICreature>() : attackingCreature;
        var defendingCreature = Mock.Of<ICreature>();
        var defendingCreature2 = different == Different.DefendingCreature
            ? Mock.Of<ICreature>() : defendingCreature;
        var battle = new BattleEventV2(attackingCreature, defendingCreature);
        var another = new BattleEventV2(attackingCreature2, defendingCreature2);

        // Act
        var actual = battle.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualBattleThatShouldNotEnd()
    {
        // Arrange
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.SetupGet(x => x.Power).Returns(2000);
        var defendingCreature = new Mock<ICreature>();
        defendingCreature.SetupGet(x => x.Power).Returns(1000);
        var state = new Mock<IGameState>();
        state.Setup(x => x.ContinuousEffects.DoesCreatureGetDestroyedInBattle(
            It.IsAny<ICreature>(), It.IsAny<ICreature>())).Returns(true);
        var battle = new BattleEventV2(
            attackingCreature.Object,
            defendingCreature.Object);
        var another = new BattleEventV2(
            attackingCreature.Object,
            defendingCreature.Object);
        battle.Happen(state.Object);

        // Act
        var actual = battle.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodeIsNotZero()
    {
        // Arrange
        var battle = new BattleEventV2(Mock.Of<ICreature>(),
            Mock.Of<ICreature>());

        // Act
        var actual = battle.GetHashCode();

        // Assert
        Assert.NotEqual(0, actual);
    }
}
