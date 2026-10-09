using Abilities.Static;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities;

public class DoubleBreakerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new DoubleBreakerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutDoubleBreakerBreaksOneShield()
    {
        // Arrange
        var ability = new DoubleBreakerAbility();
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Fact]
    public void CreatureWithDoubleBreakerBreaksTwoShields()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = new DoubleBreakerAbility { Source = creature };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(2, actual);
    }
}