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
}
