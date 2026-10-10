using Abilities.Static;
using CardFilters;
using ContinuousEffects.CanAttackUntappedCreatures;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM03;

sealed class GarkagoDragon : Creature
{
    public GarkagoDragon() : base("Garkago Dragon", 7, 6000, Race.ArmoredDragon,
        Civilization.Fire)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddStaticAbilities(
        new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
            1000, new CivilizationCreatureFilter(Civilization.Fire)
        ));
        AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        
    }
}