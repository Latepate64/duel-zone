using ContinuousEffects.Unblockable;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.Unblockable;

public class ThisCreatureCannotBeBlockedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Copy()).Returns(blockerFilter.Object);
        var effect = new ThisCreatureCannotBeBlockedEffect(blockerFilter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CannotBeBlocked(bool expected)
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
        var effect = new ThisCreatureCannotBeBlockedEffect(blockerFilter.Object)
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