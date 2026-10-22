using CardFilters;
using ContinuousEffects.Unblockable;

namespace Cards.DM01
{
    sealed class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, 4000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new MaxPowerFilter(3000)));
        }
    }
}
