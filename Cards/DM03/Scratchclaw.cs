using ContinuousEffects;

namespace Cards.DM03
{
    sealed class Scratchclaw : Engine.Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Darkness));
        }
    }
}
