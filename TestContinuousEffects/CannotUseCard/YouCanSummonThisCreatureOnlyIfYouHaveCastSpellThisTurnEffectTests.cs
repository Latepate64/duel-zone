using System;
using ContinuousEffects.CannotUseCard;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotUseCard;

public class YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect =
            new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void AppliesNotImplemented()
    {
        // Arrange
        var effect =
            new YouCanSummonThisCreatureOnlyIfYouHaveCastSpellThisTurnEffect();

        // Act + Assert
        _ = Assert.Throws<NotImplementedException>(() => effect.Applies(
            Mock.Of<ICard>()));
    }
}