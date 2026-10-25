using Interfaces;
using Interfaces.Zones;
using Models;
using Moq;

namespace TestModels;

public class MoveCardEventResolverTests
{
    [Fact]
    public void CreatureIsDestroyed()
    {
        // Arrange
        var resolver = new MoveCardEventResolver();
        var player = new Mock<IPlayer>();
        player.SetupGet(x => x.Graveyard).Returns(Mock.Of<IGraveyard>());
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(player.Object);
        var gameEvent = new MoveCardEvent(
            creature.Object, Models.ZoneType.Battlezone, Models.ZoneType.Graveyard);
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