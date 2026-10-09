using Abilities.Static;
using ContinuousEffects.Unblockable;

namespace Cards.DM10
{
    sealed class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, [Interfaces.Race.LiquidPeople, Interfaces.Race.Ghost], Interfaces.Civilization.Water, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddAbilities(new SlayerAbility());
        }
    }
}
