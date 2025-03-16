using Engine;
using Engine.Choices;
using Moq;
using Xunit;

namespace TestEngine;

public class PlayerTests
{
    [Fact]
    public void ArrangeTopCardsOfDeck()
    {
        // Arrange
        var player = new Mock<Player>();
        var choice = new ArrangeChoice(player.Object, [])
        {
            Rearranged = []
        };
        player.Setup(x => x.ChooseAbstractly(It.IsAny<ArrangeChoice>()))
            .Returns(choice);

        // Act
        player.Object.ArrangeTopCardsOfDeck();
    }
}
