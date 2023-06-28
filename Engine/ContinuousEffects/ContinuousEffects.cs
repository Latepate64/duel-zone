﻿using Engine.Abilities;
using Engine.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class ContinuousEffects : IContinuousEffects
    {
        /// <summary>
        /// 611.2a A continuous effect generated by the resolution of a spell or ability lasts as long as stated by the spell or ability creating it (such as “until end of turn”).
        /// If no duration is stated, it lasts until the end of the game.
        /// </summary>
        private readonly List<IContinuousEffect> _continuousEffects = new();

        public IGame Game { get; }

        public ContinuousEffects(IGame game)
        {
            Game = game;
        }

        public ContinuousEffects(ContinuousEffects effects)
        {
            _continuousEffects = effects._continuousEffects.Select(x => x.Copy()).ToList();
            Game = effects.Game;
        }

        public void Add(ICard source, params IStaticAbility[] staticAbilities)
        {
            var effects = new List<IContinuousEffect>();
            foreach (var ability in staticAbilities)
            {
                foreach (var effect in ability.ContinuousEffects)
                {
                    var copy = effect.Copy();
                    copy.Ability = ability;

                    // 613.7a A continuous effect generated by a static ability has the same timestamp as the object the static ability is on,
                    // or the timestamp of the effect that created the ability, whichever is later.
                    // If the effect that created the ability has the later timestamp and the object the ability is on receives a new timestamp,
                    // each continuous effect generated by static abilities of that object receives a new timestamp as well,
                    // but the relative order of those timestamps remains the same.
                    copy.Timestamp = source.Timestamp;

                    effects.Add(copy);
                }
            }
            _continuousEffects.AddRange(effects);
        }

        private IEnumerable<T> GetContinuousEffects<T>() where T : IContinuousEffect
        {
            return _continuousEffects.OfType<T>();
        }

        public void Remove(IEnumerable<Guid> staticAbilities)
        {
            _ = _continuousEffects.RemoveAll(x => staticAbilities.Contains(x.Ability.Id));
        }

        /// <summary>
        /// 613. Interaction of Continuous Effects
        /// </summary>
        public void Apply()
        {
            // 613.1.The values of an object’s characteristics are determined by starting with the actual object.
            // For a card, that means the values of the characteristics printed on that card.
            Game.GetAllCards().ToList().ForEach(x => x.ResetToPrintedValues());
            var orderedEffects = _continuousEffects.OrderBy(x => x.Timestamp);

            // TODO: 613.1d Layer 4: Type-changing effects are applied. These include effects that change an object’s card type, race, and / or supertype.
            orderedEffects.OfType<IRaceAddingEffect>().ToList().ForEach(x => x.AddRace(Game));

            // 613.1f Layer 6: Ability-adding effects, ability-removing effects, and effects that say an object can’t have an ability are applied.
            orderedEffects.OfType<IAbilityAddingEffect>().ToList().ForEach(x => x.AddAbility(Game));

            // 613.1g Layer 7: Power-changing effects are applied.
            // 613.4c Layer 7c: Effects that modify power (but don’t set power to a specific number or value) are applied.
            orderedEffects.OfType<IPowerModifyingEffect>().ToList().ForEach(x => x.ModifyPower());

            // TODO: Should check if any characteristics have changed and provide that information as an event.
        }

        public void RemoveExpired(IGameEvent gameEvent)
        {
            foreach (var remove in _continuousEffects.Where(x => x is IExpirable d && d.ShouldExpire(gameEvent)).ToArray())
            {
                _continuousEffects.Remove(remove);
            }
        }

        public void Notify(IGameEvent gameEvent)
        {
            _continuousEffects.OfType<IWatcher>().ToList().ForEach(x => x.Watch(Game, gameEvent));
        }

        public bool CanPlayerUntapTheCardsInTheirManaZoneAtTheStartOfEachOfTheirTurns(IPlayer player)
        {
            return !GetContinuousEffects<IPlayerCannotUntapCardsInManaZoneAtStartOfTurn>().Any(x => x.PlayerCannotUntapCardsInManaZoneAtStartOfTurn(player));
        }

        public bool DoCreaturesInTheBattleZoneUntapAtTheStartOfEachPlayersTurn()
        {
            return !GetContinuousEffects<ICreaturesDoNotUntapAtTheStartOfEachPlayersTurn>().Any();
        }

        public bool DoesCreatureAttackIfAble(ICard creature)
        {
            return GetContinuousEffects<IAttacksIfAbleEffect>().Any(effect => effect.AttacksIfAble(creature, Game));
        }

        public bool CanPlayerTapCreature(IPlayer player, ICard card)
        {
            return !GetContinuousEffects<IPlayerCannotTapCreatureEffect>().Any(e => e.PlayerCannotTapCreature(player, card, Game));
        }

        public bool CanPlayerChooseCreature(IPlayer player, ICard card)
        {
            return !GetContinuousEffects<IPlayerCannotChooseCreatureEffect>().Any(x => x.PlayerCannotChooseCreature(card, player.Id, Game));
        }

        public bool DoesAnySlayerEffectApply(ICard loser, ICard winner)
        {
            return GetContinuousEffects<ISlayerEffect>().Any(x => x.Applies(loser, winner, Game));
        }

        public bool DoesCreatureGetDestroyedInBattle(ICard against, ICard target)
        {
            return GetContinuousEffects<INotDestroyedInBattleEffect>().Any(x => x.Applies(against, target, Game));
        }

        public bool CanCreatureBlockCreature(ICard blocker, ICard attackingCreature)
        {
            return GetContinuousEffects<IBlockerEffect>().Any(e => e.CanBlock(blocker, attackingCreature, Game));
        }

        public bool CanCreatureBeBlocked(ICard attackingCreature, ICard blocker, IAttackable attackTarget)
        {
            return !GetContinuousEffects<IUnblockableEffect>().Any(e => e.CannotBeBlocked(attackingCreature, blocker, attackTarget));
        }

        public bool DoesCreatureBlockIfAble(ICard blocker, ICard attackingCreature)
        {
            return GetContinuousEffects<IBlocksIfAbleEffect>().Any(e => e.BlocksIfAble(blocker, attackingCreature, Game));
        }

        public bool DoesBattleHappenAfterCreatureBecomesBlocked(ICard attackingCreature, ICard blockingCreature)
        {
            return !GetContinuousEffects<ISkipBattleAfterBlockEffect>().Any(x => x.Applies(attackingCreature, blockingCreature, Game));
        }

        public int GetAmountOfShieldsCreatureBreaksAdditionally(ICard attackingCreature)
        {
            return GetContinuousEffects<IBreaksAdditionalShieldsEffect>().Sum(x => x.GetAmount(Game, attackingCreature));
        }

        public IEnumerable<int> GetAmountsOfShieldsCreatureCanBreak(ICard attackingCreature)
        {
            return GetContinuousEffects<IBreakerEffect>().Select(x => x.GetAmount(Game, attackingCreature));
        }

        public bool DoesPlayerIgnoreAnyEffectsThatWouldPreventCreatureFromAttackingTheirOpponent(ICard creature)
        {
            return GetContinuousEffects<IIgnoreCannotAttackPlayersEffects>().Any(x => x.IgnoreCannotAttackPlayersEffects(creature));
        }

        public bool DoesCreatureHaveSpeedAttacker(ICard creature)
        {
            return GetContinuousEffects<ISpeedAttackerEffect>().Any(x => x.Applies(creature, Game));
        }

        public bool CanCreatureAttack(ICard creature)
        {
            return !GetContinuousEffects<ICannotAttackEffect>().Any(x => x.CannotAttack(creature, Game));
        }

        public bool CanCreatureAttackCreature(ICard attacker, ICard targetOfAttack)
        {
            // TODO: Merge ICannotBeAttackedEffect and ICannotAttackCreaturesEffect
            return !GetContinuousEffects<ICannotBeAttackedEffect>().Any(x => x.Applies(attacker, targetOfAttack, Game)) && !GetContinuousEffects<ICannotAttackCreaturesEffect>().Any(x => x.CannotAttackCreature(attacker, targetOfAttack, Game));
        }

        public bool CanCreatureAttackPlayers(ICard creature)
        {
            return !GetContinuousEffects<ICannotAttackPlayersEffect>().Any(x => x.CannotAttackPlayers(creature, Game));
        }

        public bool CanPlayerUseCard(ICard card)
        {
            return !GetContinuousEffects<ICannotUseCardEffect>().Any(x => x.Applies(card, Game));
        }

        public bool CanCreatureEvolve(ICard toEvolve)
        {
            return GetContinuousEffects<IEvolutionEffect>().Any(x => x.CanEvolve(Game, toEvolve));
        }

        public bool CanPlayersUseTapAbilities()
        {
            return GetContinuousEffects<IPlayersCannotUseTapAbilities>().Any();
        }

        public bool CanCreatureBeAttackedAsThoughItWereTapped(ICard c)
        {
            return GetContinuousEffects<ICanBeAttackedAsThoughTappedEffect>().Any(x => x.Applies(c));
        }

        public bool CanCreatureAttackUntappedCreature(ICard attacker, ICard untappedCreature)
        {
            return GetContinuousEffects<ICanAttackUntappedCreaturesEffect>().Any(e => e.CanAttackUntappedCreature(attacker, untappedCreature));
        }

        public IEnumerable<IReplacementEffect> GetReplacementEffectsThatCanBeApplied(IGameEvent gameEvent)
        {
            return GetContinuousEffects<IReplacementEffect>().Where(effect => effect.CanBeApplied(gameEvent, Game));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IContinuousEffects Copy()
        {
            return new ContinuousEffects(this);
        }

        public void Add(IAbility source, params IContinuousEffect[] continuousEffects)
        {
            // 613.7b A continuous effect generated by the resolution of a spell or ability receives a timestamp at the time it’s created.
            continuousEffects.ToList().ForEach(x => { x.Timestamp = Game.GetTimestamp(); x.Ability = source; });
            _continuousEffects.AddRange(continuousEffects);
        }
    }
}
