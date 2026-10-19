using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class LookEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new LookEffect(0, 1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new LookEffect(0, 1);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    public void ControllerLooksAtShields(int minimum, int maximum)
    {
        // Arrange
        ICard[] shields = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        var controller = new Mock<IPlayer>();
        controller.Setup(x => x.ChooseCards(
            shields, minimum, maximum, It.IsAny<string>())).Returns(shields);
        var revealer = new Mock<IPlayer>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var applier = new Mock<IPlayerV2>();
        applier.Setup(x => x.Opponent.ShieldZone.Cards).Returns(shields);
        var effect = new LookEffect(minimum, maximum)
        {
            Ability = ability.Object,
            Applier = applier.Object
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.GetOwner(shields.First())).Returns(revealer.Object);

        // Act
        effect.Apply(game.Object);

        // Assert
        controller.Verify(x => x.Look(revealer.Object, game.Object, shields));
    }
}