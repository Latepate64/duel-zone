using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using ContinuousEffects.AbilityAdding;
using StaticAbilities;

namespace Cards.DM03;

public sealed class Flametropus : Creature
{
    public Flametropus(
        ThisCreatureGetsTwoAbilitiesEffectFactory thisCreatureGetsTwoAbilitiesEffectFactory,
        PowerAttackerAbilityFactory powerAttackerAbilityFactory,
        DoubleBreakerAbilityFactory doubleBreakerAbilityFactory,
        WheneverThisCreatureAttacksAbilityFactory wheneverThisCreatureAttacksAbilityFactory
    ) : base("Flametropus", 4, 3000, Race.RockBeast, Civilization.Fire)
    {
        AddTriggeredAbility(
            wheneverThisCreatureAttacksAbilityFactory.Create(
                new ThisCreatureGetsTwoAbilitiesIfYouSacrificeManaEffect(
                    thisCreatureGetsTwoAbilitiesEffectFactory,
                    powerAttackerAbilityFactory,
                    doubleBreakerAbilityFactory,
                    3000
                )));
    }
}
