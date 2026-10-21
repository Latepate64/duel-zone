using ContinuousEffects.Evolution;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.Evolution;

public class VortexEvolutionEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter1 = new Mock<ICardFilter>();
        filter1.Setup(x => x.Copy()).Returns(filter1.Object);
        var filter2 = new Mock<ICardFilter>();
        filter2.Setup(x => x.Copy()).Returns(filter2.Object);
        var effect = new VortexEvolutionEffect(filter1.Object, filter2.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CanEvolveWhenBothFiltersFilterDistinctCreature()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var creature1 = new Mock<ICreature>();
        creature1.SetupGet(x => x.OwnerV2).Returns(player);
        var creature2 = new Mock<ICreature>();
        creature2.SetupGet(x => x.OwnerV2).Returns(player);
        var filter1 = Mock.Of<ICardFilter>();
        var filter2 = Mock.Of<ICardFilter>();
        var evolutionCreature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(evolutionCreature);
        var effect = new VortexEvolutionEffect(filter1, filter2)
        {
            Ability = ability.Object,
            Applier = player
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(player, filter1)).Returns(
            [creature1.Object]);
        game.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(player, filter2)).Returns(
            [creature2.Object]);

        // Act
        var actual = effect.CanEvolve(game.Object, evolutionCreature);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void CannotEvolveWhenBothFiltersFilterSameCreature()
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(player);
        var filter1 = Mock.Of<ICardFilter>();
        var filter2 = Mock.Of<ICardFilter>();
        var evolutionCreature = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(evolutionCreature);
        var effect = new VortexEvolutionEffect(filter1, filter2)
        {
            Ability = ability.Object,
            Applier = player
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(player, filter1)).Returns(
            [creature.Object]);
        game.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(player, filter2)).Returns(
            [creature.Object]);

        // Act
        var actual = effect.CanEvolve(game.Object, evolutionCreature);

        // Assert
        Assert.False(actual);
    }
}