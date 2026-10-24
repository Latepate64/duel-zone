using Interfaces;
using Interfaces.Zones;
using Models;
using Moq;

namespace TestModels;

public class DestroyEventResolverTests
{
    [Fact]
    public void CreatureIsDestroyed()
    {
        // Arrange
        var resolver = new DestroyEventResolver();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Graveyard).Returns(Mock.Of<IGraveyard>());
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(player.Object);
        var gameEvent = new DestroyEvent(creature.Object);
        var state = new Mock<IGameState>();
        state.SetupGet(x => x.BattleZone).Returns(Mock.Of<IBattleZone>());
        state.Setup(x => x.BattleZone.Remove(creature.Object)).Returns([creature.Object]);

        // Act
        resolver.Resolve(state.Object, player.Object, gameEvent);

        // Assert
        state.Verify(x => x.BattleZone.Remove(creature.Object));
        player.Verify(x => x.Graveyard.Add(creature.Object));
    }
}