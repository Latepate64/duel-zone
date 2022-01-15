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
    public class BattleZone : Zone, ICopyable<BattleZone>
    {
        private AsPermanentEntersBattleZoneAbility _pendingAbility = null;
        public Card PermanentEnteringBattleZone { get; private set; }

        public BattleZone(IEnumerable<Card> cards) : base(cards)
        {
        }

        public BattleZone(BattleZone zone) : base(zone.Cards.Select(x => x.Copy()))
        {
            _pendingAbility = zone._pendingAbility?.Copy() as AsPermanentEntersBattleZoneAbility;
            if (zone.PermanentEnteringBattleZone != null)
            {
                PermanentEnteringBattleZone = new Card(zone.PermanentEnteringBattleZone, false);
            }
        }

        public void UntapCards()
        {
            foreach (Card card in Cards.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public override Choice Add(Card card, Duel duel)
        {
            PermanentEnteringBattleZone = new Card(card, true)
            {
                RevealedTo = duel.Players.Select(x => x.Id).ToList()
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
            Cards.Add(PermanentEnteringBattleZone);
            duel.Trigger(new PutIntoBattleZoneEvent(new Card(PermanentEnteringBattleZone, true), new Player(duel.GetOwner(PermanentEnteringBattleZone))));
            PermanentEnteringBattleZone = null;
        }

        public override void Remove(Card card)
        {
            if (!Cards.Remove(card))
            {
                throw new NotSupportedException(card.ToString());
            }
            foreach (var ability in card.Abilities.OfType<AsPermanentEntersBattleZoneAbility>())
            {
                ability.Revoke();
            }
        }

        public BattleZone Copy()
        {
            return new BattleZone(this);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _pendingAbility?.Dispose();
                _pendingAbility = null;
                PermanentEnteringBattleZone?.Dispose();
                PermanentEnteringBattleZone = null;
            }
        }

        public IEnumerable<Card> GetChoosableCreatures(Duel duel)
        {
            return Creatures.Where(x => !duel.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }
    }
}