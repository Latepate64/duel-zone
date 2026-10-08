using System.Collections.Generic;
using Engine.ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;
using Interfaces.Zones;
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

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureBeBlocked(bool expected)
    {
        // Arrange
        var attackingCreature = Mock.Of<ICreature>();
        var blocker = Mock.Of<ICreature>();
        var attackTarget = Mock.Of<IAttackable>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IUnblockableEffect>();
        var battleZone = Mock.Of<IBattleZone>();
        effect.Setup(x => x.CannotBeBlocked(
            attackingCreature, blocker, attackTarget, battleZone)).Returns(
                !expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureBeBlocked(
            attackingCreature, blocker, attackTarget, battleZone);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesCreatureBlockIfAble(bool expected)
    {
        // Arrange
        var blocker = Mock.Of<ICreature>();
        var attackingCreature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IBlocksIfAbleEffect>();
        effect.Setup(x => x.BlocksIfAble(
            blocker, attackingCreature, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesCreatureBlockIfAble(
            blocker, attackingCreature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesBattleHappenAfterCreatureBecomesBlocked(bool expected)
    {
        // Arrange
        var attackingCreature = Mock.Of<ICreature>();
        var blockingCreature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ISkipBattleAfterBlockEffect>();
        effect.Setup(x => x.Applies(
            attackingCreature, blockingCreature, game)).Returns(!expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesBattleHappenAfterCreatureBecomesBlocked(
            attackingCreature, blockingCreature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetAmountOfShieldsCreatureBreaksAdditionally(int expected)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var effect = new Mock<IBreaksAdditionalShieldsEffect>();
        effect.Setup(x => x.GetAmount(creature)).Returns(expected);
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.GetAmountOfShieldsCreatureBreaksAdditionally(
            creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(1, 2)]
    [InlineData(1, 3)]
    [InlineData(2, 3)]
    [InlineData(1, 2, 3)]
    public void GetAmountsOfShieldsCreatureCanBreak(params int[] expected)
    {
        // Arrange
        var creature = Mock.Of<ICreature>();
        var breakers = new List<IBreakerEffect>();
        var battleZone = Mock.Of<IBattleZone>();
        foreach (var e in expected)
        {
            var effect = new Mock<IBreakerEffect>();
            effect.Setup(x => x.GetAmount(
                creature, battleZone)).Returns(e);
            breakers.Add(effect.Object);
        }
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        effects.Add(Mock.Of<IAbility>(), [.. breakers]);

        // Act
        var actual = effects.GetAmountsOfShieldsCreatureCanBreak(creature,
            battleZone);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(
        bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IIgnoreCannotAttackPlayersEffects>();
        effect.Setup(x => x.IgnoreCannotAttackPlayersEffects(
            creature, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(
            creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void DoesCreatureHaveSpeedAttacker(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ISpeedAttackerEffect>();
        effect.Setup(x => x.Applies(creature, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.DoesCreatureHaveSpeedAttacker(creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureAttack(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ICannotAttackEffect>();
        effect.Setup(x => x.CannotAttack(creature, game)).Returns(!expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureAttack(creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, false, false)]
    [InlineData(false, true, false)]
    [InlineData(true, false, false)]
    [InlineData(true, true, true)]
    public void CanCreatureAttackCreature(
        bool canBeAttacked, bool canAttackCreature, bool expected)
    {
        // Arrange
        var attacker = Mock.Of<ICreature>();
        var targetOfAttack = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var cannotBeAttackedEffect = new Mock<ICannotBeAttackedEffect>();
        cannotBeAttackedEffect.Setup(x => x.Applies(
            attacker, targetOfAttack)).Returns(!canBeAttacked);
        var cannotAttackCreaturesEffect = new Mock<ICannotAttackCreaturesEffect>();
        cannotAttackCreaturesEffect.Setup(x => x.CannotAttackCreature(
            attacker, targetOfAttack, game)).Returns(!canAttackCreature);
        var effects = new ContinuousEffects(game);
        effects.Add(
            Mock.Of<IAbility>(),
            cannotBeAttackedEffect.Object,
            cannotAttackCreaturesEffect.Object);

        // Act
        var actual = effects.CanCreatureAttackCreature(
            attacker, targetOfAttack);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureAttackPlayers(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ICannotAttackPlayersEffect>();
        effect.Setup(x => x.CannotAttackPlayers(creature, game)).Returns(
            !expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureAttackPlayers(creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanPlayerUseCard(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var card = Mock.Of<ICard>();
        var effect = new Mock<ICannotUseCardEffect>();
        effect.Setup(x => x.Applies(card)).Returns(!expected);
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanPlayerUseCard(card);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureEvolve(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IEvolutionEffect>();
        effect.Setup(x => x.CanEvolve(game, creature)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureEvolve(creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanPlayersUseTapAbilities(bool expected)
    {
        // Arrange
        var effects = new ContinuousEffects(Mock.Of<IGame>());
        if (expected)
        {
            effects.Add(
                Mock.Of<IAbility>(), Mock.Of<IPlayersCannotUseTapAbilities>());
        }

        // Act
        var a = effects.CanPlayersUseTapAbilities();

        // Assert
        Assert.Equal(expected, a);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureBeAttackedAsThoughItWereTapped(bool expected)
    {
        // Arrange
        var player = Mock.Of<IPlayer>();
        var creature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ICanBeAttackedAsThoughTappedEffect>();
        effect.Setup(x => x.Applies(creature)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureBeAttackedAsThoughItWereTapped(
            creature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void CanCreatureAttackUntappedCreature(bool expected)
    {
        // Arrange
        var attacker = Mock.Of<ICreature>();
        var untappedCreature = Mock.Of<ICreature>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<ICanAttackUntappedCreaturesEffect>();
        effect.Setup(x => x.CanAttackUntappedCreature(
            attacker, untappedCreature, game)).Returns(expected);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.CanCreatureAttackUntappedCreature(
            attacker, untappedCreature);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetApplicableReplacementEffect()
    {
        // Arrange
        var gameEvent = Mock.Of<IGameEvent>();
        var game = Mock.Of<IGame>();
        var effect = new Mock<IReplacementEffect>();
        effect.Setup(x => x.CanBeApplied(gameEvent, game)).Returns(true);
        var effects = new ContinuousEffects(game);
        effects.Add(Mock.Of<IAbility>(), effect.Object);

        // Act
        var actual = effects.GetReplacementEffectsThatCanBeApplied(
            gameEvent);

        // Assert
        Assert.Contains(effect.Object, actual);
    }
}