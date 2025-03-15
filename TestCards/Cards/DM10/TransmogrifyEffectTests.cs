using Cards.Cards.DM10;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.Cards.DM10;

public class TransmogrifyEffectTests
{
    [Fact]
    public void NothingHappensWhenPlayerDoesNotDestroyAnyCreature()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var player = new Mock<IPlayer>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(player.Object);
        player.Setup(x => x.DestroyCreatureOptionally(game, ability.Object))
            .Returns((ICard)null);
        var effect = new TransmogrifyEffect { Ability = ability.Object };

        // Act + Assert
        effect.Apply(game);
    }

    [Fact]
    public void PlayerRevealsCardsFromTheTopOfHisDeckWhenHeDestroysOneOfHisCreatures()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var player = new Mock<IPlayer>();
        var destroyedCreature = new Mock<ICard>();
        destroyedCreature.SetupGet(x => x.Owner).Returns(player.Object);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(player.Object);
        player.Setup(x => x.DestroyCreatureOptionally(game, ability.Object))
            .Returns(destroyedCreature.Object);
        var effect = new TransmogrifyEffect { Ability = ability.Object };

        // Act
        effect.Apply(game);

        // Assert
        player.Verify(x => x.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(
            game, It.IsAny<IAbility>()), Times.Once);
    }
}
