using Engine.ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using Moq;
using Xunit;

namespace TestEngine;

public sealed class ContinuousEffectsTests
{
    [Fact]
    public void HashCodesAreEqualForEqualObjects()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        var continuousEffect = new Mock<IContinuousEffect>();
        continuousEffect.Setup(x => x.Copy()).Returns(
            continuousEffect.Object);
        effects.Add(Mock.Of<IAbility>(), continuousEffect.Object);
        var another = effects.Copy();

        // Act
        var expected = effects.GetHashCode();
        var actual = another.GetHashCode();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DoesNotEqualObjectOfAnotherType()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());

        // Act
        var actual = effects.Equals(new object());

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(false, false)]
    public void DoesNotEqualObjectWithDifferentGame(
        bool firstNull, bool secondNull)
    {
        // Arrange
        var first = new ContinuousEffects(firstNull ? null : Mock.Of<IGame>());
        var second = new ContinuousEffects(
            secondNull ? null : Mock.Of<IGame>());

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void DoesNotEqualObjectWithDifferentEffects()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var first = new ContinuousEffects(game);
        first.Add(Mock.Of<IAbility>(), Mock.Of<IContinuousEffect>());
        var second = new ContinuousEffects(game);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void ObjectsAreEqual()
    {
        // Arrange
        var game = Mock.Of<IGame>();
        var first = new ContinuousEffects(game);
        var second = new ContinuousEffects(game);

        // Act
        var actual = first.Equals(second);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void CopyOfEffectsGetsAbilityReferenceAndTimestamp()
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        var source = Mock.Of<ICard>();
        var staticAbility = new Mock<IStaticAbility>();
        var effect = new Mock<IContinuousEffect>();
        effect.Setup(x => x.Copy()).Returns(effect.Object);
        staticAbility.SetupGet(x => x.ContinuousEffects).Returns([
            effect.Object]);

        // Act
        effects.Add(source, staticAbility.Object);

        // Assert
        effect.VerifySet((x) => x.Ability = staticAbility.Object);
        effect.VerifySet((x) => x.Timestamp = source.Timestamp);
    }

    [Fact]
    public void EffectsGetApplied()
    {
        // Arrange
        var game = new Mock<IGame>();
        var card = new Mock<ICard>();
        game.Setup(x => x.GetAllCards()).Returns([card.Object]);
        var effects = new ContinuousEffects(game.Object);
        var raceAddingEffect = new Mock<IRaceAddingEffect>();
        var abilityAddingEffect = new Mock<IAbilityAddingEffect>();
        var powerModifyingEffect = new Mock<IPowerModifyingEffect>();
        effects.Add(
            Mock.Of<IAbility>(),
            raceAddingEffect.Object,
            abilityAddingEffect.Object,
            powerModifyingEffect.Object);

        // Act
        effects.Apply();

        // Assert
        card.Verify(x => x.ResetToPrintedValues());
        raceAddingEffect.Verify(x => x.AddRace(game.Object));
        abilityAddingEffect.Verify(x => x.AddAbility(game.Object));
        powerModifyingEffect.Verify(x => x.ModifyPower(game.Object));
    }

    [Fact]
    public void RemoveExpired()
    {
        // Arrange
        var gameEvent = Mock.Of<IGameEvent>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IContinuousEffect>();
        var expirable = effect.As<IExpirable>();
        expirable.Setup(x => x.ShouldExpire(gameEvent, game)).Returns(true);
        var notExpirable = new Mock<IContinuousEffect>();
        var effects = new ContinuousEffects(game);
        effects.Add(
            Mock.Of<IAbility>(),
            effect.Object,
            notExpirable.Object);

        // Act + Assert
        effects.RemoveExpired(gameEvent);
    }

    [Fact]
    public void WatchersAreNotified()
    {
        // Arrange
        var gameEvent = Mock.Of<IGameEvent>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IContinuousEffect>();
        var watcher = effect.As<IWatcher>();

        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        effects.Notify(gameEvent);

        // Assert
        watcher.Verify(x => x.Watch(game, gameEvent));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void
        CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(
            bool expected
        )
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var effect = new Mock<IPlayerCannotUntapCardsInManaZoneAtStartOfTurn>();
        effect.Setup(
            x => x.PlayerCannotUntapCardsInManaZoneAtStartOfTurn(
                player)).Returns(!expected);
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(
            player);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn(
        bool expected)
    {
        // Arrange
        var e = Mock.Of<ICreaturesDoNotUntapAtTheStartOfEachPlayersTurn>();
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        if (!expected)
        {
            effects.Add(Mock.Of<IAbility>(), e);
        }

        // Act
        var a = effects.DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn();

        // Assert
        Assert.Equal(expected, a);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesCreatureAttackIfAble(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IAttacksIfAbleEffect>();
        effect.Setup(x => x.AttacksIfAble(creature, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesCreatureAttackIfAble(creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void PlayerCannotTapCreature(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IPlayerCannotTapCreatureEffect>();
        effect.Setup(x => x.PlayerCannotTapCreature(
            player, creature, game)).Returns(!expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanPlayerTapCreature(player, creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanPlayerChooseCreature(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IPlayerCannotChooseCreatureEffect>();
        effect.Setup(x => x.PlayerCannotChooseCreature(
            creature, player.Id, game)).Returns(!expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanPlayerChooseCreature(player, creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesAnySlayerEffectApply(bool expected)
    {
        // Arrange
        var loser = Mock.Of<ICreature>();
        var winner = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ISlayerEffect>();
        effect.Setup(x => x.Applies(
            loser, winner, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesAnySlayerEffectApply(loser, winner);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesCreatureGetDestroyedInBattle(bool expected)
    {
        // Arrange
        var against = Mock.Of<ICreature>();
        var target = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<INotDestroyedInBattleEffect>();
        effect.Setup(x => x.Applies(
            against, target, game)).Returns(!expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesCreatureGetDestroyedInBattle(against, target);

        // Assert
        Assert.Equal(expected, actual);
    }
}