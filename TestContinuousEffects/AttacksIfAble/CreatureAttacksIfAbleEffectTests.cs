using ContinuousEffects.AttacksIfAble;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AttacksIfAble;

public class CreatureAttacksIfAbleEffectTests
{
    private static CreatureAttacksIfAbleEffect CreateEffect(ICreature creature)
    {
        return (CreatureAttacksIfAbleEffect)
            new CreatureAttacksIfAbleEffectFactory().Create(creature);
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
    public void CreatureAttacksIfAble()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var effect = CreateEffect(creature);

        // Act
        var actual = effect.AttacksIfAble(creature, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}