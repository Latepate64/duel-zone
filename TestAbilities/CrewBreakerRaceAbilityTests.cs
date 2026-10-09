using Abilities.Static;
using Interfaces;
using Interfaces.Zones;
using Moq;

namespace TestAbilities;

public class CrewBreakerRaceAbilityTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var ability = new CrewBreakerRaceAbility(Race.AngelCommand);

        // Act
        var copy = ability.Copy();

        // Assert
        Assert.Equal(ability, copy);
    }

    [Fact]
    public void CreatureWithoutCrewBreakerBreaksOneShield()
    {
        // Arrange
        var ability = new CrewBreakerRaceAbility(Race.AngelCommand);
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = ability.GetAmount(creature, battleZone);

        // Assert
        Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void CreatureWithCrewBreakerBreaksExpectedNumberOfShields(
        int numberOfOtherCreatures)
    {
        // Arrange
        var player = Mock.Of<IPlayerV2>();
        var source = new Mock<ICreature>();
        source.SetupGet(x => x.OwnerV2).Returns(player);
        var ability = new CrewBreakerRaceAbility(Race.AngelCommand) {
            Source = source.Object
        };
        var battleZone = new Mock<IBattleZone>();
        battleZone.Setup(x => x.GetNumberOfOtherRaceCreaturesControllerByPlayer(
            source.Object, Race.AngelCommand)).Returns(numberOfOtherCreatures);

        // Act
        var actual = ability.GetAmount(source.Object, battleZone.Object);

        // Assert
        Assert.Equal(1 + numberOfOtherCreatures, actual);
    }
}