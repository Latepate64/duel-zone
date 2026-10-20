using ContinuousEffects.CostModifying;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CostModifying;

public class CardsCostMoreEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new CardsCostMoreEffect(filter.Object, 1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(1, true, 1)]
    [InlineData(2, true, 2)]
    [InlineData(1, false, 0)]
    public void GetChange(int increase, bool match, int expectedIncrease)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var card = Mock.Of<ICard>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(card)).Returns(match);
        var effect = new CardsCostMoreEffect(filter.Object, increase)
        {
            Applier = player
        };
        var game = Mock.Of<IGame>();

        // Act
        var actualReduction = effect.GetChange(card, game);

        // Assert
        Assert.Equal(expectedIncrease, actualReduction);
    }
}