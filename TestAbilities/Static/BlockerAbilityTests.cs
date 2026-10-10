using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class BlockerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginalWithoutFilter()
    {
        // Arrange
        var ability = new BlockerAbility();

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
        var ability = new BlockerAbility(filter.Object);
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
        var attacker = Mock.Of<ICreature>();
        var ability = new BlockerAbility { Source = blocker };

        // Act
        var actual = ability.CanBlock(blocker, attacker);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CreatureWithBlockerCanBlockIfFilterMatches(bool attackerMatches)
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var attacker = Mock.Of<ICreature>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(attacker)).Returns(attackerMatches);
        var ability = new BlockerAbility(filter.Object) { Source = blocker };

        // Act
        var actual = ability.CanBlock(blocker, attacker);

        // Assert
        Assert.Equal(attackerMatches, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var ability = new BlockerAbility();

        // Act
        var actual = ability.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityOfAnotherType()
    {
        // Arrange
        var ability = new BlockerAbility();
        var other = new SlayerAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithoutFilter()
    {
        // Arrange
        var ability = new BlockerAbility(Mock.Of<ICardFilter>());
        var other = new BlockerAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentFilter()
    {
        // Arrange
        var ability = new BlockerAbility();
        var other = new BlockerAbility(Mock.Of<ICardFilter>());

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var ability = new BlockerAbility();
        var another = ability.Copy();

        // Act
        var first = ability.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}