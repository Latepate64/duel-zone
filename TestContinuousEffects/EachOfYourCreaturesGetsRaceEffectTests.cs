using ContinuousEffects;
using Interfaces;
using Moq;
using Xunit;

namespace TestContinuousEffects;

public class EachOfYourCreaturesGetsRaceEffectTests
{
    [Fact]
    public void CopyEqualsOriginal()
    {
        // Arrange
        var filter = new Mock<ICardFilter>();
        filter.Setup(x => x.Copy()).Returns(filter.Object);
        var effect = new EachOfYourCreaturesGetsRaceEffect(Race.AngelCommand, filter.Object);

        // Act
        var copy = effect.Copy();

        // Assert
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void CreatureGetsRace()
    {
        // Arrange
        const Race race = Race.AngelCommand;
        var creature = new Mock<ICreature>();
        var filter = Mock.Of<ICardFilter>();
        var player = Mock.Of<IPlayerV2>();
        var effect = new EachOfYourCreaturesGetsRaceEffect(race, filter)
        {
            Applier = player
        };
        var attacker = Mock.Of<ICreature>();
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreaturesControlledByPlayer(player, filter)).Returns(
            [creature.Object]);

        // Act
        effect.AddRace(game.Object);

        // Assert
        creature.Verify(x => x.AddGrantedRace(race));
    }
}