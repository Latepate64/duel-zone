using Abilities;
using Abilities.Static;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class GigiosHammer : Creature
{
    public GigiosHammer(
        TapAbilityFactory tapAbilityFactory,
        ContinuousEffectWithRaceIntegerAndAbilityFactory continuousEffectFactory,
        PowerAttackerAbilityFactory powerAttackerFactory
    ) : base("Gigio's Hammer", 3, 2000, Race.Xenoparts, Civilization.Fire)
    {
        AddAbilities(
            tapAbilityFactory.Create(
                new AddRaceAffectingAbilityAddingEffect(
                    continuousEffectFactory,
                    powerAttackerFactory,
                    4000
                )));
    }
}
