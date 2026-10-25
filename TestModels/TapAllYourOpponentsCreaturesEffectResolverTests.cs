using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class TapAllYourOpponentsCreaturesEffectResolverTests
{
    [Fact]
    public void TapCardEffectIsCreated()
    {
        // Arrange
        var resolver = new TapAllYourOpponentsCreaturesEffectResolver();
        var applier = Mock.Of<IPlayer>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(false);
        var effect = new TapAllYourOpponentsCreaturesEffect();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(
            applier, effect.CardFilter)).Returns([creature.Object]);

        // Act
        var events = resolver.Resolve(state.Object, applier, effect);

        // Assert
        var gameEvent = Assert.Single(events);
        var tapCardEvent = Assert.IsType<TapCardEvent>(gameEvent);
        Assert.Equal(creature.Object, tapCardEvent.Card);
    }
}
