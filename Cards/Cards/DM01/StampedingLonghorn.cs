using Cards.CardFilters;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, Common.Civilization.Nature, 4000, Common.Subtype.HornedBeast)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(3000)));
        }
    }
}
