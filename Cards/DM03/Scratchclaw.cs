using ContinuousEffects;

namespace Cards.DM03
{
    class Scratchclaw : Engine.Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Darkness));
        }
    }
}
