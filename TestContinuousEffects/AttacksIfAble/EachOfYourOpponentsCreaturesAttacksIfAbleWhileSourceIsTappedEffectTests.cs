using ContinuousEffects.AttacksIfAble;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects.AttacksIfAble;

public class EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var effect = new EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void OpponentsCreatureAttacksIfAbleWhileSourceIsTapped(bool sourceTapped)
    {
        // Arrange
        var opponent = Mock.Of<IPlayerV2>();
        var applier = new Mock<IPlayerV2>();
        applier.SetupGet(x => x.Opponent).Returns(opponent);
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(opponent);
        var source = new Mock<ICreature>();
        source.SetupGet(x => x.Tapped).Returns(sourceTapped);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source.Object);
        var effect = new EachOfYourOpponentsCreaturesAttacksIfAbleWhileSourceIsTappedEffect
        {
            Ability = ability.Object,
            Applier = applier.Object
        };

        // Act
        var actual = effect.AttacksIfAble(attacker.Object, Mock.Of<IGame>());

        // Assert
        Assert.Equal(sourceTapped, actual);
    }
}