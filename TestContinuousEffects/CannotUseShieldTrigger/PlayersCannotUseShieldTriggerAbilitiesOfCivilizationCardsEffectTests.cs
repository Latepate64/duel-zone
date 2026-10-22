using ContinuousEffects.CannotUseShieldTrigger;
using Interfaces;
using Interfaces.Zones;
using Moq;
using Xunit;

namespace TestContinuousEffects.CannotUseShieldTrigger;

public class PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(
            Civilization.Light);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void OpponentCannotUseShieldTriggerAbilitiesOfCivilizationCard(bool hasCivilization)
    {
        // Arrange
        const Civilization civilization = Civilization.Light;
        var opponent = Mock.Of<IPlayerV2>();
        var player = new Mock<IPlayerV2>();
        player.SetupGet(x => x.Opponent).Returns(opponent);
        var shieldTrigger = new Mock<ICard>();
        shieldTrigger.SetupGet(x => x.OwnerV2).Returns(opponent);
        shieldTrigger.Setup(x => x.HasCivilization(civilization)).Returns(hasCivilization);
        var effect = new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(
            civilization)
        {
            Applier = player.Object
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotUseShieldTrigger(shieldTrigger.Object, Mock.Of<IGame>());

        // Assert
        Assert.Equal(hasCivilization, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void ApplierCannotUseShieldTriggerAbilitiesOfCivilizationCard(bool hasCivilization)
    {
        // Arrange
        const Civilization civilization = Civilization.Light;
        var player = Mock.Of<IPlayerV2>();
        var shieldTrigger = new Mock<ICard>();
        shieldTrigger.SetupGet(x => x.OwnerV2).Returns(player);
        shieldTrigger.Setup(x => x.HasCivilization(civilization)).Returns(hasCivilization);
        var effect = new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(
            civilization)
        {
            Applier = player
        };
        var battleZone = Mock.Of<IBattleZone>();

        // Act
        var actual = effect.CannotUseShieldTrigger(shieldTrigger.Object, Mock.Of<IGame>());

        // Assert
        Assert.Equal(hasCivilization, actual);
    }
}