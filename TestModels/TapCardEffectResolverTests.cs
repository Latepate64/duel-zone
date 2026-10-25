using Interfaces;
using Models;
using Moq;

namespace TestModels;

public class TapCardEffectResolverTests
{
    [Fact]
    public void CardGetsTapped()
    {
        // Arrange
        var resolver = new TapCardEventResolver();
        var card = new Mock<ICard>();
        var gameEvent = new TapCardEvent(card.Object);

        // Act
        resolver.Resolve(Mock.Of<IGameState>(), Mock.Of<IPlayer>(), gameEvent);

        // Assert
        card.VerifySet(x => x.Tapped = true);
    }
}
