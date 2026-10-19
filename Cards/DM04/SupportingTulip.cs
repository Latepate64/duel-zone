using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM04;

public sealed class SupportingTulip : Creature
{
    public SupportingTulip(
        EachCreatureHasAbilitiesEffectFactory eachCreatureHasAbilityEffectFactory,
        RaceCreatureFilterFactory raceCreatureFilterFactory,
        PowerAttackerAbilityFactory powerAttackerAbilityFactory
    ) : base("Supporting Tulip", 5, 4000, Race.TreeFolk, Civilization.Nature)
    {
        AddStaticAbilities(
            eachCreatureHasAbilityEffectFactory.Create(
                raceCreatureFilterFactory.Create(Race.AngelCommand),
                powerAttackerAbilityFactory.Create(4000)
            ));
    }
}
