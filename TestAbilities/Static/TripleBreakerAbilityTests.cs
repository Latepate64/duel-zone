using Abilities.Static;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities.Static;

public class TripleBreakerAbilityTests
{
    private static TripleBreakerAbility CreateAbility()
    {
        return new TripleBreakerAbilityFactory().Create();
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
    public void CreatureWithoutTripleBreakerBreaksOneShield()
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
    public void CreatureWithTripleBreakerBreaksThreeShields()
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var ability = CreateAbility();
        ability.Source = creature;
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(3, actual);
    }
}