using ContinuousEffects.Unblockable;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class CreaturesCannotBeBlockedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var attackerFilter = new Mock<ICardFilter>();
        attackerFilter.Setup(x => x.Copy()).Returns(attackerFilter.Object);
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Copy()).Returns(blockerFilter.Object);
        var effect = new CreaturesCannotBeBlockedEffect(
            attackerFilter.Object, blockerFilter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }
}