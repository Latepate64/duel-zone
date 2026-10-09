using Abilities;
using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;
using Moq;

namespace TestAbilities.Static;

public class StaticAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new Mock<IContinuousEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new StaticAbility(effect.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
        Assert.Single(((StaticAbility)copy).ContinuousEffects);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var ability = new StaticAbility(Mock.Of<IContinuousEffect>());

        // Act
        var actual = ability.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualNonStaticAbility()
    {
        // Arrange
        var ability = new StaticAbility(Mock.Of<IContinuousEffect>());

        // Act
        var actual = ability.Equals(new SpellAbility(
            Mock.Of<IOneShotEffect>()));

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualStaticAbilityWithDifferentContinuousEffects()
    {
        // Arrange
        var ability = new StaticAbility(Mock.Of<IContinuousEffect>());
        var other = new StaticAbility(Mock.Of<IContinuousEffect>());

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualAbilities()
    {
        // Arrange
        var effect = new Mock<IContinuousEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new StaticAbility(effect.Object);
        var copy = ability.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = ability.GetHashCode();

        // Assert
        Assert.Equal(ability, copy);
    }
}