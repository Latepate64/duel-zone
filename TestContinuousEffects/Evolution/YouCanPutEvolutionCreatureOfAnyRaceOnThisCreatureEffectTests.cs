using ContinuousEffects.Evolution;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.Evolution;

public class YouCanPutEvolutionCreatureOfAnyRaceOnThisCreatureEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new YouCanPutEvolutionCreatureOfAnyRaceOnThisCreatureEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CanEvolve()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var evolutionCreature = new Mock<ICreature>();
        evolutionCreature.SetupGet(x => x.OwnerV2).Returns(player);
        var effect = new YouCanPutEvolutionCreatureOfAnyRaceOnThisCreatureEffect
        {
            Applier = player
        };
        var game = Mock.Of<IGame>();

        // Act
        var actual = effect.CanEvolve(game, evolutionCreature.Object);

        // Assert
        Assert.True(actual);
    }
}