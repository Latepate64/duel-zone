using Abilities.Static;
using Interfaces;
using Moq;

namespace TestAbilities.Static;

public class BlockerAbilityTests
{
    private static IBlockerAbility CreateAbility()
    {
        return (IBlockerAbility)new BlockerAbilityFactory().Create();
    }

    private static IBlockerAbility CreateAbility(ICardFilter filter)
    {
        return (IBlockerAbility)new BlockerAbilityFactory().Create(filter);
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
    public void CopyEqualsOriginalWithFilter()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var ability = CreateAbility(filter.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutBlockerCannotBlock()
    {
        // Arrange
        var ability = CreateAbility();
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
        var ability = CreateAbility();
        ability.Source = blocker;

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
        var ability = CreateAbility(filter.Object);
        ability.Source = blocker;

        // Act
        var actual = ability.CanBlock(blocker, attacker);

        // Assert
        Assert.Equal(attackerMatches, actual);
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
    public void DoesNotEqualAbilityWithoutFilter()
    {
        // Arrange
        var ability = CreateAbility(Mock.Of<ICardFilter>());
        var other = CreateAbility();

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityWithDifferentFilter()
    {
        // Arrange
        var ability = CreateAbility();
        var other = CreateAbility(Mock.Of<ICardFilter>());

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