using StaticAbilities;
using Interfaces;
using Moq;

namespace TestStaticAbilities;

public class SlayerAbilityTests
{
    private static SlayerAbility CreateAbility()
    {
        return new SlayerAbilityFactory().Create();
    }


    private static SlayerAbility CreateAbility(ICardFilter filter)
    {
        return new SlayerAbilityFactory().Create(filter);
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
    public void CreatureWithoutSlayerCannotBlock()
    {
        // Arrange
        var ability = CreateAbility();
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
        var ability = CreateAbility();
        ability.Source = slayer;

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
        var ability = CreateAbility(filter.Object);
        ability.Source = slayer;

        // Act
        var actual = ability.Applies(slayer, defendingCreature);

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