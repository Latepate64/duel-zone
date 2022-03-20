using Cards.CardFilters;
using Cards.OneShotEffects;

namespace Cards.Cards.DM01
{
    class PangaeasSong : Spell
    {
        public PangaeasSong() : base("Pangaea's Song", 1, Common.Civilization.Nature)
        {
            // Put 1 of your creatures from the battle zone into your mana zone.
            AddSpellAbilities(new ManaFeedEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true));
        }
    }
}
