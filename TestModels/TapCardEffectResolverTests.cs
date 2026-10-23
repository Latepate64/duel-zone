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
        var effect = new TapCardEvent(card.Object);

        // Act
        resolver.Resolve(Mock.Of<IGameState>(), Mock.Of<IPlayerV2>(), effect);

        // Assert
        card.VerifySet(x => x.Tapped = true);
    }
}