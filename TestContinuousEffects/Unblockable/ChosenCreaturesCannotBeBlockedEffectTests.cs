using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class ChosenCreaturesCannotBeBlockedEffectTests
{
    private static ChosenCreaturesCannotBeBlockedEffect CreateEffect(params ICreature[] creatures)
    {
        return (ChosenCreaturesCannotBeBlockedEffect)
            new ChosenCreaturesCannotBeBlockedEffectFactory().Create(creatures);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var effect = CreateEffect(creature);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CannotBeBlocked()
    {
        // Arrangev
        var attacker = Mock.Of<ICreature>();
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<IAttackable>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker);
        var effect = CreateEffect(attacker);
        effect.Ability = ability.Object;
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotBeBlocked(attacker, blocker, targetOfAttack, battleZone);

        // Assert
        Assert.True(actual);
    }
}