using ContinuousEffects.Breaker;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Breaker;

public class CrewBreakerRaceEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new CrewBreakerRaceEffect(Race.AngelCommand);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreatureWithoutCrewBreakerBreaksOneShield()
    {
        // Arrange
        var effect = new CrewBreakerRaceEffect(Race.AngelCommand);
        var creature = Mock.Of<ICreature>();
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.GetAmount(creature, battleZone);

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
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source.Object);
        var effect = new CrewBreakerRaceEffect(Race.AngelCommand)
        {
            Ability = ability.Object
        };
        var battleZone = new Mock<IBattleZone>();
        battleZone.Setup(x => x.GetNumberOfOtherRaceCreaturesControllerByPlayer(
            source.Object, Race.AngelCommand)).Returns(numberOfOtherCreatures);

        // Act
        var actual = effect.GetAmount(source.Object, battleZone.Object);

        // Assert
        Assert.Equal(1 + numberOfOtherCreatures, actual);
    }
}