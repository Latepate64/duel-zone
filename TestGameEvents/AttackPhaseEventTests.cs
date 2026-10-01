using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class AttackPhaseEventTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var e = new AttackPhaseEvent(player.Object);

        // Act
        var actual = e.Copy();
        
        // Assert
        Assert.Equal(e, actual);
    }

    [Fact]
    public void
        NothingHappensWhenActivePlayerHasNoUntappedCreaturesWithoutSummoningSicknessInTheBattleZone()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new AttackPhaseEvent(player);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(true);
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetUntappedCreatures(player)).Returns(
            [creature.Object]);

        // Act
        var events = e.Happen(state.Object);
        
        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void
        AttackMayHappenWhenActivePlayerHasUntappedCreatureWithoutSummoningSicknessInTheBattleZone()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var e = new AttackPhaseEvent(player);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(false);
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetUntappedCreatures(player)).Returns(
            [creature.Object]);
        var expected = new AttackEvent(player);

        // Act
        var events = e.Happen(state.Object);
        
        // Assert
        Assert.Contains(expected, events);
    }
}