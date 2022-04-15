using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class Scratchclaw : Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddSlayerAbility();
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Civilization.Darkness));
        }
    }
}
