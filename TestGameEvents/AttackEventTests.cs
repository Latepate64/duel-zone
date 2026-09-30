using GameEvents;
using Interfaces;
using Moq;

namespace TestGameEvents;

public class AttackEventTests
{
    [Theory]
    [InlineData(IllegalActionType.AttackingCreatureIsNull)]
    [InlineData(IllegalActionType.AttackingCreatureIsTapped)]
    [InlineData(IllegalActionType.AttackingCreatureHasSummoningSickness)]
    [InlineData(IllegalActionType.AttackedCreatureAndAttackedPlayerAreNull)]
    public void AttackingCreatureIsInvalidThrows(
        IllegalActionType illegalActionType)
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(
            illegalActionType == IllegalActionType.AttackingCreatureIsTapped);
        creature.SetupGet(x => x.SummoningSickness).Returns(illegalActionType ==
            IllegalActionType.AttackingCreatureHasSummoningSickness);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature =
                illegalActionType == IllegalActionType.AttackingCreatureIsNull
                ? null : creature.Object
        };

        // Act
        var ex = Assert.Throws<IllegalActionException>(
            () => attack.Validate(attack));

        // Assert
        Assert.Equal(illegalActionType, ex.Type);
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
        var ex = Assert.Throws<IllegalActionException>(
            () => attack.Validate(attack));

        // Assert
        Assert.Equal(
            IllegalActionType.AttackedCreatureAndAttackedPlayerAreNotNull,
            ex.Type);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ValidationSucceedsWhenCreatureAttacksLegalTarget(
        bool attackCreatureInsteadOfPlayer)
    {
        // Arrange
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.SummoningSickness).Returns(false);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = creature.Object,
            AttackedCreature = attackCreatureInsteadOfPlayer
                ? Mock.Of<ICreature>() : null,
            AttackedPlayer = attackCreatureInsteadOfPlayer
                ? null : Mock.Of<IPlayerV2>()
        };

        // Act + Assert
        attack.Validate(attack);
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
        var expected = new BattleEventV2(
            player, attack.AttackingCreature, attack.AttackedCreature);

        // Act
        attack.Validate(attack);
        var events = attack.Happen(Mock.Of<IGameState>());

        // Assert
        creature.Verify(x => x.Tapped, Times.Once());
        Assert.Equal(expected, events.Single());
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var attack = new AttackEvent(player.Object);

        // Act
        var actual = attack.Copy();
        
        // Assert
        Assert.Equal(attack, actual);
    }

    [Fact]
    public void CopyEqualsOriginalWithProperties()
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.Copy()).Returns(player.Object);
        var attackingCreature = new Mock<ICreature>();
        attackingCreature.Setup(x => x.Copy()).Returns(
            attackingCreature.Object);
        var attackedCreature = new Mock<ICreature>();
        attackedCreature.Setup(x => x.Copy()).Returns(attackedCreature.Object);
        var attackedPlayer = new Mock<IPlayerV2>();
        attackedPlayer.Setup(x => x.Copy()).Returns(attackedPlayer.Object);
        var attack = new AttackEvent(player.Object)
        {
            AttackingCreature = attackingCreature.Object,
            AttackedCreature = attackedCreature.Object,
            AttackedPlayer = attackedPlayer.Object,
        };

        // Act
        var actual = attack.Copy();
        
        // Assert
        Assert.Equal(attack, actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoesNotEqualEventOfAnotherType(bool isNull)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var attack = new AttackEvent(player);

        // Act
        var actual = attack.Equals(isNull ? null : new UseCardEvent(player));

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAttackEventThatShouldEnd()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var attack = new AttackEvent(player);
        var another = new AttackEvent(player);
        another.Happen(Mock.Of<IGameState>());

        // Act
        var actual = attack.Equals(another);

        // Assert
        Assert.False(actual);
    }

    public enum Different
    {
        AttackingCreature,
        AttackedCreature,
        AttackedPlayer,
    }

    [Theory]
    [InlineData(Different.AttackingCreature)]
    [InlineData(Different.AttackedCreature)]
    [InlineData(Different.AttackedPlayer)]
    public void DoesNotEqualAttackEventWithDifferentProperties(
        Different different)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var attackingCreature = Mock.Of<ICreature>();
        var attackedCreature = Mock.Of<ICreature>();
        var attackedPlayer = Mock.Of<IPlayerV2>();
        var attack = new AttackEvent(player)
        {
            AttackingCreature = attackingCreature,
            AttackedCreature = attackedCreature,
            AttackedPlayer = attackedPlayer
        };
        var another = new AttackEvent(player)
        {
            AttackingCreature = different == Different.AttackingCreature 
                ? null : attackingCreature,
            AttackedCreature = different == Different.AttackedCreature 
                ? null : attackedCreature,
            AttackedPlayer = different == Different.AttackedPlayer 
                ? null : attackedPlayer,
        };

        // Act
        var actual = attack.Equals(another);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void HashCodesAreEqualForEqualAttackEvents(bool propertiesNull)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var attackingCreature = Mock.Of<ICreature>();
        var attackedCreature = Mock.Of<ICreature>();
        var attackedPlayer = Mock.Of<IPlayerV2>();
        var attack = new AttackEvent(player)
        {
            AttackingCreature = propertiesNull ? null : attackingCreature,
            AttackedCreature = propertiesNull ? null : attackedCreature,
            AttackedPlayer = propertiesNull ? null : attackedPlayer
        };
        var another = new AttackEvent(player)
        {
            AttackingCreature = propertiesNull ? null : attackingCreature,
            AttackedCreature = propertiesNull ? null : attackedCreature,
            AttackedPlayer = propertiesNull ? null : attackedPlayer
        };
        var expected = another.GetHashCode();

        // Act
        var actual = attack.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NothingHappensAfterTheEventEnds()
    {
        // Arrange
        var attack = new AttackEvent(Mock.Of<IPlayerV2>());
        _ = attack.Happen(Mock.Of<IGameState>());

        // Act
        var events = attack.Happen(Mock.Of<IGameState>());

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void
        HavingNoAttackTargetThrowsNullReferenceExceptionAndAttackingCreatureIsSetUntapped()
    {
        // Arrange
        var attackingCreature = new Mock<ICreature>();
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = attackingCreature.Object
        };

        // Act
        var ex = Assert.Throws<NullReferenceException>(
            () => attack.Happen(Mock.Of<IGameState>()));

        // Assert
        attackingCreature.VerifySet(x => x.Tapped = false);
    }

    [Fact]
    public void PlayerWithoutShieldsLosesWhenDirectlyAttacked()
    {
        // Arrange
        var attackingCreature = new Mock<ICreature>();
        var attackedPlayer = new Mock<IPlayerV2>();
        attackedPlayer.SetupGet(x => x.ShieldZone.HasCards).Returns(false);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = attackingCreature.Object,
            AttackedPlayer = attackedPlayer.Object
        };
        var expected = new LoseGameEvent(attackedPlayer.Object);

        // Act
        var events = attack.Happen(Mock.Of<IGameState>());

        // Assert
        attackingCreature.VerifySet(x => x.Tapped = true);
        Assert.Equal(expected, events.Single());
    }

    [Fact]
    public void
        NotImplementedExceptionIsThrownWhenPlayerWithShieldsIsDirectlyAttacked()
    {
        // Arrange
        var attackingCreature = new Mock<ICreature>();
        var attackedPlayer = new Mock<IPlayerV2>();
        attackedPlayer.SetupGet(x => x.ShieldZone.HasCards).Returns(true);
        var attack = new AttackEvent(Mock.Of<IPlayerV2>())
        {
            AttackingCreature = attackingCreature.Object,
            AttackedPlayer = attackedPlayer.Object
        };
        var expected = new LoseGameEvent(attackedPlayer.Object);

        // Act + Assert
        var ex = Assert.Throws<NotImplementedException>(
            () => attack.Happen(Mock.Of<IGameState>()));
    }
}
