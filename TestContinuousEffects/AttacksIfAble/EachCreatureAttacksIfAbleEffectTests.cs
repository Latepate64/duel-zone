using ContinuousEffects.AttacksIfAble;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AttacksIfAble;

public class EachCreatureAttacksIfAbleEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new EachCreatureAttacksIfAbleEffect();

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
        var effect = new EachCreatureAttacksIfAbleEffect();

        // Act
        var actual = effect.AttacksIfAble(attacker, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}