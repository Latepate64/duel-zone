using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

public class SparkleFlowerEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new SparkleFlowerEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureWithBlockerCanBlockWhileAllTheCardsInItsControllersManaZoneAreLightCards(
        bool expected)
    {
        // Arrange
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.ManaZone.AreAllCivilizationCards(
            Civilization.Light)).Returns(expected);
        var source = new Mock<ICreature>();
        source.SetupGet(x => x.OwnerV2).Returns(player.Object);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source.Object);
        var effect = new SparkleFlowerEffect
        {
            Ability = ability.Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(
            x => x.AddAbility(source.Object, It.IsAny<BlockerAbility>()),
            expected ? Times.Once : Times.Never);
    }
}