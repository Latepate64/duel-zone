using Abilities.Static;
using ContinuousEffects.CannotAttackCreatures;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class VileMulderWingOfTheVoid : Creature
{
    public VileMulderWingOfTheVoid() : base("Vile Mulder, Wing of the Void", 4,
        7000, Race.DemonCommand, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureCannotAttackCreaturesEffect());
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WhenThisCreatureBattlesAbility(
                new AfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory(),
                    new DestroyThisCreatureEffect()
                )));
    }
}