using Abilities;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities;

public class TripleBreakerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new TripleBreakerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutTripleBreakerBreaksOneShield()
    {
        // Arrange
        var ability = new TripleBreakerAbility();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CreatureWithTripleBreakerBreaksThreeShields()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = new TripleBreakerAbility
        {
            Source = creature
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(3, actual);
    }
}