using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class BlockerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new BlockerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutBlockerCannotBlock()
    {
        // Arrange
        var ability = new BlockerAbility();
        var creatureWithoutBlocker = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();

        // Act
        var actual = ability.CanBlock(creatureWithoutBlocker, attacker);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void CreatureWithBlockerCanBlock()
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var ability = new BlockerAbility { Source = blocker };
        var attacker = Mock.Of<ICreature>();

        // Act
        var actual = ability.CanBlock(blocker, attacker);

        // Assert
        Assert.True(actual);
    }
}