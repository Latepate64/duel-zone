using ContinuousEffects.CostModifying;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CostModifying;

public class CardsCostLessEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CardsCostLessEffect(filter.Object, 1, 1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(1, 2, true, -1, 2)]
    [InlineData(2, 1, true, -2, 1)]
    [InlineData(3, 3, false, 0, 0)]
    public void GetChangeAndMinimumCost(
        int reduction, int minimumCost, bool match, int expectedReduction, int expectedMinimumCost)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(card)).Returns(match);
        var effect = new CardsCostLessEffect(filter.Object, reduction, minimumCost)
        {
            Applier = player
        };
        var game = Mock.Of<IGame>();

        // Act
        var actualReduction = effect.GetChange(card, game);
        var actualMinimumCost = effect.GetMinimumCost(card, game);

        // Assert
        Assert.Equal(expectedReduction, actualReduction);
        Assert.Equal(expectedMinimumCost, actualMinimumCost);
    }
}