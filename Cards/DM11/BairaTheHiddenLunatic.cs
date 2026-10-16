using Abilities.Static;
using ContinuousEffects.CannotAttack;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM11;

sealed class BairaTheHiddenLunatic : Creature
{
    public BairaTheHiddenLunatic() : base("Baira, the Hidden Lunatic", 3, 5000,
        Race.PandorasBox, Civilization.Darkness)
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