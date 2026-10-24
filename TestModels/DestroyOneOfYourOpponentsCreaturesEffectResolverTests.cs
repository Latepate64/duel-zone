using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class DestroyOneOfYourOpponentsCreaturesEffectResolverTests
{
    [Fact]
    public void ReturnsNoEventsWhenOpponentHasNoChoosableCreatures()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new DestroyOneOfYourOpponentsCreaturesEffectResolver(game);
        var applier = Mock.Of<IPlayerV2>();
        var effect = new DestroyOneOfYourOpponentsCreaturesEffect();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns([]);

        // Act
        var events = resolver.Resolve(state.Object, applier, effect);

        // Assert
        Assert.Empty(events);
    }

    [Fact]
    public void ReturnsDestroyEventWhenOpponentHasOneChoosableCreature()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new DestroyOneOfYourOpponentsCreaturesEffectResolver(game);
        var applier = Mock.Of<IPlayerV2>();
        var effect = new DestroyOneOfYourOpponentsCreaturesEffect();
        var creature = Mock.Of<ICreature>();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns([creature]);

        // Act
        var events = resolver.Resolve(state.Object, applier, effect);

        // Assert
        var gameEvent = Assert.Single(events);
        var destroyEvent = Assert.IsType<DestroyEvent>(gameEvent);
        Assert.Equal(creature, destroyEvent.Creature);
    }

    [Fact]
    public void ThrowsNotImplementedExceptionWhenOpponentHasMultipleChoosableCreatures()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var resolver = new DestroyOneOfYourOpponentsCreaturesEffectResolver(game);
        var applier = Mock.Of<IPlayerV2>();
        var effect = new DestroyOneOfYourOpponentsCreaturesEffect();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetOpponentsChoosableCreatures(
            applier, effect.CardFilter, game)).Returns(
                [Mock.Of<ICreature>(), Mock.Of<ICreature>()]);

        // Act + Assert
        Assert.Throws<NotImplementedException>(
            () => resolver.Resolve(state.Object, applier, effect));
    }
}