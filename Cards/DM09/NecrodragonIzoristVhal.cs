using Abilities.Static;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;

namespace Cards.DM09;

public sealed class NecrodragonIzoristVhal : Creature
{
    public NecrodragonIzoristVhal(
        ThisCreatureHasAbilityWhilePowerAtLeastEffectFactory factory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory) : base(
            "Necrodragon Izorist Vhal", 6, 0, Race.ZombieDragon, Civilization.Darkness)
    {
        AddStaticAbilities(
            new ThisCreatureGetsPowerForEachCardInYourGraveyardEffect(
                2000,
                new CivilizationCreatureFilter(Civilization.Darkness)),
            factory.Create(6000, doubleBreakerAbilityFactory.Create()));
    }
}
