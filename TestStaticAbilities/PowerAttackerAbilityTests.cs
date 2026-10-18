using StaticAbilities;
using Interfaces;

namespace TestStaticAbilities;

public class PowerAttackerAbilityTests
{
    private static IPowerAttackerAbility CreateAbility(int power = 1000)
    {
        return (IPowerAttackerAbility)new PowerAttackerAbilityFactory().Create(power);
    }

    [Fact]
    public void CopyEqualsOriginalWithoutFilter()
    {
        // Arrange
        var ability = CreateAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var ability = CreateAbility();

        // Act
        var actual = ability.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityOfAnotherType()
    {
        // Arrange
        var ability = CreateAbility();
        var other = new SlayerAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentPowers()
    {
        // Arrange
        var ability = CreateAbility(1000);
        var other = CreateAbility(2000);

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var ability = CreateAbility();
        var another = ability.Copy();

        // Act
        var first = ability.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}