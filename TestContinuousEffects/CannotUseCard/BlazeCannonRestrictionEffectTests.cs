using ContinuousEffects.CannotUseCard;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotUseCard;

public class BlazeCannonRestrictionEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new BlazeCannonRestrictionEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void DoesNotApplyToOtherCards()
    {
        // Arrange
        var effect = new BlazeCannonRestrictionEffect();

        // Act
        var actual = effect.Applies(Mock.Of<ICard>());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AppliesBasedOnWhetherAllTheCardsInAppliersManaZoneAreFireCards(
        bool areAllFireCards)
    {
        // Arrange
        var spell = Mock.Of<ISpell>();
        var spellAbility = new Mock<ISpellAbility>();
        spellAbility.SetupGet(x => x.Source).Returns(spell);
        var applier = new Mock<IPlayerV2>();
        applier.Setup(x => x.ManaZone.AreAllCivilizationCards(
            Civilization.Fire)).Returns(areAllFireCards);
        var effect = new BlazeCannonRestrictionEffect
        {
            Ability = spellAbility.Object,
            Applier = applier.Object
        };

        // Act
        var actual = effect.Applies(spell);

        // Assert
        Assert.Equal(!areAllFireCards, actual);
    }
}