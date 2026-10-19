using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class YourOtherCreaturesCannotBeBlockedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var attackerFilter = new Mock<ICardFilter>();
        attackerFilter.Setup(x => x.Copy()).Returns(attackerFilter.Object);
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Copy()).Returns(blockerFilter.Object);
        var effect = new YourOtherCreaturesCannotBeBlockedEffect(
            attackerFilter.Object, blockerFilter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false, false, false)]
    [InlineData(false, true, false)]
    [InlineData(true, false, false)]
    [InlineData(true, true, true)]
    public void CannotBeBlocked(bool attackerMatch, bool blockerMatch, bool expected)
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var blocker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<IAttackable>();
        var attackerFilter = new Mock<ICardFilter>();
        attackerFilter.Setup(x => x.Match(attacker.Object)).Returns(attackerMatch);
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Match(blocker)).Returns(blockerMatch);
        var source = Mock.Of<ICreature>();
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(source);
        var effect = new YourOtherCreaturesCannotBeBlockedEffect(
            attackerFilter.Object, blockerFilter.Object)
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotBeBlocked(attacker.Object, blocker, targetOfAttack, battleZone);

        // Assert
        Assert.Equal(expected, actual);
    }
}