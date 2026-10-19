using Interfaces;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class ShieldRecoveryEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ShieldRecoveryEffect(
            minimum: 1,
            maximum: 1,
            controllerChooses: true,
            canUseShieldTrigger: false);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var effect = new ShieldRecoveryEffect(
            minimum: 1,
            maximum: 1,
            controllerChooses: true,
            canUseShieldTrigger: false);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 1, true)]
    [InlineData(1, 2, false)]
    public void ControllerMayDrawCards(
        int minimum,
        int maximum,
        bool canUseShieldTrigger)
    {
        // Arrange
        ICard[] cards = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        var controller = new Mock<IPlayer>();
        controller.SetupGet(x => x.ShieldZone.Cards).Returns(cards);
        controller.Setup(x => x.ChooseCards(
            cards, minimum, maximum, It.IsAny<string>())).Returns(cards);
        var game = new Mock<IGame>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var effect = new ShieldRecoveryEffect(
            minimum,
            maximum,
            controllerChooses: true,
            canUseShieldTrigger)
        {
            Ability = ability.Object
        };

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.PutFromShieldZoneToHand(
            cards, canUseShieldTrigger, ability.Object));
    }
}
