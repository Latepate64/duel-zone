using Abilities.Static;
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
            new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(
                new SpeedAttackerAbility(),
                new CreatureFilter(),
                new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffectFactory()
            ));
    }
}