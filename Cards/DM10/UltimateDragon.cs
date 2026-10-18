using StaticAbilities;
using CardFilters;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class UltimateDragon : Creature
{
    public UltimateDragon(DragonFilterFactory dragonFilterFactory) : base(
        "Ultimate Dragon", 6, 5000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachOfYourOtherCreatures(
                5000,
                dragonFilterFactory.Create()
            ));
        AddAbilities(new CrewBreakerAbility(dragonFilterFactory.Create()));
    }
}
