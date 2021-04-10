﻿using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    internal class ContinuousEffectManager
    {
        /// <summary>
        /// Continuous effects that are generated by non-static abilities. Use method GetContinuousEffects() to obtain all continuous effects generated by non-static and static abilities.
        /// </summary>
        private readonly Collection<ContinuousEffect> _continuousEffects = new Collection<ContinuousEffect>();

        #region Internal methods
        internal void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffects.Add(continuousEffect);
        }

        internal void EndContinuousEffects<T>()
        {
            //TODO: Test
            _ = _continuousEffects.ToList().RemoveAll(c => c.Period is T);
            /*
            List<ContinuousEffect> suitableContinuousEffects = _continuousEffects.Where(c => c.Period.GetType() == type).ToList();
            while (suitableContinuousEffects.Count() > 0)
            {
                _continuousEffects.Remove(suitableContinuousEffects.First());
                suitableContinuousEffects.Remove(suitableContinuousEffects.First());
            }
            */
        }

        internal IEnumerable<BattleZoneCreature> GetAllBlockersPlayerHasInTheBattleZone(IPlayer player, Duel duel, AbilityManager abilityManager)
        {
            List<BattleZoneCreature> blockers = new List<BattleZoneCreature>();
            IEnumerable<BlockerEffect> blockerEffects = GetContinuousEffects<BlockerEffect>(duel, abilityManager);
            foreach (BattleZoneCreature creature in player.BattleZone.Creatures)
            {
                blockers.AddRange(blockerEffects.Where(blockerEffect => blockerEffect.CreatureFilter.FilteredCreatures.Contains(creature)).Select(blockerEffect => creature));
            }
            return new ReadOnlyCollection<BattleZoneCreature>(blockers);
        }

        internal bool HasSpeedAttacker(IDuel duel, AbilityManager abilityManager, IBattleZoneCreature creature)
        {
            return GetContinuousEffects<SpeedAttackerEffect>(duel, abilityManager).Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
        }

        internal bool HasShieldTrigger(IDuel duel, AbilityManager abilityManager, ISpell spell)
        {
            foreach (SpellContinuousEffect spellContinuousEffect in GetContinuousEffects(duel, abilityManager).Where(e => e is SpellShieldTriggerEffect).Cast<SpellShieldTriggerEffect>())
            {
                if (spellContinuousEffect.SpellFilter.FilteredSpells.Contains(spell))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool HasShieldTrigger(IDuel duel, AbilityManager abilityManager, IHandCreature creature)
        {
            foreach (CreatureShieldTriggerEffect creatureContinuousEffect in GetContinuousEffects(duel, abilityManager).OfType<CreatureShieldTriggerEffect>())
            {
                if (creatureContinuousEffect.CreatureFilter.FilteredCreatures.Contains(creature))
                {
                    return true;
                }
            }
            return false;
        }

        internal int GetPower(IDuel duel, AbilityManager abilityManager, IBattleZoneCreature creature)
        {
            return creature.Power + GetContinuousEffects<PowerEffect>(duel, abilityManager).Where(e => e.CreatureFilter.FilteredCreatures.Contains(creature)).Sum(e => e.Power);
        }

        internal IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttack(IDuel duel, AbilityManager abilityManager, IPlayer player)
        {
            return new ReadOnlyCollection<IBattleZoneCreature>(GetContinuousEffects<CannotAttackPlayersEffect>(duel, abilityManager).SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct().Where(c => !duel.GetCreaturesThatCanBeAttacked(player).Any()).ToList());
        }

        internal bool AttacksIfAble(IDuel duel, AbilityManager abilityManager, IBattleZoneCreature creature)
        {
            return GetContinuousEffects<AttacksIfAbleEffect>(duel, abilityManager).Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
        }

        internal IEnumerable<IBattleZoneCreature> GetCreaturesThatCannotAttackPlayers(IDuel duel, AbilityManager abilityManager)
        {
            return new ReadOnlyCollection<IBattleZoneCreature>(GetContinuousEffects<CannotAttackPlayersEffect>(duel, abilityManager).SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct().ToList());
        }
        #endregion Internal methods

        #region Private methods
        private IEnumerable<T> GetContinuousEffects<T>(IDuel duel, AbilityManager abilityManager)
        {
            return GetContinuousEffects(duel, abilityManager).Where(e => e is T).Cast<T>();
        }

        private ReadOnlyContinuousEffectCollection GetContinuousEffects(IDuel duel, AbilityManager abilityManager)
        {
            List<ContinuousEffect> continuousEffects = _continuousEffects.ToList();
            foreach (Card card in duel.GetAllCards())
            {
                continuousEffects.AddRange(abilityManager.GetContinuousEffectsGeneratedByCard(card, duel.GetOwner(card)));
            }
            return new ReadOnlyContinuousEffectCollection(continuousEffects);
        }
        #endregion Private methods
    }
}
