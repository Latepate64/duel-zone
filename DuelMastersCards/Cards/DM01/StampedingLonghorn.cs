using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine;

namespace Cards.Cards.DM01
{
    class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, Civilization.Nature, 4000, Subtype.HornedBeast)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(3000)));
        }
    }
}
