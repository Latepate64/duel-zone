using ContinuousEffects.CanAttackUntappedCreatures;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CanAttackUntappedCreatures;

public class YourCreaturesCanAttackUntappedCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new YourCreaturesCanAttackUntappedCreaturesEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CreatureCanAttackUntappedCreature()
    {
        // Arrange
        var targetOfAttack = Mock.Of<ICreature>();
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new YourCreaturesCanAttackUntappedCreaturesEffect()
        {
            Ability = ability.Object,
            Applier = player
        };

        // Act
        var actual = effect.CanAttackUntappedCreature(
            attacker.Object, targetOfAttack, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}