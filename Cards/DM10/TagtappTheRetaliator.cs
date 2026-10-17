using Abilities.Static;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM10;

public sealed class TagtappTheRetaliator : Creature
{
    public TagtappTheRetaliator(
        ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory
    ) : base("Tagtapp, the Retaliator", 3, 3000, Race.SpiritQuartz, Civilization.Fire,
        Civilization.Nature)
    {
        AddStaticAbilities(
            new TagtappTheRetaliatorEffect(),
            factory.Create(6000, doubleBreakerAbilityFactory.Create()));
    }
}
