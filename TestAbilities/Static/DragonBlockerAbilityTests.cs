using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class DragonBlockerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new DragonBlockerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutDragonBlockerCannotBlock()
    {
        // Arrange
        var ability = new DragonBlockerAbility();
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
    public void CreatureWithDragonBlockerCanBlock(bool attackerIsDragon)
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var ability = new DragonBlockerAbility()
        {
            Source = blocker
        };
        var attacker = new Mock<ICreature>();
        attacker.Setup(x => x.IsDragon).Returns(attackerIsDragon);

        // Act
        var actual = ability.CanBlock(blocker, attacker.Object);

        // Assert
        Assert.Equal(attackerIsDragon, actual);
    }
}