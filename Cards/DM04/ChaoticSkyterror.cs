using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;

namespace Cards.DM04;

public sealed class ChaoticSkyterror : Creature
{
    public ChaoticSkyterror(
        RaceCreatureFilterFactory filterFactory,
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
        ) : base("Chaotic Skyterror", 5, 4000, Race.ArmoredWyvern, Civilization.Fire)
    {
        AddStaticAbilities(
            new EachCreatureHasTwoAbilitiesEffect(
                filterFactory.Create(Race.DemonCommand),
                4000,
                powerAttackerAbilityFactory,
                doubleBreakerAbilityFactory));
    }
}
