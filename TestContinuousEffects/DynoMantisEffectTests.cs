using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class DynoMantisEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new DynoMantisEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
    }

    [Fact]
    public void CreaturesOfAnotherPlayerBreakNoAdditionalShields()
    {
        // Arrange
        var effect = new DynoMantisEffect();

        // Act
        var actual = effect.GetAmount(Mock.Of<ICreature>());

        // Assert
        Assert.Equal(0, actual);
    }

    [Fact]
    public void CreatureItselfBreaksNoAdditionalShields()
    {
        // Arrange
        var applier = Mock.Of<IPlayerV2>();
        var effect = new DynoMantisEffect
        {
            Applier = applier
        };
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(applier);

        // Act
        var actual = effect.GetAmount(creature.Object);

        // Assert
        Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(4999, 0)]
    [InlineData(5000, 1)]
    public void
        AnotherCreatureControlledByApplierBreaksAdditionalShieldsBasedOnItsPower(
            int power, int expected)
    {
        // Arrange
        var applier = Mock.Of<IPlayerV2>();
        var source = new Mock<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source.Object);
        source.SetupGet(x => x.OwnerV2).Returns(applier);
        var effect = new DynoMantisEffect
        {
            Applier = applier,
            Ability = ability.Object
        };
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.OwnerV2).Returns(applier);
        creature.SetupGet(x => x.Power).Returns(power);

        // Act
        var actual = effect.GetAmount(creature.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}