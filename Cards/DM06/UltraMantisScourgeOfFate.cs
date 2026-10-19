using StaticAbilities;
using ContinuousEffects.Unblockable;
using CardFilters;

namespace Cards.DM06
{
    sealed class UltraMantisScourgeOfFate : EvolutionCreature
    {
        public UltraMantisScourgeOfFate() : base("Ultra Mantis, Scourge of Fate", 6, 9000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new MaxPowerFilter(8000)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
