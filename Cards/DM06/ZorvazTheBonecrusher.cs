using Abilities.Static;
using ContinuousEffects.CannotAttack;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM06;

sealed class ZorvazTheBonecrusher : Creature
{
    public ZorvazTheBonecrusher() : base("Zorvaz, the Bonecrusher", 5, 8000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddAbilities(new BlockerAbility());
        AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        AddTriggeredAbility(
            new WhenThisCreatureBattlesAbility(
                new DestroyAfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory()
                )));
    }
}