using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    /// <summary>
    /// Battle Zone is the main place of the game. Creatures, Cross Gears, Weapons, Fortresses, Beats and Fields are put into the battle zone, but no mana, shields, castles nor spells may be put into the battle zone.
    /// </summary>
    public class BattleZone : Zone
    {
        private AsPermanentEntersBattleZoneAbility _pendingAbility = null;
        public Card PermanentEnteringBattleZone { get; private set; }
        public Zone PermanentSourceZone { get; private set; }

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
            if (zone.PermanentSourceZone != null)
            {
                PermanentSourceZone = zone.PermanentSourceZone.Copy();
            }
        }

        public void UntapCards()
        {
            foreach (Card card in Cards.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public override Choice Add(Card card, Duel duel, Zone source)
        {
            card.RevealedTo = duel.Players.Select(x => x.Id).ToList();
            PermanentEnteringBattleZone = card;
            PermanentSourceZone = source;
            var abilities = PermanentEnteringBattleZone.Abilities.OfType<AsPermanentEntersBattleZoneAbility>();
            if (abilities.Any())
            {
                _pendingAbility = abilities.Single();
                return _pendingAbility.Apply(duel, null);
            }
            else
            {
                Add(duel, false);
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
                Add(duel, true);
                _pendingAbility = null;
            }
        }

        private void Add(Duel duel, bool trigger)
        {
            var player = duel.GetOwner(PermanentEnteringBattleZone);
            player.BattleZone.Cards.Add(PermanentEnteringBattleZone);
            if (trigger)
            {
                //duel.Trigger(new CardMovedEvent(player, PermanentEnteringBattleZone, PermanentSourceZone, this)); //TODO
            }
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

        public override Zone Copy()
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
                PermanentSourceZone?.Dispose();
                PermanentSourceZone = null;
            }
        }

        public IEnumerable<Card> GetChoosableCreatures(Duel duel)
        {
            return Creatures.Where(x => !duel.GetContinuousEffects<UnchoosableEffect>(x).Any());
        }

        public override string ToString()
        {
            return "battle zone";
        }
    }
}