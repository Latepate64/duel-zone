using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class TapThisCreatureEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new TapThisCreatureEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new TapThisCreatureEffect();
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void TapsSource()
    {
        // Arrange
        var controller = new Mock<IPlayer>();
        var source = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        ability.SetupGet(x => x.Source).Returns(source);
        var effect = new TapThisCreatureEffect()
        {
            Ability = ability.Object,
        };
        var game = Mock.Of<IGame>();

        // Act
        effect.Apply(game);

        // Assert
        controller.Verify(x => x.Tap(game, source));
    }
}