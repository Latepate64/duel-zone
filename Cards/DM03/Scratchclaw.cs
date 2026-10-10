using Abilities.Static;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM03;

sealed class Scratchclaw : Creature
{
    public Scratchclaw() : base("Scratchclaw", 4, 1000, Race.Hedrian,
        Civilization.Darkness)
    {
        AddAbilities(new SlayerAbility());
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                1000, new CivilizationCreatureFilter(Civilization.Darkness)));
    }
}