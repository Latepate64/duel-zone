using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Scratchclaw : Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddSlayerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Engine.Civilization.Darkness));
        }
    }
}
