using Interfaces;
using Interfaces.Zones;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class CardMovingAreaOfEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CardMovingAreaOfEffect(
            source: ZoneType.Hand,
            destination: ZoneType.ManaZone,
            filter.Object,
            selectionRange: SelectionRange.OwnCards);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void HashCodesAreEqualForEqualEffects()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CardMovingAreaOfEffect(
            source: ZoneType.Hand,
            destination: ZoneType.ManaZone,
            filter.Object,
            selectionRange: SelectionRange.OwnCards);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AllCardsAreMoved()
    {
        // Arrange
        const ZoneType source = ZoneType.ManaZone;
        const ZoneType destination = ZoneType.Hand;
        var filter = Mock.Of<ICardFilter>();
        var ability = Mock.Of<IAbility>();
        List<ICard> ownCards = [Mock.Of<ICard>()];
        List<ICard> opponentsCards = [Mock.Of<ICard>()];
        var opponent = new Mock<IPlayerV2>();
        opponent.Setup(x => x.ManaZone.GetCards(filter)).Returns(
            opponentsCards);
        var applier = new Mock<IPlayerV2>();
        applier.Setup(x => x.ManaZone.GetCards(filter)).Returns(
            ownCards);
        applier.SetupGet(x => x.Opponent).Returns(opponent.Object);
        var effect = new CardMovingAreaOfEffect(
            source,
            destination,
            filter,
            selectionRange: SelectionRange.AllCards)
        {
            Ability = ability,
            Applier = applier.Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(
            ability,
            source,
            destination,
            ownCards.Union(opponentsCards).ToArray()));
    }

    [Fact]
    public void AllCreaturesAreDestroyed()
    {
        // Arrange
        const ZoneType source = ZoneType.BattleZone;
        const ZoneType destination = ZoneType.Graveyard;
        var filter = Mock.Of<ICardFilter>();
        var ability = Mock.Of<IAbility>();
        List<ICreature> ownCreatures = [Mock.Of<ICreature>()];
        List<ICreature> opponentsCreatures = [Mock.Of<ICreature>()];
        var opponent = new Mock<IPlayerV2>();
        var applier = new Mock<IPlayerV2>();
        applier.SetupGet(x => x.Opponent).Returns(opponent.Object);
        var effect = new CardMovingAreaOfEffect(
            source,
            destination,
            filter,
            selectionRange: SelectionRange.AllCards)
        {
            Ability = ability,
            Applier = applier.Object
        };
        var battleZone = new Mock<IBattleZone>();
        battleZone.Setup(x => x.GetCreaturesControlledByPlayer(
            applier.Object, filter)).Returns(ownCreatures);
        battleZone.Setup(x => x.GetCreaturesControlledByPlayer(
            opponent.Object, filter)).Returns(opponentsCreatures);
        var game = new Mock<IGame>();
        game.SetupGet(x => x.BattleZone).Returns(battleZone.Object);

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(
            ability,
            source,
            destination,
            ownCreatures.Union(opponentsCreatures).OfType<ICard>().ToArray()));
    }
}