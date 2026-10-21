using ContinuousEffects.Evolution;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.Evolution;

public class EvolutionEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new EvolutionEffect(filter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanEvolveWhenPlayerHasCreatureToEvolveFrom(bool playerHasCreatureToEvolveFrom)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var filter = Mock.Of<ICardFilter>();
        var evolutionCreature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(evolutionCreature);
        var effect = new EvolutionEffect(filter)
        {
            Ability = ability.Object,
            Applier = player
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.HasCreaturesControllerByPlayer(player, filter)).Returns(
            playerHasCreatureToEvolveFrom);

        // Act
        var actual = effect.CanEvolve(game.Object, evolutionCreature);

        // Assert
        Assert.Equal(playerHasCreatureToEvolveFrom, actual);
    }
}