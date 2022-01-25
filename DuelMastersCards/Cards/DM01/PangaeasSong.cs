using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM01
{
    class PangaeasSong : Spell
    {
        public PangaeasSong() : base("Pangaea's Song", 1, Civilization.Nature)
        {
            // Put 1 of your creatures from the battle zone into your mana zone.
            Abilities.Add(new SpellAbility(new ManaFeedEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true)));
        }
    }
}
