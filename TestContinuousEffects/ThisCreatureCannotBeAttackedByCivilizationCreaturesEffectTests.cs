using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class ThisCreatureCannotBeAttackedByCivilizationCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect =
            new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void DoesNotApplyToOtherCreatures()
    {
        // Arrange
        var effect =
            new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect();
        var targetOfAttack = Mock.Of<ICreature>();

        // Act
        var actual = effect.Applies(attacker: null, targetOfAttack);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesWhenTheAttackingCreatureHasSpecificCivilization(
        bool hasCivilization)
    {
        // Arrange
        var attacker = new Mock<ICreature>();
        var civilization = Civilization.Light;
        attacker.Setup(x => x.HasCivilization(civilization)).Returns(
            hasCivilization);
        var targetOfAttack = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(targetOfAttack);
        var effect =
            new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(
                civilization)
        {
            Ability = ability.Object
        };

        // Act
        var actual = effect.Applies(attacker.Object, targetOfAttack);

        // Assert
        Assert.Equal(hasCivilization, actual);
    }
}