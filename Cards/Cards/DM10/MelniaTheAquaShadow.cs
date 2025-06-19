using Cards.ContinuousEffects;

namespace Cards.Cards.DM10
{
    class MelniaTheAquaShadow : Creature
    {
        public MelniaTheAquaShadow() : base("Melnia, the Aqua Shadow", 2, 1000, [Engine.Race.LiquidPeople, Engine.Race.Ghost], Engine.Civilization.Water, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}
