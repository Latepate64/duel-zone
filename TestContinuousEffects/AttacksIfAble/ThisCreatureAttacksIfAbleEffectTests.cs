using ContinuousEffects.AttacksIfAble;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AttacksIfAble;

public class ThisCreatureAttacksIfAbleEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureAttacksIfAbleEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CreatureAttacksIfAble()
    {
        // Arrange
        var attacker = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker);
        var effect = new ThisCreatureAttacksIfAbleEffect()
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.AttacksIfAble(attacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}