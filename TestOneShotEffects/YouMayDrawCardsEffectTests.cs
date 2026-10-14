using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class YouMayDrawCardsEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new YouMayDrawCardsEffect(1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new YouMayDrawCardsEffect(1);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ControllerMayDrawCards(int amount)
    {
        // Arrange
        var controller = new Mock<IPlayer>();
        var game = Mock.Of<IGame>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var effect = new YouMayDrawCardsEffect(amount)
        {
            Ability = ability.Object
        };

        // Act
        effect.Apply(game);

        // Assert
        controller.Verify(x => x.DrawCardsOptionally(
            game, ability.Object, amount));
    }
}
