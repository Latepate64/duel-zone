using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class AlcadeiasLordOfSpiritsEffectTests
{
    [Fact]
    public void DoesNotApplyToCreature()
    {
        // Arrange
        var effect = new AlcadeiasLordOfSpiritsEffect();
        var creature = Mock.Of<ICreature>();

        // Act
        var actual = effect.Applies(creature);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotApplyToLightSpell()
    {
        // Arrange
        var effect = new AlcadeiasLordOfSpiritsEffect();
        var spell = new Mock<ISpell>();
        spell.Setup(x => x.HasCivilization(Civilization.Light)).Returns(
            true);

        // Act
        var actual = effect.Applies(spell.Object);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void AppliesToNonLightSpell()
    {
        // Arrange
        var effect = new AlcadeiasLordOfSpiritsEffect();
        var spell = new Mock<ISpell>();
        spell.Setup(x => x.HasCivilization(Civilization.Light)).Returns(
            false);

        // Act
        var actual = effect.Applies(spell.Object);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new AlcadeiasLordOfSpiritsEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }
}