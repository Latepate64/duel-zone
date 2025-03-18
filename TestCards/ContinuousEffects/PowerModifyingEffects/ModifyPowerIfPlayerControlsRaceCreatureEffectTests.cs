using Cards.ContinuousEffects.PowerModifyingEffects;
using Engine;
using Engine.Abilities;
using Moq;
using Xunit;

namespace TestCards.ContinuousEffects.PowerModifyingEffects;

public class ModifyPowerIfPlayerControlsRaceCreatureEffectTestsTests
{
    [Theory]
    [InlineData(Race.AngelCommand, 2000, 2000)]
    [InlineData(Race.ArmoredDragon, 1000, 3000)]
    public void ModifiesPowerWhilePlayerHasCreatureOfSpecificRaceInTheBattleZone(
        Race race, int powerToAdd, int initialPower)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var card = Mock.Of<ICard>();
        card.Power = initialPower;
        card.Owner = player;
        var expectedCreature = new Mock<ICard>();
        expectedCreature.SetupGet(x => x.Races).Returns([race]);
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(card);
        var effect = new ModifyPowerIfPlayerControlsRaceCreatureEffect(race,
            powerToAdd)
        {
            Ability = ability.Object
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreatures(player, race)).Returns(
            [expectedCreature.Object]);

        // Act
        effect.ModifyPower(game.Object);

        // Assert
        Assert.Equal(initialPower + powerToAdd, card.Power);
    }

    [Fact]
    public void DoesNotModifyPowerWhilePlayerDoesNotHaveCreatureOfSpecificRaceInTheBattleZone()
    {
        // Arrange
        const int initialPower = 2000;
        const Race race = Race.ArmoredDragon;
        var player = Mock.Of<IPlayer>();
        var card = Mock.Of<ICard>();
        card.Power = initialPower;
        card.Owner = player;
        var ability = new Mock<IAbility>();
        ability.SetupGet(x => x.Source).Returns(card);
        var effect = new ModifyPowerIfPlayerControlsRaceCreatureEffect(race,
            3000)
        {
            Ability = ability.Object
        };
        var game = new Mock<IGame>();
        game.Setup(x => x.BattleZone.GetCreatures(player, race)).Returns([]);

        // Act
        effect.ModifyPower(game.Object);

        // Assert
        Assert.Equal(initialPower, card.Power);
    }

    [Fact]
    public void Copy()
    {
        var effect = new ModifyPowerIfPlayerControlsRaceCreatureEffect(
            Race.ZombieDragon, 2000);
        var copy = effect.Copy();
        Assert.Equal(effect, copy);
        Assert.Equal(effect.GetHashCode(), copy.GetHashCode());
    }

    [Fact]
    public void EffectsNotEqual()
    {
        Assert.NotEqual(
            new ModifyPowerIfPlayerControlsRaceCreatureEffect(Race.ZombieDragon,
                2000),
            new ModifyPowerIfPlayerControlsRaceCreatureEffect(Race.AngelCommand,
                2000));
    }
}
