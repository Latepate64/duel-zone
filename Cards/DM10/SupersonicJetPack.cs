using StaticAbilities;
using CardFilters;
using ContinuousEffects.AbilityAdding;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class SupersonicJetPack : Spell
{
    public SupersonicJetPack() : base("Supersonic Jet Pack", 1,
        Civilization.Fire)
    {
        AddSpellAbilities(
            new OneOfYourCreaturesGetsAbilityEffect(
                new SpeedAttackerAbility(),
                new CreatureFilter(),
                new CreaturesGetAbilitiesEffectFactory(),
                new UntilEndOfThisTurnDuration()
            ));
    }
}