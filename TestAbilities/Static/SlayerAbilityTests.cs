using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class SlayerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginalWithoutFilter()
    {
        // Arrange
        var ability = new SlayerAbility();

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CopyEqualsOriginalWithFilter()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var ability = new SlayerAbility(filter.Object);
        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutSlayerCannotBlock()
    {
        // Arrange
        var ability = new SlayerAbility();
        var creatureWithoutSlayer = Mock.Of<ICreature>();
        var defendingCreature = Mock.Of<ICreature>();

        // Act
        var actual = ability.Applies(creatureWithoutSlayer, defendingCreature);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Applies()
    {
        // Arrange
        var slayer = Mock.Of<ICreature>();
        var defendingCreature = Mock.Of<ICreature>();
        var ability = new SlayerAbility { Source = slayer };

        // Act
        var actual = ability.Applies(slayer, defendingCreature);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesWhenFilterMatches(bool attackerMatches)
    {
        // Arrange
        var slayer = Mock.Of<ICreature>();
        var defendingCreature = Mock.Of<ICreature>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(defendingCreature)).Returns(attackerMatches);
        var ability = new SlayerAbility(filter.Object) { Source = slayer };

        // Act
        var actual = ability.Applies(slayer, defendingCreature);

        // Assert
        Assert.Equal(attackerMatches, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var ability = new SlayerAbility();

        // Act
        var actual = ability.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityOfAnotherType()
    {
        // Arrange
        var ability = new SlayerAbility();
        var other = new BlockerAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithoutFilter()
    {
        // Arrange
        var ability = new SlayerAbility(Mock.Of<ICardFilter>());
        var other = new SlayerAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentFilter()
    {
        // Arrange
        var ability = new SlayerAbility();
        var other = new SlayerAbility(Mock.Of<ICardFilter>());

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var ability = new SlayerAbility();
        var another = ability.Copy();

        // Act
        var first = ability.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}