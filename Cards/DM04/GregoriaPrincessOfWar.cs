using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAddingPowerModifying;
using Interfaces;

namespace Cards.DM04;

public sealed class GregoriaPrincessOfWar : Creature
{
    public GregoriaPrincessOfWar(
        RaceCreatureFilterFactory raceCreatureFilterFactory,
        BlockerAbilityFactory blockerAbilityFactory
    ) : base("Gregoria, Princess of War", 6, 5000, Race.DarkLord,
        Civilization.Darkness)
    {
        AddStaticAbilities(
            new EachCreatureGetsPowerAndAbilityEffect(
                raceCreatureFilterFactory.Create(Race.DemonCommand),
                2000,
                blockerAbilityFactory.Create()
            ));
    }
}
