using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM09;

public sealed class TerradragonAnristVhal : Creature
{
    public TerradragonAnristVhal() : base("Terradragon Anrist Vhal", 6, 0,
        Race.EarthDragon, Civilization.Nature)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                2000, new CivilizationCreatureFilter(Civilization.Nature)),
            new PoweredDoubleBreaker());
    }
}
