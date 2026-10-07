using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class ThisCreatureCannotBeAttackedByDragonsEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureCannotBeAttackedByDragonsEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void DoesNotApplyToOtherCreatures()
    {
        // Arrange
        var effect = new ThisCreatureCannotBeAttackedByDragonsEffect();
        var targetOfAttack = Mock.Of<ICreature>();

        // Act
        var actual = effect.Applies(attacker: null, targetOfAttack);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesWhenTheAttackingCreatureIsDragon(bool isDragon)
    {
        // Arrange
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.IsDragon).Returns(isDragon);
        var targetOfAttack = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(targetOfAttack);
        var effect = new ThisCreatureCannotBeAttackedByDragonsEffect
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.Applies(attacker.Object, targetOfAttack);

        // Assert
        Assert.Equal(isDragon, actual);
    }
}