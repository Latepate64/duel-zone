﻿using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.StaticAbilities;
using DuelMastersModels.Abilities.TriggerAbilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.PlayerActions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class AbilityManager
    {
        #region Internal properties
        internal bool IsAbilityBeingResolved => _abilityBeingResolved != null;

        internal bool IsAbilityBeingResolvedSpellAbility => _abilityBeingResolved is SpellAbility;
        #endregion Internal properties

        #region Fields
        /// <summary>
        /// An ability can be a characteristic an card has that lets it affect the game. A card's abilities are defined by its rules text or by the effect that created it.
        /// </summary>
        private readonly AbilityCollection _abilities = new AbilityCollection();

        /// <summary>
        /// Non-static abilities that are waiting to be resolved.
        /// </summary>
        private readonly Collection<INonStaticAbility> _pendingAbilities = new Collection<INonStaticAbility>();

        /// <summary>
        /// A non-static ability that is currently being resolved.
        /// </summary>
        private INonStaticAbility _abilityBeingResolved;
        #endregion Fields

        #region Internal methods
        internal void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature)
        {
            TriggerTriggerAbilities<WhenYouPutThisCreatureIntoTheBattleZone>(creature);
        }

        internal void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(ReadOnlyCollection<IBattleZoneCreature> creatures)
        {
            TriggerTriggerAbilities<WheneverAnotherCreatureIsPutIntoTheBattleZone>(creatures);
        }

        internal void TriggerWheneverAPlayerCastsASpellAbilities(IEnumerable<IBattleZoneCreature> creatures)
        {
            TriggerTriggerAbilities<WheneverAPlayerCastsASpell>(creatures);
        }

        internal List<IContinuousEffect> GetContinuousEffectsGeneratedByCard(Card card, IPlayer player)
        {
            List<IContinuousEffect> continuousEffects = new List<IContinuousEffect>();
            foreach (IStaticAbility staticAbility in GetStaticAbilities().Where(a => a.Source == card))
            {
                continuousEffects.AddRange(player.GetContinuousEffectsGeneratedByStaticAbility(card, staticAbility));
            }
            return continuousEffects;
        }

        internal PlayerActionWithEndInformation ContinueResolution(IDuel duel)
        {
            return _abilityBeingResolved.ContinueResolution(duel);
        }

        internal void SetAbilityBeingResolved(INonStaticAbility ability)
        {
            _abilityBeingResolved = ability;
        }

        internal void StartResolvingSpellAbility(ISpell spell)
        {
            //TODO: spell may have more than one spell ability.
            SpellAbility spellAbility = GetSpellAbilities().First(a => a.Source == spell);
            SetAbilityBeingResolved(spellAbility);
        }

        internal int GetSpellAbilityCount(ISpell spell)
        {
            return GetSpellAbilities().Count(a => a.Source == spell);
        }

        internal void RemovePendingAbility(INonStaticAbility ability)
        {
            _ = _pendingAbilities.Remove(ability);
        }

        internal SelectAbilityToResolve TryGetSelectAbilityToResolve(IPlayer player)
        {
            ReadOnlyCollection<INonStaticAbility> pendingAbilities = GetPendingAbilitiesForPlayer(player);
            return pendingAbilities.Count > 0 ? new SelectAbilityToResolve(player, pendingAbilities) : null;
        }
        #endregion Internal methods

        #region Private methods
        private ReadOnlyCollection<TriggerAbility> GetTriggerAbilities()
        {
            return new ReadOnlyTriggerAbilityCollection(_abilities.Where(a => a is TriggerAbility).Cast<TriggerAbility>());
        }

        private ReadOnlyCollection<TriggerAbility> GetTriggerAbilities<T>(ICard card)
        {
            return new ReadOnlyCollection<TriggerAbility>(GetTriggerAbilities().Where(ability => ability.Source == card && ability.TriggerCondition is T).ToList());
        }

        /// <summary>
        /// Once an ability has triggered, its controller puts it on the stack as an object that’s not a card the next time a player would receive priority.
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="controller"></param>
        /// <param name="source"></param>
        private void TriggerTriggerAbility(TriggerAbility ability, IPlayer controller, ICard source)
        {
            _pendingAbilities.Add(ability.CreatePendingTriggerAbility(controller, source));
        }

        private void TriggerTriggerAbilities<T>(IBattleZoneCreature card)
        {
            foreach (TriggerAbility ability in GetTriggerAbilities<T>(card))
            {
                TriggerTriggerAbility(ability, ability.Controller, card);
            }
        }

        private void TriggerTriggerAbilities<T>(IEnumerable<IBattleZoneCreature> creatures)
        {
            foreach (IBattleZoneCreature creature in creatures)
            {
                TriggerTriggerAbilities<T>(creature);
            }
        }

        private ReadOnlyStaticAbilityCollection GetStaticAbilities()
        {
            return new ReadOnlyStaticAbilityCollection(_abilities.Where(a => a is IStaticAbility).Cast<IStaticAbility>());
        }

        private ReadOnlySpellAbilityCollection GetSpellAbilities()
        {
            return new ReadOnlySpellAbilityCollection(_abilities.Where(a => a is SpellAbility).Cast<SpellAbility>());
        }

        /// <summary>
        /// Non-static abilities controlled by a player that are waiting to be resolved.
        /// </summary>
        private ReadOnlyCollection<INonStaticAbility> GetPendingAbilitiesForPlayer(IPlayer player)
        {
            return new ReadOnlyCollection<INonStaticAbility>(_pendingAbilities.Where(a => a.Controller == player).ToList());
        }
        #endregion Private methods
    }
}
