using ContinuousEffects;

namespace Cards.DM10
{
    class MelniaTheAquaShadow : Engine.Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, [Interfaces.Race.LiquidPeople, Interfaces.Race.Ghost], Interfaces.Civilization.Water, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
