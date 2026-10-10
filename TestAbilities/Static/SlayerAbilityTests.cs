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

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void AppliesToCreatureWithSlayer(bool defendingCreatureMatches)
    {
        // Arrange
        var slayer = Mock.Of<ICreature>();
        var defendingCreature = Mock.Of<ICreature>();
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Match(defendingCreature)).Returns(
            defendingCreatureMatches);
        var ability = new SlayerAbility(filter.Object) { Source = slayer };

        // Act
        var actual = ability.Applies(slayer, defendingCreature);

        // Assert
        Assert.Equal(defendingCreatureMatches, actual);
    }
}