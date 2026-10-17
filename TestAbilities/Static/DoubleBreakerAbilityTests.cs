using Abilities.Static;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities.Static;

public class DoubleBreakerAbilityTests
{
    private static IBreakerAbility CreateAbility()
    {
        return (IBreakerAbility)new DoubleBreakerAbilityFactory().Create();
    }

    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = CreateAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutDoubleBreakerBreaksOneShield()
    {
        // Arrange
        var ability = CreateAbility();
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
        var ability = CreateAbility();
        ability.Source = creature;
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(2, actual);
    }
}