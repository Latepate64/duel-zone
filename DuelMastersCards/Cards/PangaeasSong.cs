using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    class PangaeasSong : Spell
    {
        public PangaeasSong() : base("Pangaea's Song", 1, Civilization.Nature)
        {
            // Put 1 of your creatures from the battle zone into your mana zone.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(ZoneType.BattleZone, ZoneType.ManaZone, new OwnersBattleZoneCreatureFilter(), 1, 1, true)));
        }
    }
}
