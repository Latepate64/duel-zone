using ContinuousEffects.CannotUseShieldTrigger;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotUseShieldTrigger;

public class YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect();

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void YourOpponentCannotUseShieldTriggersWhileSourceIsTapped(bool sourceIsTapped)
    {
        // Arrangev
        var opponent = Mock.Of<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent);
        var shieldTrigger = new Mock<ICard>();
        shieldTrigger.SetupGet(x => x.OwnerV2).Returns(opponent);
        var creature = new Mock<ICreature>();
        creature.SetupGet(x => x.Tapped).Returns(sourceIsTapped);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(creature.Object);
        var effect = new YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect()
        {
            Ability = ability.Object,
            Applier = player.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotUseShieldTrigger(shieldTrigger.Object, Mock.Of<IGame>());

        // Assert
        Assert.Equal(sourceIsTapped, actual);
    }
}