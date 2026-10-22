using ContinuousEffects.AttacksIfAble;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AttacksIfAble;

public class EachOfYourOpponentsCreaturesAttacksIfAbleEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new EachOfYourOpponentsCreaturesAttacksIfAbleEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void OpponentsCreatureAttacksIfAble()
    {
        // Arrange
        var opponent = Mock.Of<IPlayerV2>();
        var applier = new Mock<IPlayerV2>();
        applier.SetupGet(x => x.Opponent).Returns(opponent);
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(opponent);
        var source = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source);
        var effect = new EachOfYourOpponentsCreaturesAttacksIfAbleEffect
        {
            Ability = ability.Object,
            Applier = applier.Object
        };

        // Act
        var actual = effect.AttacksIfAble(attacker.Object, Mock.Of<IGame>());

        // Assert
        Assert.True(actual);
    }
}