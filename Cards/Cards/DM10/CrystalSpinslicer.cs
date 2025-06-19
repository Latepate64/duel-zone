using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM10
{
    class CrystalSpinslicer : EvolutionCreature
    {
        public CrystalSpinslicer() : base("Crystal Spinslicer", 2, 5000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }
    }
}
