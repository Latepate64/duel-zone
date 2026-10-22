using StaticAbilities;
using ContinuousEffects.Unblockable;
using CardFilters;

namespace Cards.DM02
{
    sealed class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect(new CreatureFilter()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
