using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class ChooseAndMoveCardsEffectResolverTests
{
    [Fact]
    public void ReturnsNoEventsWhenOpponentHasNoChoosableCreatures()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new ChooseAndMoveCardsEffectResolver(game);
        var applier = Mock.Of<IPlayer>();
        var effect = new ChooseAndMoveCardsEffect();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns([]);

        // Act
        var events = resolver.Resolve(state.Object, applier, effect);

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void ReturnsMoveCardEventWhenOpponentHasOneChoosableCreature()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new ChooseAndMoveCardsEffectResolver(game);
        var applier = Mock.Of<IPlayer>();
        var effect = new ChooseAndMoveCardsEffect
        {
            Minimum = 1,
            Maximum = 1,
            SelectionRange = Models.SelectionRange.Opponent
        };
        var creature = Mock.Of<ICreature>();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns([creature]);

        // Act
        var events = resolver.Resolve(state.Object, applier, effect);

        // Assert
        var gameEvent = Assert.Single(events);
        var moveCardEvent = Assert.IsType<MoveCardEvent>(gameEvent);
        Assert.Equal(creature, moveCardEvent.Card);
    }

    [Fact]
    public void ThrowsNotImplementedExceptionWhenOpponentHasMoreCardsThanIsRequiredToChoose()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new ChooseAndMoveCardsEffectResolver(game);
        var applier = Mock.Of<IPlayer>();
        var effect = new ChooseAndMoveCardsEffect
        {
            Minimum = 0,
            Maximum = 1,
            SelectionRange = Models.SelectionRange.Opponent
        };
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns([Mock.Of<ICreature>()]);

        // Act + Assert
        Assert.Throws<NotImplementedException>(
            () => resolver.Resolve(state.Object, applier, effect));
    }
}