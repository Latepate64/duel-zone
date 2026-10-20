using CardFilters;
using ContinuousEffects.AbilityAdding;
using ContinuousEffects.AttacksIfAble;
using Interfaces;
using OneShotEffects;
using StaticAbilities;

namespace Cards.DM10;

public sealed class InfernalCommand : Spell
{
    public InfernalCommand(CreaturesGetAbilitiesEffectFactory creaturesGetAbilitiesEffectFactory)
    : base("Infernal Command", 1, Civilization.Darkness)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new OneOfYourOpponentsCreaturesGetsAbilitiesEffect(
                new CreatureFilter(),
                creaturesGetAbilitiesEffectFactory,
                new UntilStartOfPlayersNextTurn(),
                new StaticAbility(new ThisCreatureAttacksIfAbleEffect())
            ));
    }
}
