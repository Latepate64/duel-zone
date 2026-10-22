using ContinuousEffects.CostModifying;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CostModifying;

public class YourCardsCostLessEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new YourCardsCostLessEffect(filter.Object, 1, 1);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void DoesNotAffectOpponentsCards()
    {
        // Arrange
        var opponent = Mock.Of<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent);
        var card = new Mock<ICard>();
        card.SetupGet(x => x.OwnerV2).Returns(opponent);
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(card.Object)).Returns(true);
        var effect = new YourCardsCostLessEffect(filter.Object, reduction: 1, minimumCost: 1)
        {
            Applier = player.Object
        };
        var game = Mock.Of<IGame>();

        // Act
        var actualReduction = effect.GetChange(card.Object, game);
        var actualMinimumCost = effect.GetMinimumCost(card.Object, game);

        // Assert
        Assert.Equal(0, actualReduction);
        Assert.Equal(0, actualMinimumCost);
    }
}