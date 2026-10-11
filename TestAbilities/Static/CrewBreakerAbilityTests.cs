using Abilities.Static;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities.Static;

public class CrewBreakerAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var ability = new CrewBreakerAbility(filter.Object);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void GetAmountReturnsOneForCreatureWithoutCrewBreaker()
    {
        // Arrange
        var ability = new CrewBreakerAbility(Mock.Of<ICardFilter>());
        var creature = Mock.Of<ICreature>();

        // Act
        var actual = ability.GetAmount(creature, Mock.Of<IBattleZone>());

        // Assert
        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    public void GetAmountReturnsBasedOnFilterMatching(
        int numberOfOtherCreatures, int expected)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var filter = Mock.Of<ICardFilter>();
        var battleZone = new Mock<IBattleZone>();
        battleZone.Setup(x => x.GetNumberOfOtherCreaturesControllerByPlayer(
            creature, filter)).Returns(numberOfOtherCreatures);
        var ability = new CrewBreakerAbility(filter) { Source = creature };

        // Act
        var actual = ability.GetAmount(creature, battleZone.Object);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var ability = new CrewBreakerAbility(Mock.Of<ICardFilter>());

        // Act
        var actual = ability.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualAbilityOfAnotherType()
    {
        // Arrange
        var ability = new CrewBreakerAbility(Mock.Of<ICardFilter>());
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
        var ability = new CrewBreakerAbility(Mock.Of<ICardFilter>());
        var other = new CrewBreakerAbility(Mock.Of<ICardFilter>());

        // Act
        var actual = ability.Equals(other);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var ability = new CrewBreakerAbility(filter.Object);
        var another = ability.Copy();

        // Act
        var first = ability.GetHashCode();
        var second = another.GetHashCode();

        // Assert
        Assert.Equal(first, second);
    }
}