using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM04;

public sealed class ChaoticSkyterror : Creature
{
    public ChaoticSkyterror(
        RaceCreatureFilterFactory filterFactory,
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        EachCreatureHasAbilitiesEffectFactory eachCreatureHasAbilitiesEffectFactory
        ) : base("Chaotic Skyterror", 5, 4000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(
            eachCreatureHasAbilitiesEffectFactory.Create(
                filterFactory.Create(Race.DemonCommand),
                powerAttackerAbilityFactory.Create(4000),
                doubleBreakerAbilityFactory.Create()
            ));
    }
}
