using Abilities.Static;
using ContinuousEffects.PowerModifying;

namespace Cards.DM03
{
    sealed class Scratchclaw : Creature
    {
        public Scratchclaw() : base("Scratchclaw", 4, 1000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new SlayerAbility());
            AddStaticAbilities(new GetsPowerForEachOtherCivilizationCreatureYouControlEffect(1000, Interfaces.Civilization.Darkness));
        }
    }
}
