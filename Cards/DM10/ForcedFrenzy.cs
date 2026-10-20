using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.AttacksIfAble;
using Interfaces;
using OneShotEffects;
using StaticAbilities;

namespace Cards.DM10;

public sealed class ForcedFrenzy : Spell
{
    public ForcedFrenzy(
        EachOfYourOpponentsCreaturesGetsAbilityEffectFactory effectFactory,
        CreaturesGetAbilitiesEffectFactory continuousEffectFactory)
        : base("Forced Frenzy", 3, Civilization.Fire)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            effectFactory.Create(
                new CreatureFilter(),
                continuousEffectFactory,
                new UntilStartOfPlayersNextTurn(),
                new StaticAbility(new ThisCreatureAttacksIfAbleEffect())
            ));
    }
}
