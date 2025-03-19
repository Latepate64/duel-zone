using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.OneShotEffects;

public class AddCardFromYourHandToYourShieldsFaceDownEffectTests
{
    [Fact]
    public void MovesCardsFromHandToShieldsFaceDown()
    {
        // Arrange
        var effect = new AddCardFromYourHandToYourShieldsFaceDownEffect();
        var ability = Mock.Of<IAbility>();
        var player = new Mock<IPlayer>();
        player.SetupGet(x => x.Hand.Cards).Returns([]);
        ability.Controller = player.Object;
        effect.Ability = ability;
        var game = new Mock<IGame>();

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(ability, ZoneType.Hand, ZoneType.ShieldZone),
            Times.Once);
    }
}