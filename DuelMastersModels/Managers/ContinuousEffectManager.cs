﻿using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Managers
{
    public class ContinuousEffectManager
    {
        public Duel Duel { get; set; }

        public ContinuousEffectManager(Duel duel)
        {
            Duel = duel;
        }

        public void AddContinuousEffect(ContinuousEffect continuousEffect)
        {
            _continuousEffects.Add(continuousEffect);
        }

        public void EndContinuousEffects<T>()
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

        public IEnumerable<Creature> GetAllBlockersPlayerHasInTheBattleZone(Player player)
        {
            throw new System.NotImplementedException();
            //List<Creature> blockers = new List<Creature>();
            //IEnumerable<BlockerEffect> blockerEffects = GetContinuousEffects<BlockerEffect>();
            //foreach (Creature creature in Duel.BattleZone.Creatures)
            //{
            //    blockers.AddRange(blockerEffects.Where(blockerEffect => blockerEffect.CreatureFilter.FilteredCreatures.Contains(creature)).Select(blockerEffect => creature));
            //}
            //return new ReadOnlyCollection<Creature>(blockers);
        }

        public bool HasSpeedAttacker(Creature creature)
        {
            return GetContinuousEffects<SpeedAttackerEffect>().Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
        }

        public bool HasShieldTrigger(Spell spell)
        {
            foreach (SpellContinuousEffect spellContinuousEffect in GetContinuousEffects().Where(e => e is SpellShieldTriggerEffect).Cast<SpellShieldTriggerEffect>())
            {
                if (spellContinuousEffect.SpellFilter.FilteredSpells.Contains(spell))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasShieldTrigger(Creature creature)
        {
            foreach (CreatureShieldTriggerEffect creatureContinuousEffect in GetContinuousEffects().OfType<CreatureShieldTriggerEffect>())
            {
                if (creatureContinuousEffect.CreatureFilter.FilteredCreatures.Contains(creature))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetPower(Creature creature)
        {
            return creature.Power + GetContinuousEffects<PowerEffect>().Where(e => e.CreatureFilter.FilteredCreatures.Contains(creature)).Sum(e => e.Power);
        }

        public IEnumerable<Creature> GetCreaturesThatCannotAttack(Player player)
        {
            return new ReadOnlyCollection<Creature>(GetContinuousEffects<CannotAttackPlayersEffect>().SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct().Where(c => !Duel.GetCreaturesThatCanBeAttacked(player).Any()).ToList());
        }

        public bool AttacksIfAble(Creature creature)
        {
            return GetContinuousEffects<AttacksIfAbleEffect>().Any(e => e.CreatureFilter.FilteredCreatures.Contains(creature));
        }

        public IEnumerable<Creature> GetCreaturesThatCannotAttackPlayers()
        {
            return new ReadOnlyCollection<Creature>(GetContinuousEffects<CannotAttackPlayersEffect>().SelectMany(e => e.CreatureFilter.FilteredCreatures).Distinct().ToList());
        }

        /// <summary>
        /// Continuous effects that are generated by non-static abilities. Use method GetContinuousEffects() to obtain all continuous effects generated by non-static and static abilities.
        /// </summary>
        private readonly Collection<ContinuousEffect> _continuousEffects = new Collection<ContinuousEffect>();

        private IEnumerable<T> GetContinuousEffects<T>()
        {
            return GetContinuousEffects().Where(e => e is T).Cast<T>();
        }

        private List<ContinuousEffect> GetContinuousEffects()
        {
            throw new System.NotImplementedException();
            //List<ContinuousEffect> continuousEffects = _continuousEffects.ToList();
            //foreach (Card card in Duel.GetAllCards())
            //{
            //    continuousEffects.AddRange(AbilityManager.GetContinuousEffectsGeneratedByCard(card, card.Owner, Duel.BattleZone));
            //}
            //return new List<ContinuousEffect>(continuousEffects);
        }
    }
}
