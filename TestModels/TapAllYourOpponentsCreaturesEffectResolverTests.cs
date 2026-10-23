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
        var applier = Mock.Of<IPlayerV2>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(false);
        var effect = new TapAllYourOpponentsCreaturesEffect();
        var state = new Mock<IGameState>();
        state.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(
            applier, effect.Item)).Returns([creature.Object]);

        // Act
        var effects = resolver.Resolve(state.Object, applier, effect);

        // Assert
        var actual = Assert.Single(effects);
        var tapCardEffect = Assert.IsType<TapCardEvent>(actual);
        Assert.Equal(creature.Object, tapCardEffect.Card);
    }
}
