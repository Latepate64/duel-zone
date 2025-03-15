using Cards.Cards.DM10;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.Cards.DM10;

public class TransmogrifyTests
{
    [Fact]
    public void NothingHappensWhenPlayerDoesNotDestroyAnyCreature()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var player = new Mock<IPlayer>();
        var transmogrify = SetupTransmogrify(game, player, null);

        // Act + Assert
        transmogrify.Resolve(game);
    }

    [Fact]
    public void PlayerRevealsCardsFromTheTopOfHisDeckWhenHeDestroysOneOfHisCreatures()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var player = new Mock<IPlayer>();
        var creatureToDestroy = new Mock<ICard>();
        creatureToDestroy.SetupGet(x => x.Owner).Returns(player.Object);
        var transmogrify = SetupTransmogrify(game, player,
            creatureToDestroy.Object);

        // Act
        transmogrify.Resolve(game);

        // Assert
        player.Verify(x => x.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(
            game, It.IsAny<IAbility>()), Times.Once);
    }

    static Transmogrify SetupTransmogrify(IGame game, Mock<IPlayer> player,
        ICard creatureToDestroy)
    {
        var transmogrify = new Transmogrify();
        var ability = transmogrify.PrintedAbilities[0] as ResolvableAbility;
        ability.Controller = player.Object;
        player.Setup(x => x.DestroyCreatureOptionally(game, ability))
            .Returns(creatureToDestroy);
        return transmogrify;
    }
}
