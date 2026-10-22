using ContinuousEffects;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class ThisCreatureCannotAttackCreaturesEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var blockerFilter = new Mock<ICardFilter>();
        blockerFilter.Setup(x => x.Copy()).Returns(blockerFilter.Object);
        var effect = new ThisCreatureCannotAttackCreaturesEffect(blockerFilter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CannotAttackCreature(bool targetFilterMatches)
    {
        // Arrangev
        var player = Mock.Of<IPlayerV2>();
        var attacker = new Mock<ICreature>();
        attacker.SetupGet(x => x.OwnerV2).Returns(player);
        var target = Mock.Of<ICreature>();
        var targetFilter = new Mock<ICardFilter>();
        targetFilter.Setup(x => x.Match(target)).Returns(targetFilterMatches);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(attacker.Object);
        var effect = new ThisCreatureCannotAttackCreaturesEffect(targetFilter.Object)
        {
            Ability = ability.Object,
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotAttackCreature(attacker.Object, target, Mock.Of<IGame>());

        // Assert
        Assert.Equal(targetFilterMatches, actual);
    }
}