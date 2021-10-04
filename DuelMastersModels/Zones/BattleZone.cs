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
        public List<Permanent> Permanents { get; } = new List<Permanent>();

        public IEnumerable<Permanent> Creatures => Permanents.Where(x => x.CardType == CardType.Creature);

        public BattleZone()
        {
        }

        public BattleZone(BattleZone zone)
        {
            Permanents = zone.Permanents.Select(x => new Permanent(x)).ToList();
        }

        public void UntapCards()
        {
            foreach (Card card in Permanents.Where(x => x.Tapped))
            {
                card.Tapped = false;
            }
        }

        public void Add(Card card, Duel duel)
        {
            var permanent = new Permanent(card)
            {
                RevealedTo = duel.Players.Select(x => x.Id)
            };
            Permanents.Add(permanent);
            duel.Trigger(new CardChangedZoneEvent(permanent.Id, ZoneType.Anywhere, ZoneType.BattleZone));
        }

        public void Remove(Permanent permanent)
        {
            if (!Permanents.Remove(permanent))
            {
                throw new NotSupportedException(permanent.ToString());
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
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}