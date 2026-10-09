using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class CivilizationBlockerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new CivilizationBlockerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutCivilizationBlockerCannotBlock()
    {
        // Arrange
        var ability = new CivilizationBlockerAbility();
        var creatureWithoutBlocker = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();

        // Act
        var actual = ability.CanBlock(creatureWithoutBlocker, attacker);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureWithCivilizationBlockerCanBlock(
        bool attackerHasTargetCivilization)
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var ability = new CivilizationBlockerAbility(Civilization.Light)
        {
            Source = blocker
        };
        var attacker = new Mock<ICreature>();
        attacker.Setup(x => x.HasCivilization(Civilization.Light)).Returns(
            attackerHasTargetCivilization);

        // Act
        var actual = ability.CanBlock(blocker, attacker.Object);

        // Assert
        Assert.Equal(attackerHasTargetCivilization, actual);
    }
}