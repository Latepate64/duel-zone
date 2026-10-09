using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM02
{
    sealed class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Interfaces.Race.LiquidPeople, Interfaces.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
