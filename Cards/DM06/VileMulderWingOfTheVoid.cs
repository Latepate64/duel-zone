using StaticAbilities;
using ContinuousEffects;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;
using CardFilters;

namespace Cards.DM06;

sealed class VileMulderWingOfTheVoid : Creature
{
    public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4,
        7000, Race.DemonCommand, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect(new CreatureFilter()));
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WhenThisCreatureBattlesAbility(
                new AfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory(),
                    new DestroyThisCreatureEffect()
                )));
    }
}