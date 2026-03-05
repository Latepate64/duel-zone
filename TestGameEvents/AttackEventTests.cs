using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class AttackEventTests
{
    [Fact]
    public void AttackingCreatureIsNullThrows()
    {
        // Arrange
        var attack = new AttackEvent(Mock.Of<IPlayerV2>());

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => attack.Validate(attack));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureIsNull, ex.Type);
    }

    [Fact]
    public void AttackingCreatureIsTappedThrows()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(true);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = creature.Object
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => attack.Validate(attack));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureIsTapped, ex.Type);
    }

    [Fact]
    public void AttackingCreatureHasSummoningSicknessThrows()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(true);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = creature.Object
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => attack.Validate(attack));

        // Assert
        Assert.Equal(IllegalActionType.AttackingCreatureHasSummoningSickness, ex.Type);
    }

    [Fact]
    public void AttackedCreatureAndAttackedPlayerAreNullThrows()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(false);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = creature.Object
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => attack.Validate(attack));

        // Assert
        Assert.Equal(IllegalActionType.AttackedCreatureAndAttackedPlayerAreNull, ex.Type);
    }

    [Fact]
    public void AttackedCreatureAndAttackedPlayerAreNotNullThrows()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(false);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = creature.Object,
            AttackedCreature = Mock.Of<ICreature>(),
            AttackedPlayer = Mock.Of<IPlayerV2>(),
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(() => attack.Validate(attack));

        // Assert
        Assert.Equal(IllegalActionType.AttackedCreatureAndAttackedPlayerAreNotNull, ex.Type);
    }

    [Fact]
    public void AttackingACreatureTapsTheAttackingCreatureAndCreatesABattleEvent()
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(false);
        var player = Mock.Of<IPlayerV2>();
        var attack = new AttackEvent(player)
        {
            AttackingCreature = creature.Object,
            AttackedCreature = Mock.Of<ICreature>(),
        };
        var expected = new BattleEventV2(player, attack.AttackingCreature, attack.AttackedCreature);

        // Act
        attack.Validate(attack);
        var events = attack.Happen(Mock.Of<IGameState>());

        // Assert
        creature.Verify(x => x.Tapped, Times.Once());
        Assert.Equal(expected, events.Single());
    }
}
