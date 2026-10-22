using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedWhileAttackingCreatureEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CanBeBlockedWhileAttackingPlayer()
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<IPlayerV2>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect()
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotBeBlocked(attacker.Object, blocker, targetOfAttack, battleZone);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CannotBeBlockedWhileAttackingCreature()
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new ThisCreatureCannotBeBlockedWhileAttackingCreatureEffect()
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotBeBlocked(attacker.Object, blocker, targetOfAttack, battleZone);

        // Assert
        Assert.True(actual);
    }
}