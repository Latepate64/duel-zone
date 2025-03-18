using Cards.Cards.DM07;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.Cards.DM07;

public class BexTheOracleEffectTests
{
    [Fact]
    public void AddsBlockerAbilityToSourceWhileItsOwnerHasNoShields()
    {
        // Arrange
        var card = new Mock<ICard>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(card.Object);
        ability.SetupGet(x => x.Source.Owner.ShieldZone.HasCards)
            .Returns(false);
        var effect = new BexTheOracleEffect
        {
            Ability = ability.Object
        };
        var game = Mock.Of<IGame>();

        // Act
        effect.AddAbility(game);

        // Assert
        card.Verify(x => x.AddGrantedAbility(It.IsAny<BlockerAbility>()),
            Times.Once);
    }

    [Fact]
    public void Copy()
    {
        var effect = new BexTheOracleEffect();
        Assert.Equal(effect, effect.Copy());
    }
}
