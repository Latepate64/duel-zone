using ContinuousEffects.AbilityAdding;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AbilityAdding;

public class ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(
            Civilization.Light, Mock.Of<IAbility>()
        );

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureGetsAbilityWhileAllTheCardsInItsControllersManaZoneAreCivilizationCards(
        bool expected)
    {
        // Arrange
        const Civilization civilization = Civilization.Light;
        var player = new Mock<IPlayerV2>();
        player.Setup(x => x.ManaZone.AreAllCivilizationCards(civilization)).Returns(expected);
        var source = new Mock<ICreature>();
        source.SetupGet(x => x.OwnerV2).Returns(player.Object);
        var sourceAbility = new Mock<IAbility>();
        sourceAbility.SetupGet(x => x.Source).Returns(source.Object);
        var abilityToAdd = Mock.Of<IAbility>();
        var effect = new ThisCreatureHasAbilityWhileYourManaCardsAreCivilizationEffect(
            civilization, abilityToAdd)
        {
            Ability = sourceAbility.Object
        };
        var game = new Mock<IGame>();

        // Act
        effect.AddAbility(game.Object);

        // Assert
        game.Verify(
            x => x.AddAbility(source.Object, abilityToAdd),
            expected ? Times.Once : Times.Never);
    }
}