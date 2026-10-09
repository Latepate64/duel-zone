using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class SlayerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new SlayerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void DoesNotApplyToCreatureWithoutSlayer()
    {
        // Arrange
        var ability = new SlayerAbility();
        var creatureWithoutSlayer = Mock.Of<ICreature>();
        var against = Mock.Of<ICreature>();

        // Act
        var actual = ability.Applies(creatureWithoutSlayer, against);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void AppliesToCreatureWithSlayer()
    {
        // Arrange
        var slayer = Mock.Of<ICreature>();
        var ability = new SlayerAbility { Source = slayer };
        var against = Mock.Of<ICreature>();

        // Act
        var actual = ability.Applies(slayer, against);

        // Assert
        Assert.True(actual);
    }
}