using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class TapAllYourOpponentsCreaturesEffectResolverTests
{
    [Fact]
    public void OpponentsCreatureGetsTapped()
    {
        // Arrange
        var filter = Mock.Of<ICardFilter>();
        var resolver = new TapAllYourOpponentsCreaturesEffectResolver(filter);
        var state = new Mock<IGameState>();
        var applier = Mock.Of<IPlayerV2>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(false);
        state.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(applier, filter)).Returns(
            [creature.Object]);
        var effect = new TapAllYourOpponentsCreaturesEffect();

        // Act
        var effects = resolver.Resolve(state.Object, applier, effect);

        // Assert
        var actual = Assert.Single(effects);
        var tapCardEffect = Assert.IsType<TapCardEffect>(actual);
        Assert.Equal(creature.Object, tapCardEffect.Card);
    }
}
