using Abilities;
using Abilities.Static;
using Interfaces;
using Interfaces.ContinuousEffects;
using Moq;

namespace TestAbilities;

public class SpellAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new Mock<IOneShotEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new SpellAbility(effect.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void ResolvingSetsAbilityReferenceAndAppliesEffect()
    {
        // Arrange
        var effect = new Mock<IOneShotEffect>();
        var ability = new SpellAbility(effect.Object);
        var game = Mock.Of<IGame>();

        // Act
        ability.Resolve(game);

        // Assert
        effect.VerifySet(x => x.Ability = ability);
        effect.Verify(x => x.Apply(game));
    }

    [Fact]
    public void DoesNotEqualObjectThatIsNotAbility()
    {
        // Arrange
        var first = new SpellAbility(Mock.Of<IOneShotEffect>());

        // Act
        var actual = first.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithoutSource()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var first = new SpellAbility(effect);
        var second = new SpellAbility(effect) { Source = Mock.Of<ICard>() };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentSource()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var first = new SpellAbility(effect) { Source = Mock.Of<ICard>() };
        var second = new SpellAbility(effect) { Source = Mock.Of<ICard>() };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithoutController()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var source = Mock.Of<ICard>();
        var first = new SpellAbility(effect) { Source = source };
        var second = new SpellAbility(
            effect) { Source = source, Controller = Mock.Of<IPlayer>() };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentController()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var source = Mock.Of<ICard>();
        var first = new SpellAbility(
            effect) { Source = source, Controller = Mock.Of<IPlayer>() };
        var second = new SpellAbility(
            effect) { Source = source, Controller = Mock.Of<IPlayer>() };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualNonResolvableAbility()
    {
        // Arrange
        var effect = Mock.Of<IOneShotEffect>();
        var source = Mock.Of<ICard>();
        var controller = Mock.Of<IPlayer>();
        var first = new SpellAbility(
            effect) { Source = source, Controller = controller };
        var second = new StaticAbility(Mock.Of<IContinuousEffect>())
        {
            Source = source,
            Controller = controller
        };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualSpellAbilityWithDifferentEffect()
    {
        // Arrange
        var source = Mock.Of<ICard>();
        var controller = Mock.Of<IPlayer>();
        var first = new SpellAbility(Mock.Of<IOneShotEffect>())
            { Source = source, Controller = controller };
        var second = new SpellAbility(Mock.Of<IOneShotEffect>())
            { Source = source, Controller = controller };

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualAbilities()
    {
        // Arrange
        var effect = new Mock<IOneShotEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        var ability = new SpellAbility(effect.Object);
        var copy = ability.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = ability.GetHashCode();

        // Assert
        Assert.Equal(ability, copy);
    }
}