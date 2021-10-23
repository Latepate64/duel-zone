using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : ICopyable<BattleZone>, IDisposable
    {
        /// <summary>
        /// Note: Prefer use of property Creatures.
        /// </summary>
        public List<Permanent> Permanents { get; } = new List<Permanent>();

        /// <summary>
        /// Note: Use method GetChoosableCreatures when selecting creatures controller by opponent.
        /// </summary>
        public IEnumerable<Permanent> Creatures => Permanents.Where(x => x.CardType == CardType.Creature);

        private AsPermanentEntersBattleZoneAbility _pendingAbility = null;
        public Permanent PermanentEnteringBattleZone { get; private set; }

        public BattleZone()
        {
        }

        public BattleZone(BattleZone zone)
        {
            Permanents = zone.Permanents.Select(x => new Permanent(x)).ToList();
            _pendingAbility = zone._pendingAbility?.Copy() as AsPermanentEntersBattleZoneAbility;
            if (zone.PermanentEnteringBattleZone != null)
            {
                PermanentEnteringBattleZone = new Permanent(zone.PermanentEnteringBattleZone);
            }
        }

        public void UntapCards()
        {
            foreach (Card card in Permanents.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public Choice Add(Card card, Duel duel)
        {
            PermanentEnteringBattleZone = new Permanent(card)
            {
                RevealedTo = duel.Players.Select(x => x.Id)
            };
            var abilities = PermanentEnteringBattleZone.Abilities.OfType<AsPermanentEntersBattleZoneAbility>();
            if (abilities.Any())
            {
                _pendingAbility = abilities.Single();
                return _pendingAbility.Apply(duel, null);
            }
            else
            {
                Add(duel);
                return null;
            }
        }

        public void Add(Duel duel, Decision decision)
        {
            var dec = _pendingAbility.Apply(duel, decision);
            if (dec != null)
            {
                throw new NotImplementedException("Should never happen in TCG");
            }
            else
            {
                Add(duel);
                _pendingAbility = null;
            }
        }

        private void Add(Duel duel)
        {
            Permanents.Add(PermanentEnteringBattleZone);
            duel.Trigger(new PutIntoBattleZoneEvent(new Permanent(PermanentEnteringBattleZone), new Player(duel.GetOwner(PermanentEnteringBattleZone))));
            PermanentEnteringBattleZone = null;
        }

        public void Remove(Permanent permanent)
        {
            if (!Permanents.Remove(permanent))
            {
                throw new NotSupportedException(permanent.ToString());
            }
            foreach (var ability in permanent.Abilities.OfType<AsPermanentEntersBattleZoneAbility>())
            {
                ability.Revoke();
            }
        }

        public BattleZone Copy()
        {
            return new BattleZone(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Permanents != null)
            {
                foreach (var permanent in Permanents)
                {
                    permanent.Dispose();
                }
                Permanents.Clear();
                _pendingAbility?.Dispose();
                _pendingAbility = null;
                PermanentEnteringBattleZone?.Dispose();
                PermanentEnteringBattleZone = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Permanent> GetChoosableCreatures(Duel duel)
        {
            return Creatures.Where(x => !duel.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }
    }
}