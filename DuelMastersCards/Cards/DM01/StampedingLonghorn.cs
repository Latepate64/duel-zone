using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, Civilization.Nature, 4000, Subtype.HornedBeast)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(3000)));
        }
    }
}
