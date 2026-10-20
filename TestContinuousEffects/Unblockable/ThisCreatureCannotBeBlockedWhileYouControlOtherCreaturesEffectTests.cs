using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Copy()).Returns(blockerFilter.Object);
        var effect = new ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect(
            blockerFilter.Object, 2);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(2, 1, false)]
    [InlineData(2, 2, true)]
    public void CannotBeBlocked(int minimum, int numberOfOtherCreatures, bool expected)
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<IAttackable>();
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Match(blocker)).Returns(expected);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new ThisCreatureCannotBeBlockedWhileYouControlOtherCreaturesEffect(
            blockerFilter.Object, minimum)
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = new Mock<IBattleZone>();
        battleZone.Setup(x => x.GetNumberOfOtherCreaturesControllerByPlayer(
            attacker.Object, blockerFilter.Object)).Returns(numberOfOtherCreatures);

        // Act
        var actual = effect.CannotBeBlocked(
            attacker.Object, blocker, targetOfAttack, battleZone.Object);

        // Assert
        Assert.Equal(expected, actual);
    }
}