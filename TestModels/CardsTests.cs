using Models;

namespace TestModels;

public class CardsTests
{
    [Fact]
    public void CardsWithoutItemsIsEmpty()
    {
        // Arrange
        var cards = new Cards { Items = [] };

        // Act + Assert
        Assert.Empty(cards.Items);
    }
}