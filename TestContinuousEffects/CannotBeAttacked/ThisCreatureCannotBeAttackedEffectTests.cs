using ContinuousEffects.CannotBeAttacked;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotBeAttacked;

public class ThisCreatureCannotBeAttackedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureCannotBeAttackedEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesOnlyToTheCreatureItself(bool expected)
    {
        // Arrange
        var targetOfAttack = new Mock<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(targetOfAttack.Object);
        var effect = new ThisCreatureCannotBeAttackedEffect
        {
            Ability = expected ? ability.Object : null
        };

        // Act
        var actual = effect.Applies(attacker: null, targetOfAttack.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}