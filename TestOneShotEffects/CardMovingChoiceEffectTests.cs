using Interfaces;
using Interfaces.Zones;
using Moq;
using OneShotEffects;

namespace TestOneShotEffects;

public class CardMovingChoiceEffectTests
{
    const int minimum = 0;
    const int maximum = 1;

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CardMovingChoiceEffect(
            minimum,
            maximum,
            controllerChooses: true,
            filter.Object,
            source: ZoneType.Hand,
            destination: ZoneType.ManaZone,
            selectionRange: SelectionRange.OwnCreatures);

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
        var effect = new CardMovingChoiceEffect(
            minimum,
            maximum,
            controllerChooses: true,
            filter.Object,
            source: ZoneType.Hand,
            destination: ZoneType.ManaZone,
            selectionRange: SelectionRange.OwnCreatures);
        var copy = effect.Copy();
        var expected = copy.GetHashCode();

        // Act
        var actual = effect.GetHashCode();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Theory]
    [InlineData(false, SelectionRange.OpponentsCreatures)]
    [InlineData(false, SelectionRange.OwnCreatures)]
    [InlineData(true, SelectionRange.OpponentsCreatures)]
    [InlineData(true, SelectionRange.OwnCreatures)]
    public void MoveCardsFromHandIntoManaZone(
        bool controllerChooses, SelectionRange selectionRange)
    {
        // Arrange
        var filter = Mock.Of<ICardFilter>();
        ICard[] cards = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        var hand = new Mock<IHand>();
        hand.Setup(x => x.GetCards(filter)).Returns(cards);
        var opponent = new Mock<IPlayerV2>();
        opponent.SetupGet(x => x.Hand).Returns(hand.Object);
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Hand).Returns(hand.Object);
        player.SetupGet(x => x.Opponent).Returns(opponent.Object);
        var controller = new Mock<IPlayer>();
        controller.Setup(x => x.ChooseCards(
            cards, minimum, maximum, It.IsAny<string>())).Returns(cards);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var source = ZoneType.Hand;
        var destination = ZoneType.ManaZone;
        var effect = new CardMovingChoiceEffect(
            minimum,
            maximum,
            controllerChooses,
            filter,
            source,
            destination,
            selectionRange)
        {
            Applier = player.Object,
            Ability = ability.Object
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.GetOpponent(controller.Object)).Returns(
            controller.Object);

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(
            ability.Object, source, destination, cards));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void MoveCardsFromBattleZoneIntoGraveyard(bool controllerChooses)
    {
        // Arrange
        const SelectionRange selectionRange = SelectionRange.OwnCreatures;
        var filter = Mock.Of<ICardFilter>();
        ICreature[] creatures = [Mock.Of<ICreature>(), Mock.Of<ICreature>()];
        var battleZone = new Mock<IBattleZone>();
        var game = new Mock<IGame>();
        game.SetupGet(x => x.BattleZone).Returns(battleZone.Object);
        var opponent = new Mock<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent.Object);
        battleZone.Setup(x => x.GetChoosableCreatures(
            controllerChooses ? player.Object : opponent.Object,
            filter,
            game.Object,
            selectionRange)).Returns(
                creatures);
        var controller = new Mock<IPlayer>();
        ICard[] cards = [Mock.Of<ICard>(), Mock.Of<ICard>()];
        controller.Setup(x => x.ChooseCards(
            It.IsAny<IEnumerable<ICard>>(),
            minimum, maximum, It.IsAny<string>())).Returns(
                cards);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Controller).Returns(controller.Object);
        var source = ZoneType.BattleZone;
        var destination = ZoneType.Graveyard;
        var effect = new CardMovingChoiceEffect(
            minimum,
            maximum,
            controllerChooses,
            filter,
            source,
            destination,
            selectionRange)
        {
            Applier = player.Object,
            Ability = ability.Object
        };
        game.Setup(x => x.GetOpponent(controller.Object)).Returns(
            controller.Object);

        // Act
        effect.Apply(game.Object);

        // Assert
        game.Verify(x => x.Move(
            ability.Object, source, destination, cards));
    }
}
