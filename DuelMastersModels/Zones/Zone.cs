using DuelMastersModels.Choices;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Zones
{
    public enum ZoneType { Anywhere, BattleZone, Deck, Graveyard, Hand, ManaZone, ShieldZone, SpellStack };

    /// <summary>
    /// A zone is an area where cards can be during a game. There are normally eight zones: deck, hand, battle zone, graveyard, mana zone, shield zone, hyperspatial zone and "super gacharange zone". Each player has their own zones except for the battle zone which is shared by each player.
    /// </summary>
    public abstract class Zone : System.IDisposable
    {
        public List<Card> Cards { get; private set; }

        public IEnumerable<Card> Creatures => Cards.Where(x => x.CardType == CardType.Creature);

        #region Methods
        protected Zone(IEnumerable<Card> cards)
        {
            Cards = new List<Card>(cards.ToList());
        }

        public abstract Choice Add(Card card, Duel duel);

        public abstract void Remove(Card card);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Cards != null)
            {
                foreach (var card in Cards)
                {
                    card.Dispose();
                }
                Cards = null;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
        #endregion Methods
    }
}
