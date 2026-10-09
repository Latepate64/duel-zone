using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class CivilizationSlayerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new CivilizationSlayerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void DoesNotApplyToCreatureWithoutCivilizationSlayer()
    {
        // Arrange
        var ability = new CivilizationSlayerAbility(Civilization.Light);
        var creatureWithoutSlayer = Mock.Of<ICreature>();
        var against = Mock.Of<ICreature>();

        // Act
        var actual = ability.Applies(creatureWithoutSlayer, against);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesToCreatureWithCivilizationSlayer(
        bool otherCreatureHasTargetCivilization)
    {
        // Arrange
        var slayer = Mock.Of<ICreature>();
        var ability = new CivilizationSlayerAbility(
            Civilization.Light) { Source = slayer };
        var against = new Mock<ICreature>();
        against.Setup(x => x.HasCivilization(Civilization.Light)).Returns(
            otherCreatureHasTargetCivilization);

        // Act
        var actual = ability.Applies(slayer, against.Object);

        // Assert
        Assert.Equal(otherCreatureHasTargetCivilization, actual);
    }
}