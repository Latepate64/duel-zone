using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.PowerModifying;
using Interfaces;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SwordOfMalevolentDeath : Spell
{
    public SwordOfMalevolentDeath(
        EachOfYourCreaturesGetsAbilityEffectFactory factory,
        ThisCreatureGetsAbilitiesUntilTheEndOfTheTurnEffectFactory continuousEffectFactory
    ) : base("Sword of Malevolent Death", 4,
        Civilization.Darkness)
    {
        AddSpellAbilities(
            factory.Create(
                new CreatureFilter(),
                continuousEffectFactory,
                new UntilEndOfThisTurnDuration(),
                new StaticAbility(
                    new WhileAttackingThisCreatureGetPowerForEachCardInYourManaZoneEffect(
                        1000,
                        new CivilizationCardFilter(Civilization.Darkness)
                ))
            ));
    }
}
