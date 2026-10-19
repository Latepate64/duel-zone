using StaticAbilities;
using ContinuousEffects.Unblockable;
using CardFilters;

namespace Cards.DM02
{
    sealed class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, 6000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new MaxPowerFilter(5000)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
