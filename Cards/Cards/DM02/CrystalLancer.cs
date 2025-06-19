using Cards.ContinuousEffects;
using Effects.Continuous;

namespace Cards.Cards.DM02
{
    class CrystalLancer : EvolutionCreature
    {
        public CrystalLancer() : base("Crystal Lancer", 6, 8000, Engine.Race.LiquidPeople, Engine.Civilization.Water)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
